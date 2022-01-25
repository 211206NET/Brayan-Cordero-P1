using Xunit;
using Moq;
using StoreWebApp.Controllers;
using BL;
using Models;
using System.Collections.Generic;
using StoreDL;
using System;
using Microsoft.AspNetCore.Mvc;





namespace Test;

public class ControllerTest
{

    [Fact] 
    public void StoreControllerGetAllInventoryOfStoreById()
    {
        var MockBl = new Mock<IBL>();
        int i = 1;
        MockBl.Setup(x => x.StoreInventory(i)).Returns(
            new List<Inventory>
            {
                new Inventory
                {
                 ID=1,
                 StoreId =1,
                 ProductID =2,
                 Quantity =10,
                 },
                new Inventory
                {
                 ID=2,
                 StoreId =3,
                 ProductID =4,
                 Quantity =14,
                 }
            }
            );
        var storeController = new StoreController(MockBl.Object);

        var result= storeController.Get(i);


        Assert.NotNull(result);
        Assert.IsType<ActionResult<List<Inventory>>>(result);
        
    }

    [Fact]
    public void StoreControllerGetsAllStores()
    {
        var mockBL = new Mock<IBL>();
        var testOne =new StoreAddressOnly
            {
            ID = 1,
            Address = "Test Ave",
            City = "TestCity",
            State = "TestState"
             };
        var testTwo = new StoreAddressOnly
             {
            ID = 2,
            Address = "Test2 Ave",
            City = "TestCity 2",
            State = "TestState 2"
             };

        mockBL.Setup(x => x.GetAllStoresAddress()).Returns(
            new List<StoreAddressOnly>
            {
               testOne,
               testTwo,
            });
        

        var storeController = new StoreController(mockBL.Object);

        var result = storeController.Get();
          
        Assert.IsType<List<StoreAddressOnly>>(result);
        Assert.Equal(2, result.Count);
        Assert.Contains(testOne, result);
        Assert.Contains(testTwo, result);
    }

    [Fact]
    public void StoreControllerShouldGetStoreById()
    {
        var MockBl = new Mock<IBL>();
        int i = 1;
        MockBl.Setup(x => x.GetStoresAddressById(i)).Returns(

                new StoreAddressOnly
                {
                    ID = 1,
                    Address = "TestAddress",
                    City = "TestCity",
                    Name = "TestName",
                    State = "TestState"
                    
                    
                }

            );
        var productController = new StoreController(MockBl.Object);

        var result = productController.GetStoreById(i);


        Assert.NotNull(result);
        Assert.IsType<ActionResult<StoreAddressOnly>>(result);

    }

    [Fact]
    public void StoreControllerGetStoreOrdersById()
    {
        var MockBl = new Mock<IBL>();
        int i = 1;
        MockBl.Setup(x => x.AllStoreOrders(i)).Returns(
            new List<StoreOrders>
            {
                new StoreOrders
                {
                 OrderDate = "01/26/2022",
                 CustomerID = 1,
                 OrderNumber = 2,
                 StoreID = 5,
                 Total = 12.75M
                 },
                new StoreOrders
                {
                 OrderDate = "01/25/2022",
                 CustomerID = 3,
                 OrderNumber = 4,
                 StoreID = 3,
                 Total = 25.75M
                 }
            }
            );
        var storeController = new StoreController(MockBl.Object);

        var result = storeController.GetOrders(i);


        Assert.NotNull(result);
        Assert.IsType<ActionResult<List<StoreOrders>>>(result);

    }

    [Fact]
    public void ProductControllerShouldGetAllProductsById()
    {
        var MockBl = new Mock<IBL>();
        int i = 1;
        MockBl.Setup(x => x.GetProductById(i)).Returns(
           
                new Product
                {
                 ID=1,
                 ProductName = "TestName",
                 Description = "TestDescription",
                 Price = 2.25M
                 }
            
            );
        var productController = new ProductController(MockBl.Object);

        var result = productController.Get(i);


        Assert.NotNull(result);
        Assert.IsType<ActionResult<Product>>(result);

    }

    [Fact]
    public void ProductControllerShouldGetAllProducts()
    {
        var mockBL = new Mock<IBL>();
        var testOne = new Product
        {
            ID = 1,
            ProductName = "TestName",
            Description = "TestDescription",
            Price = 2.25M

        };
        var testTwo = new Product
        {
            ID = 2,
            ProductName = "Test2Name",
            Description = "Test2Description",
            Price = 5.25M
        };

        mockBL.Setup(x => x.AllProducts()).Returns(
            new List<Product>
            {
               testOne,
               testTwo,
            });


        var storeController = new ProductController(mockBL.Object);

        var result = storeController.Get();

        Assert.IsType<List<Product>>(result);
        Assert.Equal(2, result.Count);
        Assert.Contains(testOne, result);
        Assert.Contains(testTwo, result);
    }

    [Fact]
    public void CustomerControllerShouldGetAllCustomers()
    {
        var mockBL = new Mock<IBL>();
        var testOne = new Customer
        {
            Id = 1,
            UserName = "TestUsername",
            Password ="TestPassword",
            Email = "TestEmail"

        };
        var testTwo = new Customer
        {
            Id = 2,
            UserName = "Test2Username",
            Password = "Test2Password",
            Email = "TesteEmail"
            
        };

        mockBL.Setup(x => x.GetAllCustomers()).Returns(
            new List<Customer>
            {
               testOne,
               testTwo,
            });


        var storeController = new CustomerController(mockBL.Object);

        var result = storeController.Get();

        Assert.IsType<List<Customer>>(result);
        Assert.Equal(2, result.Count);
        Assert.Contains(testOne, result);
        Assert.Contains(testTwo, result);
    }

    [Fact]
    public void CustomerControllerShouldGetCustomerById()
    {
        var MockBl = new Mock<IBL>();
        int i = 1;
        MockBl.Setup(x => x.GetCustomerById(i)).Returns(

                new Customer
                {
                    Id = 1,
                    UserName = "TestUsername",
                    Password = "TestPassword",
                    Email = "TestEmail"
                }

            );
        var productController = new CustomerController(MockBl.Object);

        var result = productController.Get(i);


        Assert.NotNull(result);
        Assert.IsType<ActionResult<Customer>>(result);

    }

    [Fact]
    public void CustomerControllerShouldGetCustomerOrderHistory()
    {
        var MockBl = new Mock<IBL>();
        int i = 1;
        MockBl.Setup(x => x.AllOrders(i)).Returns(
                       new List<Order>
            {
                new Order
                {
                 OrderDate = "01/26/2022",
                 Customer = "TestCustomer",
                 OrderNumber = 1,
                 StoreName = "TestStore",
                 Total = 20.5M
                 },
                new Order
                {
                 OrderDate = "01/25/2022",
                Customer = "Test2Customer",
                 OrderNumber = 2,
                 StoreName = "Test2Store",
                 Total = 20.5M
                 }
            }
            );
        var storeController = new CustomerController(MockBl.Object);

        var result = storeController.GetOrders(i);


        Assert.NotNull(result);
        Assert.IsType<ActionResult<List<Order>>>(result);



    }

    [Fact]
    public void CustomerControllerShouldGetCustomerCart()
    {
        var MockBl = new Mock<IBL>();
        
        MockBl.Setup(x => x.GetCart()).Returns(
                       new List<CustomerCart>
            {
                new CustomerCart
                {
                 productId = 1,
                 productName = "TestName",
                 productDescription = "TestDescription",
                 productPrice = 2.75M,
                 quantity = 10,
                 },
                new CustomerCart
                {
                 productId = 3,
                 productName = "Test2Name",
                 productDescription = "Test2Description",
                 productPrice = 5.75M,
                 quantity = 3,
                 }
            }
            );
        var storeController = new CustomerController(MockBl.Object);

        var result = storeController.GetCart();


        Assert.NotNull(result);
        Assert.IsType<ActionResult<List<CustomerCart>>>(result);



    }



}