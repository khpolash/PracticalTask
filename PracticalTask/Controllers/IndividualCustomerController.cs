using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticalTask.Models.ViewModels;
using PracticalTask.Services;

namespace PracticalTask.Controllers;

public class IndividualCustomerController : Controller
{
    private readonly IIndividualCustomerService _individualCustomerService;

    public IndividualCustomerController(IIndividualCustomerService individualCustomerService)
    {
        _individualCustomerService = individualCustomerService;
    }

    // GET: Product
    public async Task<IActionResult> Index()
    {
        var list = await _individualCustomerService.GetAllAsync();
        return View(list);
    }

    // GET: Product/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await _individualCustomerService.FirstOrDefaultAsync(id);

        if (product == null)
        {
            return NotFound();
        }

        return View(product);
    }

    // GET: Product/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Product/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(IndividualCustomerVm model)
    {
        if (ModelState.IsValid)
        {
            await _individualCustomerService.InsertAsync(model);
            return RedirectToAction(nameof(Index));
        }
        return View(model);
    }

    // GET: Product/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var model = await _individualCustomerService.FirstOrDefaultAsync(id);
        if (model == null)
        {
            return NotFound();
        }
        return View(model);
    }

    // POST: Product/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, IndividualCustomerVm model)
    {
        if (id != model.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _individualCustomerService.UpdateAsync(id, model);
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
        return View(model);
    }

    // GET: Product/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await _individualCustomerService.FirstOrDefaultAsync(id);
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
        await _individualCustomerService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }

    private bool ProductServiceExists(int id)
    {
        return _individualCustomerService.GetAll().Any(e => e.Id == id);
    }
}
