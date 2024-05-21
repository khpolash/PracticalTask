using System.ComponentModel.DataAnnotations.Schema;

namespace PracticalTask.Models.Entities;

[Table("Products_Service_Tbl")]
public class Product
{
    public Product()
    {
        MeetingMinutesDetails = new HashSet<MeetingMinutesDetails>();
    }
    public int Id { get; set; }
    public string ProductName { get; set; }
    public int UnitId { get; set; }

    [ForeignKey(nameof(UnitId))]
    public ProductUnit ProductUnit { get; set; }

    public ICollection<MeetingMinutesDetails> MeetingMinutesDetails { get; set; }
}
