namespace Models;

public class StoreOrders
{
    public string? OrderDate { get; set; }
    public int CustomerID { get; set; }
    public int OrderNumber { get; set; }
    public int StoreID { get; set; }
    public List<LineItem> LineItems { get; set; }
    public decimal Total { get; set; }
    public decimal CalculateTotal()
    {
        decimal total = 0;
        if (this.LineItems?.Count > 0)
        {
            foreach (LineItem lineitem in this.LineItems)
            {
                // Console.WriteLine(lineitem.Item.Price + "Quantity" + lineitem.Quantity);
                //multiply the product's price by how many we're buying
                total += lineitem.Item.Price * lineitem.Quantity;
            }
        }
        this.Total = total;
        return Total;
    }
}