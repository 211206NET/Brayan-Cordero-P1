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


    





    
}