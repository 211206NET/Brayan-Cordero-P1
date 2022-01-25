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

    public StoreAddressOnly GetStoresAddressById(int storeId)
    {
        return _dl.GetStoresAddressById(storeId);
    }

    public void AddStore(StoreAddressOnly StoreToAdd)
    {
        _dl.AddStore(StoreToAdd);

    }

    public void AddToInventory(AddtoInventory inventoryToAdd)
    {
        _dl.AddToInventory(inventoryToAdd);
    }

    public void AddToCart(Cart addToCart)
    {
        _dl.AddToCart(addToCart);
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

    public List<Inventory> StoreInventory(int storeId)
    {
        return _dl.StoreInventory(storeId);
    }

    public Customer GetCustomerById(int customerId)
    {
        return _dl.GetCustomerById(customerId);
    }

    public List<Order> AllOrders(int CustomerId)
    {
        return _dl.AllOrders(CustomerId);
    }

    public List<StoreOrders> AllStoreOrders(int StoreId)
    {
        return _dl.AllStoreOrders(StoreId);
    }

    public List<Product> AllProducts()
    {
        return _dl.AllProducts();
    }

    public Product GetProductById(int productId)
    {
        return _dl.GetProductById(productId);
    }

    public List<CustomerCart> GetCart()
    {
        return _dl.GetCart();
    }

    public void AddProduct(Product productToAdd)
    {
        _dl.AddProduct(productToAdd);
    }

    public void AddToOrders(decimal Total, int StoreId, int CustomerId, string OrderDate)
    {
        _dl.AddToOrders(Total, StoreId, CustomerId, OrderDate);
    }
    public void DeleteStore(int storeId)
    {
        _dl.DeleteStore(storeId);
    }

    public void DeleteCustomer(int CustomerId)
    {
        _dl.DeleteCustomer(CustomerId);
    }

    public void DeleteProduct(int ProductId)
    {
        _dl.DeleteProduct(ProductId);
    }

    public void ClearCart()
    {
        _dl.ClearCart();
    }

}