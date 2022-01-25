using Models;


namespace BL;

public interface IBL
{

    List<Storefront> GetAllStores();
    List<StoreAddressOnly> GetAllStoresAddress();

    StoreAddressOnly GetStoresAddressById(int storeId);

    void AddStore(StoreAddressOnly StoreToAdd);
    void AddToInventory(AddtoInventory inventoryToAdd);

    void AddToCart(Cart addToCart);


    List<Customer> GetAllCustomers();

    void AddCustomer(Customer CustomerToAdd);


    List<Staff> GetAllStaff();


    Storefront GetStoreById(int storeId);

    List<Inventory> StoreInventory(int storeId);

    Customer GetCustomerById(int customerId);


    List<Order> AllOrders(int CustomerId);

    List<StoreOrders> AllStoreOrders(int StoreId);

    List<Product> AllProducts();

    Product GetProductById(int productId);

    List<CustomerCart> GetCart();
    void AddProduct(Product productToAdd);

    void AddToOrders(decimal Total, int StoreId, int CustomerId, string OrderDate);

    public void DeleteStore(int storeId);

    public void DeleteCustomer(int CustomerId);

    public void DeleteProduct(int ProductId);

    public void ClearCart();

}