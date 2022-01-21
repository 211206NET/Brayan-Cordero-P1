namespace Models;

public class Order
{
    //You can also use DateTime data type for this
    public string? OrderDate { get; set; }
    public string? Customer { get; set; }
    public int OrderNumber { get; set; }
    public string? StoreName { get; set; }
    public List<LineItem> LineItems { get; set; }
    public decimal Total { get; set; }
    public decimal CalculateTotal() 
    {
        decimal total = 0;
        if(this.LineItems?.Count > 0)
        {
            foreach(LineItem lineitem in this.LineItems)
            {
                // Console.WriteLine(lineitem.Item.Price + "Quantity" + lineitem.Quantity);
                //multiply the product's price by how many we're buying
                total += lineitem.Item.Price * lineitem.Quantity;
            }
        }
        this.Total = total;
        return Total;
    }

    // public Order(Storefront store){
    //     this.StoreId = store.StoreID;
    // }

    // Storefront namestore = new Storefront();
    // Order newOrder = new Order(namestore);
}