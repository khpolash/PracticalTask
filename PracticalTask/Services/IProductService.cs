using Microsoft.AspNetCore.Mvc.Rendering;
using PracticalTask.Models.Entities;
using PracticalTask.Models.ViewModels;
using PracticalTask.Services.Base;

namespace PracticalTask.Services;

public interface IProductService : IBaseService<Product, ProductVm>
{
    Task<IEnumerable<SelectListItem>> Dropdown();
}