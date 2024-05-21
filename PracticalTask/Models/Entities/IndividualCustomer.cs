using System.ComponentModel.DataAnnotations.Schema;

namespace PracticalTask.Models.Entities;

[Table("Individual_Customer_Tbl")]
public class IndividualCustomer
{
    public IndividualCustomer()
    {
        MeetingMinutesMasters = new HashSet<MeetingMinutesMaster>();
    }
    public int Id { get; set; }
    public string CustomerName { get; set; }

    public ICollection<MeetingMinutesMaster> MeetingMinutesMasters { get; set; }
}