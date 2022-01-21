
namespace UI;
using StoreDL;
using Models;

public class ManagerMenu
{
    List<Inventory> StoreInventory = new List<Inventory>();
    
    public void managerMenu()
    {
    
    store manageStores = new store();
    bool exit = false;

    while(!exit)
    {
        Console.WriteLine("Hello Brayan");
        Console.WriteLine("What would you like to do?");
        Console.WriteLine("[1] Manage Store info");
        Console.WriteLine("[2] See all Stores");
        Console.WriteLine("[3] See all Customers ");
        Console.WriteLine("[4] Exit");
        string? input = Console.ReadLine();

        switch(input)
        {
            case "1":
            DBREPO dbManagerStore = new DBREPO();
            List<Storefront> manageStore = dbManagerStore.AllStores();
            manageStores.manageStores(manageStore);

            break;

            case "2":
            DBREPO dbRepoStores = new DBREPO();
            List<Storefront> allstores = dbRepoStores.AllStores();
            foreach(Storefront store in allstores)
                {
                    Console.WriteLine($"{store.Name}\n{store.Address}\n{store.City}\n{store.State}");
                    Console.WriteLine("************************************");
                }
            break;

            case "3":
            DBREPO dbRepo = new DBREPO();
            List<Customer> customers = dbRepo.AllCustomers();
            foreach(Customer excistingCustomers in customers)
            {
                Console.WriteLine($"Customer: {excistingCustomers.UserName} Email: {excistingCustomers.Email}");
                Console.WriteLine("***************************");
            }
            break;

            case "4":
            exit = true;
            break;

            default:
            Console.WriteLine("invalid input");
            break;


        }



    }





        


    }
}