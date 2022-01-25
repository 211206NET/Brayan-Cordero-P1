using Xunit;
using Models;
using System.Collections.Generic;

namespace Tests;

public class UnitTest1
{
    [Fact]
    public void CreateNewStore()
    {
        
        Storefront testStore = new Storefront();
        
        Assert.NotNull(testStore);
    }

    [Fact]
    public void StoreShouldSetData()
    {
        
        Storefront testStore = new Storefront();
        string name = "Test Name";
        string address ="Test Address";
        string city = "Test City";
        string state = "Test State";

        
        testStore.Name = name;
        testStore.Address = address;
        testStore.City = city;
        testStore.State = state;

        
        Assert.Equal(name,testStore.Name);
        Assert.Equal(address,testStore.Address);
        Assert.Equal(city,testStore.City);
        Assert.Equal(state,testStore.State);

    }

    [Fact]
    public void ProductShouldCreate()
    {

        Product product = new Product();

        Assert.NotNull(product);
    }

    [Fact]
    public void ProductShouldSetDate()
    {
        Product testProduct = new Product();
        int Id = 1;
        string Name = "TestName";
        string Description = "TestDescription";
        decimal price = 1.5M;

        testProduct.ID = Id;
        testProduct.ProductName = Name;
        testProduct.Description = Description; 
        testProduct.Price = price;

        Assert.Equal(Id, testProduct.ID);
        Assert.Equal(Name, testProduct.ProductName);
        Assert.Equal(Description, testProduct.Description);
        Assert.Equal(price, testProduct.Price);

    }

    [Fact]
    public void CustomerShouldCreate()
    {

        Customer customer = new Customer();

        Assert.NotNull(customer);
    }

    [Fact]
    public void CustomerShouldSetDate()
    {
        Customer testCustomer = new Customer();
        int Id = 1;
        string Username = "TestUsername";
        string Password = "TestPassword";
        string Email = "TestEmail";

        testCustomer.Id = Id;
        testCustomer.UserName = Username;
        testCustomer.Password = Password;
        testCustomer.Email = Email;

        Assert.Equal(Id, testCustomer.Id);
        Assert.Equal(Username, testCustomer.UserName);
        Assert.Equal(Password, testCustomer.Password);
        Assert.Equal(Email, testCustomer.Email);

    }

    [Fact]
    public void OrderShouldCreate()
    {

        Order order = new Order();

        Assert.NotNull(order);
    }

    [Fact]

    public void OrderShouldSetData()
    {
        Order testOrder = new Order();
        string OrderDate = "01/26/2022";
        string Customer = "TestCustomer";
        int OrderNumber = 12;
        string StoreName = "TestStore";
        decimal Total = 20.55M;

        testOrder.OrderDate = OrderDate;
        testOrder.Customer = Customer;
        testOrder.OrderNumber = OrderNumber;
        testOrder.StoreName = StoreName;
        testOrder.Total = Total;

        Assert.Equal(Customer, testOrder.Customer);
        Assert.Equal(OrderDate, testOrder.OrderDate);
        Assert.Equal(OrderNumber, testOrder.OrderNumber);
        Assert.Equal(StoreName, testOrder.StoreName);
        Assert.Equal(Total, testOrder.Total);

    }

    [Fact]
    public void StaffShouldCreate()
    {
        Staff staff = new Staff();

        Assert.NotNull(staff);
    }

    [Fact]
    public void StaffShouldSetData()
    {
        Staff testStaff = new Staff();
        int ID = 100;
        string Name = "TestStaff";
        string Password = "TestPassword";
        string Tittle = "TestTittle";
        int StoreID = 101;

        testStaff.ID = ID;
        testStaff.Name = Name;
        testStaff.Password = Password;
        testStaff.Tittle = Tittle;
        testStaff.StoreID = StoreID;

        Assert.Equal(ID, testStaff.ID);
        Assert.Equal(Name, testStaff.Name);
        Assert.Equal(Password, testStaff.Password);
        Assert.Equal(Tittle, testStaff.Tittle);
        Assert.Equal(StoreID, testStaff.StoreID);


    }








}