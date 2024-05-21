using System.ComponentModel.DataAnnotations.Schema;

namespace PracticalTask.Models.Entities;

[Table("Corporate_Customer_Tbl")]
public class CorporateCustomer
{
    public CorporateCustomer()
    {
        MeetingMinutesMasters = new HashSet<MeetingMinutesMaster>();
    }
    public int Id { get; set; }
    public string CustomerName { get; set; }

    public ICollection<MeetingMinutesMaster> MeetingMinutesMasters { get; set; }
}
