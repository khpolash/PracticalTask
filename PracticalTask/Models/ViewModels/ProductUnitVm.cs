using PracticalTask.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace PracticalTask.Models.ViewModels;

public class ProductUnitVm
{
    public int Id { get; set; }

    [Display(Name = "Unit Name")]
    [Required(ErrorMessage = "Unit Name is required.")]
    public string UnitName { get; set; }
}