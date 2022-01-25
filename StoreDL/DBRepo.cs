namespace StoreDL;

using Microsoft.Data.SqlClient;
using System.Data;
public class DBREPO : IRepo 
{
    private string _connectionString;

    public DBREPO(String connectionString)
    {
        _connectionString = connectionString;
    }

    //List of customers
    public List<Customer> GetAllCustomers()
    {
        List<Customer> allCustomers = new List<Customer>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string queryTxt = "SELECT*FROM Customer";
            
            using(SqlCommand cmd = new SqlCommand(queryTxt, connection))
            {
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        Customer custo = new Customer();
                        custo.Id = reader.GetInt32(0);
                        custo.UserName = reader.GetString(1);
                        custo.Password = reader.GetString(2);
                        custo.Email = reader.GetString(3);
                        allCustomers.Add(custo);
                    }
                }
            } 
            connection.Close();
            
        }
        return allCustomers;
    }

    //List of Staff
        public List<Staff>  GetAllStaff()
    {
        List<Staff> allStaff = new List<Staff>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string queryTxt = "SELECT*FROM Staff";
            
            using(SqlCommand cmd = new SqlCommand(queryTxt, connection))
            {
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        Staff staff = new Staff();
                        staff.ID = reader.GetInt32(0);
                        staff.Name = reader.GetString(1);
                        staff.Password = reader.GetString(2);
                        staff.Tittle = reader.GetString(3);
                        allStaff.Add(staff);
                    }
                }
            } 
            connection.Close();
        }
        return allStaff;
    }

    //List of Storefronts
    public List<Storefront> GetAllStores()
    {
        List<Storefront> allStores = new List<Storefront>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string queryTxt = "SELECT*FROM StoreFront";

            using (SqlCommand cmd = new SqlCommand(queryTxt, connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Storefront store = new Storefront();
                        store.ID = reader.GetInt32(0);
                        store.Name = reader.GetString(1);
                        store.Address = reader.GetString(2);
                        store.City = reader.GetString(3);
                        store.State = reader.GetString(4);
                        allStores.Add(store);
                    }
                }
            }
            connection.Close();
        }
        return allStores;
    }

    //Get all stores address only
    public List<StoreAddressOnly> GetAllStoresAddress()
    {
        List<StoreAddressOnly> allStores = new List<StoreAddressOnly>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string queryTxt = "SELECT*FROM StoreFront";

            using (SqlCommand cmd = new SqlCommand(queryTxt, connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        StoreAddressOnly store = new StoreAddressOnly();
                        store.ID = reader.GetInt32(0);
                        store.Name = reader.GetString(1);
                        store.Address = reader.GetString(2);
                        store.City = reader.GetString(3);
                        store.State = reader.GetString(4);
                        allStores.Add(store);
                    }
                }
            }
            connection.Close();
        }
        return allStores;
    }

    //List of cutomer orders by customer ID
    public List<Order> AllOrders(int CustomerID)
    {
        List<Order> allOrders = new List<Order>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string queryTxt = $"SELECT Orders.ID, Orders.OrderDate, Storefront.Name, Customer.Username, Orders.TOTAL FROM Orders INNER JOIN Customer ON Orders.Customer_ID = Customer.ID INNER JOIN Storefront ON Orders.StoreFront_ID = Storefront.ID WHERE Customer_ID='{CustomerID}'";
            
            using(SqlCommand cmd = new SqlCommand(queryTxt, connection))
            {
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        Order order = new Order();
                        order.OrderNumber= reader.GetInt32(0);
                        order.OrderDate= reader.GetString(1);
                        order.StoreName= reader.GetString(2);
                        order.Customer = reader.GetString(3);
                        order.Total = reader.GetDecimal(4);
                        allOrders.Add(order);
                    }
                }
            } 
            connection.Close();
        }
        return allOrders;
    }

    //All StoreOrders by storeID
    public List<StoreOrders> AllStoreOrders(int StoreId)
    {
        List<StoreOrders> allOrders = new List<StoreOrders>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string queryTxt = $"SELECT*FROM Orders WHERE StoreFront_ID = {StoreId}";

            using (SqlCommand cmd = new SqlCommand(queryTxt, connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        StoreOrders order = new StoreOrders();
                        order.OrderNumber = reader.GetInt32(0);
                        order.OrderDate = reader.GetString(1);
                        order.StoreID = reader.GetInt32(2);
                        order.CustomerID = reader.GetInt32(3);
                        order.Total = reader.GetDecimal(4);
                        allOrders.Add(order);
                    }
                }
            }
            connection.Close();
        }
        return allOrders;
    }

    //Inventory for stores
    public List<Inventory> StoreInventory(int storeId)
    {
        //Storefront incomingStore = IncomingStore;
        List<Inventory> storeInventory = new List<Inventory>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string queryTxt = $"SELECT Inventory.ID, Inventory.Quantity, Inventory.ID,Product.Name,Product.Description, Product.Price, StoreFront_ID FROM Inventory INNER JOIN Product ON Inventory.ProductID = Product.ID WHERE StoreFront_ID='{storeId}'";
            
            
            using(SqlCommand cmd = new SqlCommand(queryTxt, connection))
            {
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        Inventory inventory = new Inventory();
                        Product storeProduct = new Product();
                        inventory.ID = reader.GetInt32(0);
                        inventory.Quantity = reader.GetInt32(1);
                        inventory.StoreId = reader.GetInt32(6);
                        storeProduct.ProductName = reader.GetString(3);
                        storeProduct.Description = reader.GetString(4);
                        storeProduct.Price = reader.GetDecimal(5);
                        inventory.Item = storeProduct;
                        storeProduct.ID=reader.GetInt32(2);
                        inventory.ProductID = storeProduct.ID;
                        storeInventory.Add(inventory);
                    }
                }
            } 
            connection.Close();
        }
        return storeInventory;
    }

    //List of all products
    public List<Product> AllProducts()
    {
        List<Product> allProduct = new List<Product>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string queryTxt = "SELECT*FROM Product";
            
            using(SqlCommand cmd = new SqlCommand(queryTxt, connection))
            {
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        Product product = new Product();
                        product.ID = reader.GetInt32(0);
                        product.ProductName = reader.GetString(1);
                        product.Description= reader.GetString(2);
                        product.Price = reader.GetDecimal(3);
                        allProduct.Add(product);
                    }
                }
            } 
            connection.Close();
        }
        return allProduct;
    }

    
    //add new customers
    public void AddCustomer(Customer customerToAdd)
    {
        DataSet customerSet = new DataSet();
        string selectCmd = "SELECT*FROM Customer";
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            using(SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd, connection))
            {
                
                dataAdapter.Fill(customerSet, "Customer");

                DataTable customerTable = customerSet.Tables["Customer"];
                DataRow newRow = customerTable.NewRow();
                    newRow["Username"]= customerToAdd.UserName;
                    newRow["Password"]= customerToAdd.Password;
                    newRow["Email"]= customerToAdd.Email;
                customerTable.Rows.Add(newRow);
                
                string insertCmd = $"INSERT INTO Customer (Username, Password, Email) VALUES ('{customerToAdd.UserName}','{customerToAdd.Password}','{customerToAdd.Email}')";
                
                dataAdapter.InsertCommand= new SqlCommand(insertCmd, connection);
                
                dataAdapter.Update(customerTable);
                Log.Information("new user added to database {username}", customerToAdd.UserName);
            }
        }
    }

    // Add new products to storefront
    public void AddProduct(Product productToAdd)
    {
        DataSet customerSet = new DataSet();
        string selectCmd = "SELECT*FROM Product";
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            using(SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd, connection))
            {
                
                dataAdapter.Fill(customerSet, "Product");

                DataTable customerTable = customerSet.Tables["Product"];
                DataRow newRow = customerTable.NewRow();
                    newRow["Name"]= productToAdd.ProductName;
                    newRow["Description"]= productToAdd.Description;
                    newRow["Price"]= productToAdd.Price;
                customerTable.Rows.Add(newRow);
                
                string insertCmd = $"INSERT INTO Product (Name, Description, Price) VALUES ('{productToAdd.ProductName}','{productToAdd.Description}','{productToAdd.Price}')";
                
                dataAdapter.InsertCommand= new SqlCommand(insertCmd, connection);
                
                dataAdapter.Update(customerTable);
                Log.Information("new product added to database {ProductID} {ProductName} {ProductPrice}", productToAdd.ID, productToAdd.ProductName, productToAdd.Price);
            }
        }
    }

    //Add to inventory
    public void AddToInventory(AddtoInventory productToAddToInventory)
    {
        DataSet customerSet = new DataSet();
        string selectCmd = "SELECT*FROM Inventory";
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            using(SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd, connection))
            {
                
                dataAdapter.Fill(customerSet, "Inventory");

                DataTable customerTable = customerSet.Tables["Inventory"];
                DataRow newRow = customerTable.NewRow();
                    newRow["Quantity"]= productToAddToInventory.Quantity;
                    newRow["ProductID"]= productToAddToInventory.ProductID;
                    newRow["StoreFront_ID"]=productToAddToInventory.StoreId;
                customerTable.Rows.Add(newRow);
                
                string insertCmd = $"INSERT INTO Inventory (Quantity, ProductID, StoreFront_ID) VALUES ('{productToAddToInventory.Quantity}','{productToAddToInventory.ProductID}','{productToAddToInventory.StoreId}')";
                
                dataAdapter.InsertCommand= new SqlCommand(insertCmd, connection);
                
                dataAdapter.Update(customerTable);
                Log.Information("new product added to store inventory {ProductID}{Quantity}{StoreFront}", productToAddToInventory.ProductID, productToAddToInventory.Quantity, productToAddToInventory.StoreId);
            }
        }
    }

    //add new order
    public void AddToOrders(decimal Total, int StoreId, int CustomerId, string OrderDate)
    {
        DataSet orderSet = new DataSet();
        string selectCmd = "SELECT*FROM Orders";
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            using(SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd, connection))
            {
                
                dataAdapter.Fill(orderSet, "Orders");

                DataTable orderTable = orderSet.Tables["Orders"];
                DataRow newRow = orderTable.NewRow();
                    newRow["OrderDate"]= OrderDate;
                    newRow["StoreFront_ID"]= StoreId;
                    newRow["Customer_ID"]=CustomerId;
                    newRow["TOTAL"] = Total;
                orderTable.Rows.Add(newRow);
                
                string insertCmd = $"INSERT INTO Orders (OrderDate, StoreFront_ID, Customer_ID, TOTAL) VALUES ('{OrderDate}', '{StoreId}', '{CustomerId}', '{Total}')";
                
                dataAdapter.InsertCommand= new SqlCommand(insertCmd, connection);
                
                dataAdapter.Update(orderTable);
                Log.Information("new order from User {OrderDate}{Customer_ID}{StoreFront_ID}{TOTAL}", OrderDate, CustomerId, StoreId, Total);
            }
        }
    }

    //Add new Store to DB
        public void AddStore(StoreAddressOnly newStore)
    {
        DataSet customerSet = new DataSet();
        string selectCmd = "SELECT*FROM StoreFront";
        using(SqlConnection connection = new SqlConnection(_connectionString))
        {
            using(SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd, connection))
            {
                
                dataAdapter.Fill(customerSet, "StoreFront");

                DataTable customerTable = customerSet.Tables["StoreFront"];
                DataRow newRow = customerTable.NewRow();
                    newRow["Name"]= newStore.Name;
                    newRow["Address"]= newStore.Address;
                    newRow["City"]= newStore.City;
                    newRow["State"] = newStore.State;
                customerTable.Rows.Add(newRow);
                
                string insertCmd = $"INSERT INTO StoreFront (Name, Address, City, State) VALUES ('{newStore.Name}','{newStore.Address}','{newStore.City}', '{newStore.State}')";
                
                dataAdapter.InsertCommand= new SqlCommand(insertCmd, connection);
                
                dataAdapter.Update(customerTable);
                Log.Information("new storefront created {Name}{Address}{City}{State}", newStore.Name, newStore.Address, newStore.City, newStore.State);
            }
        }
    }

    // Add Products to Cart 
    public void AddToCart(Cart addToCart)
    {
        DataSet CartSet = new DataSet();
        string selectCmd = "SELECT*FROM Cart";
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            using (SqlDataAdapter dataAdapter = new SqlDataAdapter(selectCmd, connection))
            {

                dataAdapter.Fill(CartSet, "Cart");

                DataTable cartTable = CartSet.Tables["Cart"];
                DataRow newRow = cartTable.NewRow();
                newRow["Product_ID"] = addToCart.productId;
                newRow["Quantity"] = addToCart.Quantity;
               
                cartTable.Rows.Add(newRow);

                string insertCmd = $"INSERT INTO Cart (Product_ID, QUANTITY) VALUES ('{addToCart.productId}', '{addToCart.Quantity}')";

                dataAdapter.InsertCommand = new SqlCommand(insertCmd, connection);

                dataAdapter.Update(cartTable);
                
            }
        }
    }

    //Get Customer Cart
    public List<CustomerCart> GetCart()
    {
        List<CustomerCart> allProduct = new List<CustomerCart>();
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            connection.Open();
            string queryTxt = "SELECT Product.ID, Product.Name, Product.Description, Product.Price, Cart.QUANTITY FROM Cart INNER JOIN Product ON Cart.Product_ID = Product.ID";

            using (SqlCommand cmd = new SqlCommand(queryTxt, connection))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CustomerCart cart = new CustomerCart();
                        cart.productId = reader.GetInt32(0);
                        cart.productName = reader.GetString(1);
                        cart.productDescription = reader.GetString(2);
                        cart.productPrice = reader.GetDecimal(3);
                        cart.quantity = reader.GetInt32(4);
                        allProduct.Add(cart);
                    }
                }
            }
            connection.Close();
        }
        return allProduct;
    }



    //Get Store info by Id
    public Storefront GetStoreById(int storeId)
    {
        
        string query = "SELECT * FROM StoreFront WHERE ID = @StoreId ";
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        using SqlCommand cmd = new SqlCommand(query, connection);
        SqlParameter param = new SqlParameter("@StoreId", storeId);
        cmd.Parameters.Add(param);

        using SqlDataReader reader = cmd.ExecuteReader();
        Storefront store = new Storefront();
        if (reader.Read())
        {
            store.ID = reader.GetInt32(0);
            store.Name = reader.GetString(1);
            store.Address = reader.GetString(2);
            store.City = reader.GetString(3);
            store.State = reader.GetString(4);
        }
        connection.Close();
        return store;
    }
    //Get Customer info by Id
    public Customer GetCustomerById(int customerId)
    {

        string query = "SELECT * FROM Customer WHERE ID = @customerId ";
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        using SqlCommand cmd = new SqlCommand(query, connection);
        SqlParameter param = new SqlParameter("@customerID", customerId);
        cmd.Parameters.Add(param);

        using SqlDataReader reader = cmd.ExecuteReader();
        Customer customer = new Customer();
        if (reader.Read())
        {
            customer.Id= reader.GetInt32(0);
            customer.UserName = reader.GetString(1);
            customer.Password = reader.GetString(2);
            customer.Email = reader.GetString(3);
           
        }
        connection.Close();
        return customer;
    }

    //Get Product info by Id
    public Product GetProductById(int productId)
    {

        string query = "SELECT * FROM Product WHERE ID = @productId ";
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        using SqlCommand cmd = new SqlCommand(query, connection);
        SqlParameter param = new SqlParameter("@productId", productId);
        cmd.Parameters.Add(param);

        using SqlDataReader reader = cmd.ExecuteReader();
        Product product = new Product();
        if (reader.Read())
        {
            product.ID = reader.GetInt32(0);
            product.ProductName = reader.GetString(1);
            product.Description = reader.GetString(2);
            product.Price = reader.GetDecimal(3);

        }
        connection.Close();
        return product;
    }
    //DeleteStore form DB using StoreId
    public void DeleteStore(int storeId)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        //Deletes storefront and inventory of selected storefront from DB
       
        string sqlDelStore = $"DELETE FROM StoreFront WHERE ID = {storeId}";
        string sqlDelInventory = $"DELETE FROM Inventory WHERE StoreFront_ID = {storeId}";
        string sqlDelFromOrders = $"DELETE FROM Orders WHERE StoreFront_ID = {storeId}";
         
        using SqlCommand cmdDelStore = new SqlCommand(sqlDelStore, connection);
        using SqlCommand cmdDelInventory = new SqlCommand(sqlDelInventory, connection);
        using SqlCommand cmdDelFromOrders = new SqlCommand(sqlDelFromOrders, connection);

        cmdDelInventory.ExecuteNonQuery();
        cmdDelFromOrders.ExecuteNonQuery();
        cmdDelStore.ExecuteNonQuery();
        connection.Close();

        Log.Information("Store Deleted {storeId}", storeId);


    }
    //DeleteCustomer form DB using CustomerId
    public void DeleteCustomer(int CustomerId)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        
        string sqlDelCustomer = $"DELETE FROM Customer WHERE ID = {CustomerId}";
        string sqlDelCustomerOrder = $"DELETE FROM Orders WHERE Customer_ID = {CustomerId}";
       
        using SqlCommand cmdDelCustomer = new SqlCommand(sqlDelCustomer, connection);
        using SqlCommand cmdDelCustomerOrder = new SqlCommand(sqlDelCustomerOrder, connection);

        cmdDelCustomerOrder.ExecuteNonQuery();
        cmdDelCustomer.ExecuteNonQuery();
        connection.Close();
        Log.Information("Customer Deleted {CustomerId}", CustomerId);
    }

    //DeleteProduct from DB using ProductID
    public void DeleteProduct(int ProductId)
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        string sqlDelProduct = $"DELETE FROM Product WHERE ID = {ProductId}";
        string sqLDelFromInventory = $"DELETE FROM Inventory WHERE ProductID ={ProductId}";

        using SqlCommand cmdDelProduct = new SqlCommand(sqlDelProduct, connection);
        using SqlCommand cmdDelFromInventory = new SqlCommand(sqLDelFromInventory, connection);

        cmdDelFromInventory.ExecuteNonQuery();
        cmdDelProduct.ExecuteNonQuery();
        connection.Close();
        Log.Information("Product Deleted {ProductID}", ProductId);
    }

    //Clear Cart after checkout
    public void ClearCart()
    {
        using SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();

        string sqlClearCart = $"DELETE FROM Cart";
        using SqlCommand cmdClearCart = new SqlCommand( sqlClearCart, connection);
        
        cmdClearCart.ExecuteNonQuery();
        connection.Close ();
    }



}
