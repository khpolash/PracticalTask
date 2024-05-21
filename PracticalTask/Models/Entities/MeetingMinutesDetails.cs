using System.ComponentModel.DataAnnotations.Schema;

namespace PracticalTask.Models.Entities;

[Table("Meeting_Minutes_Details_Tbl")]
public class MeetingMinutesDetails
{
    public int Id { get; set; }
    public int? MeetingId { get; set; }

    [ForeignKey(nameof(MeetingId))]
    public MeetingMinutesMaster MeetingMinutesMaster { get; set; }
    public int? ProductId { get; set; }

    [ForeignKey(nameof(ProductId))]
    public Product Product { get; set; }
    public int? Quantity { get; set; }
}
