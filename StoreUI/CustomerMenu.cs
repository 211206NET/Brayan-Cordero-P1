namespace UI;
using Models;
using StoreDL;
public class CustomerMenu
{
    public void customerMenu(Customer incomingCustomer)
    {
        Console.WriteLine($"Welcome: {incomingCustomer.UserName}");
        DBREPO dbRepoStores = new DBREPO();
        
        List<Order> newOrderList= new List<Order>();
        // List<LineItem> cart = new List<LineItem>();
        bool exit = false;
        while(!exit)
        {
        Console.WriteLine("what would you like to do?");
        Console.WriteLine("[1] See all stores");
        Console.WriteLine("[2] Place an Order");
        Console.WriteLine("[3] See order History");
        Console.WriteLine("[4] Logout ");
        string? input = Console.ReadLine();

            switch(input)
            {
                case "1":
                    
                    List<Storefront> allstores = dbRepoStores.AllStores();
                    Console.WriteLine("*********STORES********");
                    foreach(Storefront store in allstores)
                    {
                        Console.WriteLine($"{store.Name}\n{store.Address}\n{store.City}\n{store.State}");
                        Console.WriteLine("********************************");
                    }
                break;

                case "2":
                    List<Storefront> selectStores = dbRepoStores.AllStores();
                    Console.WriteLine("Select a Store:");
                    for(int i = 0;i < selectStores.Count;i++)
                    {
                        Console.WriteLine($"[{i}] {selectStores[i].Name}\n{selectStores[i].Address}\n{selectStores[i].City}\n{selectStores[i].State}");
                    }
                    int selection = Int32.Parse(Console.ReadLine());

                    Console.WriteLine($"You Selected:\n{selectStores[selection].Name}\n******************");
                    CustomerCheckout newChekout = new CustomerCheckout();
                    newChekout.customerCheckout(incomingCustomer,selectStores[selection]);

                break;

                case "3":
                Console.WriteLine("Order History:");
                Console.WriteLine("*******ORDERS*******");
                newOrderList = dbRepoStores.AllOrders(incomingCustomer);
                foreach(Order OrderHistory in newOrderList )
                {
                    Console.WriteLine($"Order Number: {OrderHistory.OrderNumber} Order Date: {OrderHistory.OrderDate}");
                    Console.WriteLine($"Store: {OrderHistory.StoreName} Total: {OrderHistory.Total}");
                    Console.WriteLine("*********************************");
                }
                break;

                case "4":
                    exit = true;
                break;

                default:
                    Console.WriteLine("Invalid input");
                break;
                
            }
        }


        
    }
}