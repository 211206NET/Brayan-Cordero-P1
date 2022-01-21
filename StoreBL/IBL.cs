using Models;


namespace BL;

public interface IBL
{

    List<Storefront> GetAllStores();
    List<StoreAddressOnly> GetAllStoresAddress();

    void AddStore(Storefront StoreToAdd);

    List<Customer> GetAllCustomers();

    void AddCustomer(Customer CustomerToAdd);

    List<Staff> GetAllStaff();

    Storefront GetStoreById(int storeId);

}