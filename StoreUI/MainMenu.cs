namespace UI;
using Models;
using StoreDL;

public class MainMenu
{
    public void mainMenuStart()
    {

    store manageStores = new store();
    CustomerMenu customerSignIn = new CustomerMenu();
    ManagerMenu managerPortal = new ManagerMenu();
    DBREPO dbRepo = new DBREPO();
    // List<Customer> customers = dbRepo.AllCustomers();
    // AllCustomers.allCustomers = dbRepo.AllCustomers();
    //insted of list of customer on the top. 
    List<Staff> staff = dbRepo.AllStaff();

    bool exit = false;

    while (!exit)
    {
        
        Console.WriteLine("Welcome to Munchies");
        Console.WriteLine("[1] Sign In \n[2] Create New Account \n[3] exit \n[4] Admin");
        string? UserInput = Console.ReadLine();


        switch (UserInput)
        {
            case "1": 
                List<Customer> customers = dbRepo.AllCustomers();
                
                bool successfullLogin = false;
                    Console.WriteLine("Enter Username");
                    string? CustomerUsername = Console.ReadLine();
                    Console.WriteLine("Enter Password");
                    string? CustomerPassword = Console.ReadLine();
                    
                    foreach(Customer customer in customers)
                    {
                        if(CustomerUsername == customer.UserName && CustomerPassword == customer.Password )
                        {
                            customerSignIn.customerMenu(customer);
                            successfullLogin = true;
                        }
                    }
                    if(!successfullLogin)
                    {
                        Console.WriteLine("Invalid Username or Password");
                        Console.WriteLine("Please try again");
                    }
                
            break;

            case "2":
                Customer newCustomer = new Customer();
                Console.WriteLine("Enter a Username:");
                string? username = Console.ReadLine();
                Console.WriteLine("Enter a Password");
                string? password = Console.ReadLine();
                Console.WriteLine("Enter an Email");
                string? email = Console.ReadLine();
                newCustomer.UserName = username;
                newCustomer.Password = password;
                newCustomer.Email = email;
                dbRepo.AddCustomer(newCustomer);
                
                Console.WriteLine("your account has been created");
                
            break;

            case "3":
                exit =true;
            break;
            
            case "4":
                bool staffLogin = false;
                    Console.WriteLine("Enter Username");
                    string? staffUsername = Console.ReadLine();
                    Console.WriteLine("Enter Password");
                    string? staffPassword = Console.ReadLine();
                    
                    foreach(Staff incomingStaff in staff)
                    {
                        if(staffUsername == incomingStaff.Name && staffPassword == incomingStaff.Password )
                        {
                            managerPortal.managerMenu();
                            successfullLogin = true;
                        }
                    }
                    if(!staffLogin)
                    {
                        Console.WriteLine("Invalid Username or Password");
                        Console.WriteLine("Please try again");
                    }
            break;
            default:
                Console.WriteLine("Invalid input, try again");
            break;
        }

        
    }



    }

}