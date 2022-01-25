namespace Models;

public class Checkout
{
    public List<CustomerCart> cart { get; set; }

    public decimal cartTotal { get; set; }


    public decimal CalculateTotal()
    {
        decimal total = 0;
        if (this.cart?.Count > 0)
        {
            foreach (CustomerCart cart in this.cart)
            {
                // Console.WriteLine(lineitem.Item.Price + "Quantity" + lineitem.Quantity);
                //multiply the product's price by how many we're buying
                total += cart.productPrice * cart.quantity;
            }
        }
        this.cartTotal = total;
        return cartTotal;
    }
}