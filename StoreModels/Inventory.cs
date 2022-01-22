namespace Models;
using System.Data;

public class Inventory 
{
    public int ID { get; set; }
    public int StoreId { get; set; } 
    public int ProductID { get; set; }
    public int Quantity { get; set; }
    public Product Item { get; set; }

    //public Inventory(DataRow r)
    //{
    //    this.ID = (int)r["ID"];
    //    this.StoreId = (int) r["StoreId"];
    //    this.ProductID = (int) r["ProductID"];
    //    this.Quantity= (int) r["Quantity"];
       
    //}
}

