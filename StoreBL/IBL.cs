using Models;


namespace BL;

public interface IBL
{

    List<Storefront> GetAllStores();
    List<StoreAddressOnly> GetAllStoresAddress();

    void AddStore(StoreAddressOnly StoreToAdd);

    List<Customer> GetAllCustomers();

    void AddCustomer(Customer CustomerToAdd);

    List<Staff> GetAllStaff();

    Storefront GetStoreById(int storeId);

    List<Inventory> StoreInventory(int storeId);

    Customer GetCustomerById(int customerId);

    List<Order> AllOrders(int StoreId);

    public void DeleteStore(int storeId);

}