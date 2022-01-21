namespace UI;
using Models;
using StoreDL;

public class ManageInventory
{
    public void manageInventory(Storefront IncomingStore, int selection )
    {

        
        bool goback = false;
        while(!goback)
        {
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("[1] Make a new product");
        Console.WriteLine("[2] Add a product to Inventory");
        Console.WriteLine("[3] See Inventory");
        Console.WriteLine("[4] Go Back");
        string? input = Console.ReadLine();

            switch(input)
            {
                case "1":
                    DBREPO addProduct = new DBREPO();
                    Product newProduct = new Product();
                    Console.WriteLine("Enter Product Name:");
                    string? productName = Console.ReadLine();
                    newProduct.ProductName = productName;
                    Console.WriteLine("Enter Product Description");
                    string? productDescription = Console.ReadLine();
                    newProduct.Description = productDescription;
                    Console.WriteLine("Enter Product Price");
                    decimal productPrice = Decimal.Parse(Console.ReadLine());
                    newProduct.Price= productPrice;
                    addProduct.AddProduct(newProduct);

                break;
                case "2":
                    Console.WriteLine("Select a product to add by ID:");
                    DBREPO dbProducts = new DBREPO();
                    List<Product> allProducts = dbProducts.AllProducts();
                        for (int i = 0; i < allProducts.Count;i++)
                        {
                            Console.WriteLine($"ID: [{allProducts[i].ID}]\nProduct Name: {allProducts[i].ProductName}");
                            Console.WriteLine($"Description: {allProducts[i].Description}");
                            Console.WriteLine($"Price: {allProducts[i].Price}");
                            Console.WriteLine("*******************************");
                        }
                    int selectedProduct = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Quantity: ");
                    int productQuantity = Int32.Parse(Console.ReadLine());
                    Inventory addToInventory = new Inventory ();
                    addToInventory.Quantity= productQuantity;
                    addToInventory.ProductID = selectedProduct;
                    addToInventory.StoreId = IncomingStore.ID;
                    dbProducts.AddToInventory(addToInventory);

                break;

                case "3":
                    DBREPO dbStoreInventory = new DBREPO();
                    List<Inventory> storeInventory= dbStoreInventory.StoreInventory(IncomingStore);
                    foreach (Inventory inventory in storeInventory)
                    {
                        
                        Console.WriteLine($"Item: {inventory.Item.ProductName} Description: {inventory.Item.Description}");
                        Console.WriteLine($"Price: {inventory.Item.Price} Quantity: {inventory.Quantity}");
                        Console.WriteLine("************************");
                        
                    }
                    break;

                case "4":
                    goback = true;
                break;

                default:
                    Console.WriteLine("Invalid Input");
                break;
            }
        }
    }
}
