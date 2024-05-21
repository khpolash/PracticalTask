using PracticalTask.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace PracticalTask.Models.ViewModels;

public class IndividualCustomerVm
{
    public int Id { get; set; }

    [Display(Name = "Customer Name")]
    [Required(ErrorMessage = "Customer Name is required.")]
    public string CustomerName { get; set; }

}