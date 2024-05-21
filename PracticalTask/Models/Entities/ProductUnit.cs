using System.ComponentModel.DataAnnotations.Schema;

namespace PracticalTask.Models.Entities;

[Table("Product_Unit_Tbl")]
public class ProductUnit
{
    public ProductUnit()
    {
        ProductServices = new HashSet<Product>();
    }
    public int Id { get; set; }
    public string UnitName { get; set; }

    public ICollection<Product> ProductServices { get; set; }
}
