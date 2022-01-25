namespace Models;

public class CustomerCart
{
    public int productId { get; set; }
    public string? productName { get; set; }
    public string? productDescription { get; set; }

    public decimal productPrice { get; set; }

    public int quantity { get; set; }



}