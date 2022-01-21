namespace Models;
using System.ComponentModel.DataAnnotations;


public class Storefront
{
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