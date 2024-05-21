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
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductUnitService _productUnitService;

        public ProductController(IProductService productService, IProductUnitService productUnitService)
        {
            _productService = productService;
            _productUnitService = productUnitService;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            var list = await _productService.GetAllAsync(x => x.ProductUnit);
            return View(list);
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.FirstOrDefaultAsync(id, x => x.ProductUnit);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Product/Create
        public async Task<IActionResult> Create()
        {
            var model = new ProductVm
            {
                UnitDropdown = await _productUnitService.Dropdown()
            };
            return View(model);
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductVm model)
        {
            if (ModelState.IsValid)
            {
                await _productService.InsertAsync(model);
                return RedirectToAction(nameof(Index));
            }
            model.UnitDropdown = await _productUnitService.Dropdown();
            return View(model);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _productService.FirstOrDefaultAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            model.UnitDropdown = await _productUnitService.Dropdown();
            return View(model);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductVm model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _productService.UpdateAsync(id, model);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductServiceExists(model.Id))
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
            model.UnitDropdown = await _productUnitService.Dropdown();
            return View(model);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.FirstOrDefaultAsync(id, x => x.ProductUnit);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _productService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ProductServiceExists(int id)
        {
            return _productService.GetAll().Any(e => e.Id == id);
        }
    }
}
