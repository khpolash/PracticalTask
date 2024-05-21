using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticalTask.Models.ViewModels;
using PracticalTask.Services;
using System.Transactions;

namespace PracticalTask.Controllers;

public class MeetingMinutesMasterController : Controller
{
    private readonly IMeetingMinutesMasterService _meetingMinutesMasterService;
    private readonly ICorporateCustomerService _corporateCustomerService;
    private readonly IIndividualCustomerService _individualCustomerService;
    private readonly IProductService _productService;
    private readonly IMeetingMinutesDetailsService _meetingMinutesDetailsService;

    public MeetingMinutesMasterController(IMeetingMinutesMasterService meetingMinutesMasterService, ICorporateCustomerService corporateCustomerService, IIndividualCustomerService individualCustomerService, IProductService productService, IMeetingMinutesDetailsService meetingMinutesDetailsService)
    {
        _meetingMinutesMasterService = meetingMinutesMasterService;
        _corporateCustomerService = corporateCustomerService;
        _individualCustomerService = individualCustomerService;
        _productService = productService;
        _meetingMinutesDetailsService = meetingMinutesDetailsService;
    }

    // GET:  MeetingMinutesMaster
    public async Task<IActionResult> Index()
    {
        var list = await _meetingMinutesMasterService.GetAllAsync(x => x.IndividualCustomer, x => x.CorporateCustomer, x => x.MeetingMinutesDetails);
        return View(list);
    }

    // GET: MeetingMinutesMaster/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var meetingMinutes = await _meetingMinutesMasterService.FirstOrDefaultAsync(id, x => x.CorporateCustomer, x => x.IndividualCustomer);
        meetingMinutes.Products = await _meetingMinutesDetailsService.GetAllAsync(x => x.MeetingId == meetingMinutes.Id, x => x.Product);
        if (meetingMinutes == null)
        {
            return NotFound();
        }

        return View(meetingMinutes);
    }

    // GET: MeetingMinutesMaster/Create
    public async Task<IActionResult> Create()
    {
        var model = new MeetingMinutesMasterVm
        {
            IndividualCustomerDropdown = await _individualCustomerService.Dropdown(),
            CorporateCustomerDropdown = await _corporateCustomerService.Dropdown(),
            MeetingDate = DateTime.Now,
        };
        ViewBag.ProductDropdown = await _productService.Dropdown();
        return View(model);
    }

    // POST: MeetingMinutesMaster/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(MeetingMinutesMasterVm model)
    {
        var success = false;
        using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Products.Count < 1)
                        throw new ArgumentException("Product not found.");

                    var result = await _meetingMinutesMasterService.InsertMeetingMinutesMasterAsync(model.CorporateCustomerId, model.IndividualCustomerId, model.MeetingDate, model.MeetingPlace, model.AttendsFormClientSide, model.AttendsFormHostSide, model.MeetingAgenda, model.MeetingDiscussion, model.MeetingDecision);

                    var products = model.Products.Select(e =>
                    {
                        e.MeetingId = result;
                        return e;
                    }).ToList();

                    foreach (var item in products)
                    {
                        await _meetingMinutesDetailsService.InsertMeetingMinutesDetailAsync(item.MeetingId, item.ProductId, item.Quantity);
                    }


                    success = true;
                    transaction.Complete();
                }
                else
                {
                    success = false;
                    transaction.Dispose();
                }
            }
            catch (Exception)
            {
                success = false;
                transaction.Dispose();
            }
        }

        return Json(new { success, message = "Meeting minutes saved successfully." });

    }

    // GET: MeetingMinutesMaster/Edit
    public async Task<ActionResult> Edit(int id)
    {
        var model = await _meetingMinutesMasterService.GetByIdAsync(id);

        if (model == null)
            return NotFound();

        model.CorporateCustomerDropdown = await _corporateCustomerService.Dropdown(model.CorporateCustomerId);
        model.IndividualCustomerDropdown = await _individualCustomerService.Dropdown(model.IndividualCustomerId);
        model.Products = await _meetingMinutesDetailsService.GetAllAsync(x => x.MeetingId == model.Id, x => x.Product);
        ViewBag.ProductDropdown = await _productService.Dropdown();

        return View(model);
    }

    // POST: MeetingMinutesMaster/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(MeetingMinutesMasterVm model)
    {
        var success = false;
        using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Products.Count < 1)
                        throw new ArgumentException("Product not found.");

                    var result = await _meetingMinutesMasterService.UpdateAsync(model.Id, model);

                    var products = model.Products.Select(e =>
                    {
                        e.MeetingId = result.Id;
                        return e;
                    }).ToList();
                    var deletedId = _meetingMinutesDetailsService.GetAll().Where(x => x.MeetingId == result.Id).Select(x => x.Id).ToArray();
                    foreach (var delete in deletedId)
                    {
                        await _meetingMinutesDetailsService.DeleteAsync(delete);
                    }
                    foreach (var item in products)
                    {
                        await _meetingMinutesDetailsService.InsertMeetingMinutesDetailAsync(item.MeetingId, item.ProductId, item.Quantity);
                    }


                    success = true;
                    transaction.Complete();
                }
                else
                {
                    success = false;
                    transaction.Dispose();
                }
            }
            catch (Exception)
            {
                success = false;
                transaction.Dispose();
            }
        }

        return Json(new { success, message = "Meeting minutes update successfully." });
    }


    // GET: Product/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var meetingMinutes = await _meetingMinutesMasterService.FirstOrDefaultAsync(id, x => x.CorporateCustomer, x => x.IndividualCustomer);
        meetingMinutes.Products = await _meetingMinutesDetailsService.GetAllAsync(x => x.MeetingId == meetingMinutes.Id, x => x.Product);
        if (meetingMinutes == null)
        {
            return NotFound();
        }

        return View(meetingMinutes);
    }

    // POST: Product/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var meetingMinutes = await _meetingMinutesMasterService.FirstOrDefaultAsync(id);
        if (meetingMinutes == null)
        {
            return NotFound();
        }
        var products = await _meetingMinutesDetailsService.GetAllAsync(x => x.MeetingId == meetingMinutes.Id);
        foreach (var product in products)
        {
            await _meetingMinutesDetailsService.DeleteAsync(product.Id);
        }
        await _meetingMinutesMasterService.DeleteAsync(id);

        return RedirectToAction(nameof(Index));
    }

}
