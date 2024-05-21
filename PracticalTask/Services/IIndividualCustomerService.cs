using Microsoft.AspNetCore.Mvc.Rendering;
using PracticalTask.Models.Entities;
using PracticalTask.Models.ViewModels;
using PracticalTask.Services.Base;

namespace PracticalTask.Services;

public interface IIndividualCustomerService : IBaseService<IndividualCustomer, IndividualCustomerVm>
{
    Task<IEnumerable<SelectListItem>> Dropdown();
    Task<IEnumerable<SelectListItem>> Dropdown(int? individualCustomerId);
}