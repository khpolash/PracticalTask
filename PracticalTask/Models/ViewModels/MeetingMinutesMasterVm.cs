using Microsoft.AspNetCore.Mvc.Rendering;
using PracticalTask.Models.CustomValidations;
using PracticalTask.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PracticalTask.Models.ViewModels;

public class MeetingMinutesMasterVm
{
    public MeetingMinutesMasterVm()
    {
        CorporateCustomerDropdown = new List<SelectListItem>();
        IndividualCustomerDropdown = new List<SelectListItem>();
        Products = new List<MeetingMinutesDetailsVm>();
    }

    public int Id { get; set; }


    [Display(Name = "Customer Name")]
    public int? CorporateCustomerId { get; set; }

    [Display(Name = "Customer Name")]
    public string CorporateCustomerName { get; set; }

    [Display(Name = "Customer Name")]
    public int? IndividualCustomerId { get; set; }

    [Display(Name = "Customer Name")]
    public string IndividualCustomerName { get; set; }

    [Display(Name = "Meeting Date")]
    [DataType(DataType.DateTime)]
    [Required(ErrorMessage = "Meeting Date is required.")]
    public DateTime? MeetingDate { get; set; }

    [Display(Name = "Meeting Place")]
    [Required(ErrorMessage = "Meeting Place is required.")]
    public string MeetingPlace { get; set; }

    [Display(Name = "Attends Form Client Side")]
    [Required(ErrorMessage = "Attends Form Client Side is required.")]
    public string AttendsFormClientSide { get; set; }

    [Display(Name = "Attends Form Host Side")]
    [Required(ErrorMessage = "Attends Form Host Side is required.")]
    public string AttendsFormHostSide { get; set; }

    [Display(Name = "Meeting Agenda")]
    [Required(ErrorMessage = "Meeting Agenda is required.")]
    public string MeetingAgenda { get; set; }

    [Display(Name = "Meeting Discussion")]
    [Required(ErrorMessage = "Meeting Discussion is required.")]
    public string MeetingDiscussion { get; set; }

    [Display(Name = "Meeting Decision")]
    [Required(ErrorMessage = "Meeting Decision is required.")]
    public string MeetingDecision { get; set; }

    public IEnumerable<SelectListItem> CorporateCustomerDropdown { get; set; }

    public IEnumerable<SelectListItem> IndividualCustomerDropdown { get; set; }

    public IList<MeetingMinutesDetailsVm> Products { get; set; }
}