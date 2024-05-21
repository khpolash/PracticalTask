using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PracticalTask.Models.ViewModels;

public class ProductVm
{
    public ProductVm()
    {
        UnitDropdown = new List<SelectListItem>();
    }
    public int Id { get; set; }

    [DisplayName("Product Name")]
    [Required(ErrorMessage = "Product Name is required.")]
    public string ProductName { get; set; }

    [DisplayName("Unit")]
    [Required(ErrorMessage = "Unit is required.")]
    public int UnitId { get; set; }

    [DisplayName("Unit Name")]
    public string UnitName { get; set; }

    public IEnumerable<SelectListItem> UnitDropdown { get; set; }
}