using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PracticalTask.DbConnection;
using PracticalTask.Models.Entities;
using PracticalTask.Models.ViewModels;
using PracticalTask.Services.Base;

namespace PracticalTask.Services;

public class ProductUnitService : BaseService<ProductUnit, ProductUnitVm>, IProductUnitService
{
    public ProductUnitService(PracticalTaskDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<IEnumerable<SelectListItem>> Dropdown()
    {
        return await GetAll().Select(x => new SelectListItem
        {
            Text = x.UnitName,
            Value = x.Id.ToString(),
        }).ToListAsync();
    }
}
