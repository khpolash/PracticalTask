using System.ComponentModel.DataAnnotations.Schema;

namespace PracticalTask.Models.Entities;

[Table("Meeting_Minutes_Master_Tbl")]
public class MeetingMinutesMaster
{
    public MeetingMinutesMaster()
    {
        MeetingMinutesDetails = new HashSet<MeetingMinutesDetails>();
    }
    public int Id { get; set; }
    public int? CorporateCustomerId { get; set; }
    [ForeignKey(nameof(CorporateCustomerId))]
    public CorporateCustomer CorporateCustomer { get; set; }
    public int? IndividualCustomerId { get; set; }
    [ForeignKey(nameof(IndividualCustomerId))]
    public IndividualCustomer IndividualCustomer { get; set; }
    public DateTime? MeetingDate { get; set; }
    public string MeetingPlace { get; set; }
    public string AttendsFormClientSide { get; set; }
    public string AttendsFormHostSide { get; set; }
    public string MeetingAgenda { get; set; }
    public string MeetingDiscussion { get; set; }
    public string MeetingDecision { get; set; }

    public ICollection<MeetingMinutesDetails> MeetingMinutesDetails { get; set; }
}
