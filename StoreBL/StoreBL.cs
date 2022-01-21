using Models;
using StoreDL;
namespace BL;


public class StoreBL : IBL
{

    private IRepo _dl;

    public StoreBL(IRepo repo)
    {
        _dl = repo;
    }

    public List<Storefront> GetAllStores()
    {
        return _dl.GetAllStores();
    }

    public List<StoreAddressOnly> GetAllStoresAddress()
    {
        return _dl.GetAllStoresAddress();
    }

    public void AddStore(Storefront StoreToAdd)
    {
        _dl.AddStore(StoreToAdd);
    }

    public List<Customer> GetAllCustomers()
    {
        return _dl.GetAllCustomers();
    }

    public void AddCustomer(Customer CustomerToAdd)
    {
        _dl.AddCustomer(CustomerToAdd);
    }

    public List<Staff> GetAllStaff()
    {
        return _dl.GetAllStaff();
    }

    public Storefront GetStoreById(int storeId)
    {
        return _dl.GetStoreById(storeId);
    }
}