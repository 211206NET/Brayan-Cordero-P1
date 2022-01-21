namespace StoreDL; 

public  class StaticStorage 
{
    private static List<Storefront> _allStores = new List<Storefront>();

    public List<Storefront> GetAllStores()
    {
        return StaticStorage._allStores;
    }

    public void AddStore(Storefront StoreToAdd)
    {
        StaticStorage._allStores.Add(StoreToAdd);
    }


    private static List<Customer> _allCustomers = new List<Customer>();

    public List<Customer> GetAllCustomers()
    {
        return StaticStorage._allCustomers;
    }

    public void AddCustomer(Customer CustomerToAdd)
    {
        StaticStorage._allCustomers.Add(CustomerToAdd);
    }


    private static List<Staff> _allStaff = new List<Staff>();

    public List<Staff> GetAllStaff()
    {
        return StaticStorage._allStaff;
    }


    // private static List<Order> _allOrders = new List<Order>();

    // public List<Order> GetAllOrders(Customer incomingCustomer)
    // {
    //     return StaticStorage._allOrders;
    // }

    // public void AddToOrders(Customer incomingCustomer, Storefront selectedStore,Order incomingOrder)
    // {
    //     StaticStorage._allOrders.Add(incomingOrder);
    // }






}




