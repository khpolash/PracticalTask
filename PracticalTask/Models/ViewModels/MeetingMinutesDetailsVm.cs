using Microsoft.AspNetCore.Mvc.Rendering;
using PracticalTask.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticalTask.Models.ViewModels;

public class MeetingMinutesDetailsVm
{
    public MeetingMinutesDetailsVm()
    {
        ProductDropdown = new List<SelectListItem>();
    }
    public int Id { get; set; }

    [Display(Name = "Meeting")]
    public int? MeetingId { get; set; }

    [Display(Name = "Product")]
    [Required(ErrorMessage = "Product is required.")]
    public int? ProductId { get; set; }

    [Display(Name = "Product Name")]
    public string ProductName { get; set; }

    [Required(ErrorMessage = "Quantity is required.")]
    public int? Quantity { get; set; }


    public IEnumerable<SelectListItem> ProductDropdown { get; set; }
}
