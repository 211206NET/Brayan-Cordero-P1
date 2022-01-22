namespace Models;

public class Customer
{
    public int Id { get; set; }
    public string? UserName { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    //public List<Order> Orders { get; set; }

    // public Customer(){}

    // public string printCustomer()
    // {
    //     return $"UserName: {this.UserName} UserID: {this.Id} ";

    // }
}