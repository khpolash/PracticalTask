using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticalTask.DbConnection;
using PracticalTask.Models.Entities;
using PracticalTask.Models.ViewModels;
using PracticalTask.Services;

namespace PracticalTask.Controllers
{
    public class ProductUnitController : Controller
    {
        private readonly IProductUnitService _productUnitService;

        public ProductUnitController(IProductUnitService productUnitService)
        {
            _productUnitService = productUnitService;
        }

        // GET: ProductUnit
        public async Task<IActionResult> Index()
        {
            var unitList = await _productUnitService.GetAllAsync();
            return View(unitList);
        }

        // GET: ProductUnit/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productUnit = await _productUnitService.GetByIdAsync(id);
            if (productUnit == null)
            {
                return NotFound();
            }

            return View(productUnit);
        }

        // GET: ProductUnit/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductUnit/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductUnitVm model)
        {
            if (ModelState.IsValid)
            {
                await _productUnitService.InsertAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: ProductUnit/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productUnit = await _productUnitService.GetByIdAsync(id);
            if (productUnit == null)
            {
                return NotFound();
            }
            return View(productUnit);
        }

        // POST: ProductUnit/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductUnitVm model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _productUnitService.UpdateAsync(id, model);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductUnitExists(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: ProductUnit/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productUnit = await _productUnitService.GetByIdAsync(id);
            if (productUnit == null)
            {
                return NotFound();
            }

            return View(productUnit);
        }

        // POST: ProductUnit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productUnitService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ProductUnitExists(int id)
        {
            return _productUnitService.GetAll().Any(e => e.Id == id);
        }
    }
}
