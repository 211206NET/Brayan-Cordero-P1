namespace UI;
using Models;
using StoreDL;

public class store
{
    
    ManageInventory ManageInventory = new ManageInventory();
    List<Inventory> StoreInventory = new List<Inventory>();

    public void manageStores(List<Storefront> IncomingStores)
    {

        bool goBack = false;

            while(!goBack)
            {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[1] Create new store");
                Console.WriteLine("[2] Manage Inventory");
                Console.WriteLine("[3] Go back");
                string? managerInput = Console.ReadLine();

                switch(managerInput)
                {
                case "1":
                    DBREPO dBREPO = new DBREPO();
                    Storefront newStore = new Storefront();
                    Console.WriteLine("Enter Store Name:");
                    string? newName = Console.ReadLine();
                    newStore.Name= newName;
                    Console.WriteLine("Enter Address:");
                    string? newAddress = Console.ReadLine();
                    newStore.Address= newAddress;
                    Console.WriteLine("Enter City:");
                    string? newCity = Console.ReadLine();
                    newStore.City = newCity;
                    Console.WriteLine("Enter State:");
                    string? newState = Console.ReadLine();
                    newStore.State = newState;
                    dBREPO.AddNewStore(newStore);
                break;

                case "2":
                    DBREPO dbRepoStores = new DBREPO();
                    List<Storefront> allstores = dbRepoStores.AllStores();
                    Console.WriteLine("Select a Store:");
                    Console.WriteLine("*******STORES********");
                    for(int i = 0;i < allstores.Count;i++)
                    {
                        Console.WriteLine($"[{i}] {allstores[i].Name}\n{allstores[i].Address}\n{allstores[i].City}\n{allstores[i].State}");
                        Console.WriteLine("***********************");
                    }
                    int selection = Int32.Parse(Console.ReadLine());
                    ManageInventory.manageInventory(allstores[selection], selection);
                break;

                case "3":
                    goBack = true;
                break;

                default:
                    Console.WriteLine("Invalid input");
                break;
                }
            }
        }
}
