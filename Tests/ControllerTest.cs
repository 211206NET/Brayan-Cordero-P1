using Xunit;
using Moq;
using StoreWebApp.Controllers;
using BL;
using Models;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;


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
        //Assert.IsType<List<Inventory>>(result);
        //    Assert.Equal(2, result.Count);
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
        //IMemoryCache cache = new MemoryCache(new MemoryCacheOptions());

        var storeController = new StoreController(mockBL.Object);

        var result = storeController.Get();
          
        Assert.IsType<List<StoreAddressOnly>>(result);
        Assert.Equal(2, result.Count);
        Assert.Contains(testOne, result);
    }

}