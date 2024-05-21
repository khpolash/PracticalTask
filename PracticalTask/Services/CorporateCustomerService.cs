using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticalTask.DbConnection;
using PracticalTask.Models.Entities;
using PracticalTask.Models.ViewModels;
using PracticalTask.Services.Base;

namespace PracticalTask.Services;

public class CorporateCustomerService : BaseService<CorporateCustomer, CorporateCustomerVm>, ICorporateCustomerService
{
    public CorporateCustomerService(PracticalTaskDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<IEnumerable<SelectListItem>> Dropdown()
    {
        return await GetAll().Select(x => new SelectListItem
        {
            Text = x.CustomerName,
            Value = x.Id.ToString(),
        }).ToListAsync();
    }

    public async Task<IEnumerable<SelectListItem>> Dropdown(int? selectedId)
    {
        return await GetAll().Select(x => new SelectListItem
        {
            Text = x.CustomerName,
            Value = x.Id.ToString(),
            Selected = x.Id == selectedId
        }).ToListAsync();
    }
}
