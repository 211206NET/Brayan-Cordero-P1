namespace Models;
using System.ComponentModel.DataAnnotations;
using System.Data;


public class Storefront
{
    public Storefront()
    { }
    public Storefront(DataRow row)
    {
        this.ID = (int)row["ID"];
        this.Name = row["Name"].ToString() ?? "";
        this.Address = row["Address"].ToString() ?? "";
        this.City = row["City"].ToString() ?? "";
        this.State = row["State"].ToString() ?? "";
    }
    public int ID { get; set; }
    [Required]
    [RegularExpression("^[a-zA-Z0-9 #']+$", ErrorMessage ="Storefront name can only have alphanumeric characters, white space, #, and ' ")]
    public string? Name { get; set; }
    public string? Address { get; set; }
    public string? State {get; set; }
    public string? City {get; set; }
    public List<Inventory> Inventories { get; set; }
    public List<Order> Orders { get; set; }

 




}