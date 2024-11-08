using ConsoleApp24.Entities;
using HW11.Services;
using System.ComponentModel.DataAnnotations;

var proservice = new ProductService();
var customerservice = new CustomerService();
bool isfinished = false;
do
{
    Console.Clear();
    Console.WriteLine("*****Welcome To The store*****");
    Console.WriteLine("1.Login");
    Console.WriteLine("2.Sign up");
    Console.WriteLine("3.Logout");
    Console.WriteLine("******************************");
    int choice=0;
    try
    {
         choice = Int32.Parse(Console.ReadLine());
    }
    catch(FormatException)
    {
        Console.Clear();
        Console.WriteLine("Invalid format entered.Try again.");
        Console.WriteLine("Press any key...");
        Console.ReadKey();
    }
    switch(choice)
    {
        case 1:
            Console.Clear();
            Login();
            Console.ReadKey();
            break;
        case 2:
            Console.Clear();
            Register(); 
            Console.ReadKey();  
            break;
        case 3:
            Console.Clear();
            isfinished = true;
            break;
    }
}while(!isfinished);
void Login()
{
    Console.Write("Please enter your name: ");
    var name = Console.ReadLine();
    var res = customerservice.Login(name);
    Console.WriteLine(res._messege);
    if(res._isDone==true)
    { CustomerMenu(); }
    Console.WriteLine("Press any key...");
}
void Register()
{
    Console.Write("Please enter your name: ");
    var name = Console.ReadLine();
    var res = customerservice.Register(name);
    Console.WriteLine(res._messege);
    if(res._isDone==true)
    {
        Console.WriteLine("1.Advance to menu     2.Peace out");
        int res1 = 0;
        try
        { res1 = Int32.Parse(Console.ReadLine()); }
        catch (FormatException)
        {
            Console.Clear();
            Console.WriteLine("Invalid format entered.Try again.");
            Console.WriteLine("Press any key...");
        }
        if(res1 == 1)
        {
            CustomerMenu();
        }
    }
    else
    {
        Console.WriteLine("Press any key...");
    }
}
void CustomerMenu()
{
    bool isfinished = false;
    do
    {
        Console.Clear();
        Console.WriteLine("*****Welcome to the shop*****");
        Console.WriteLine("1.Add a new product.");
        Console.WriteLine("2.Products List.");
        Console.WriteLine("3.Search product.");
        Console.WriteLine("4.Edit product.");
        Console.WriteLine("5.Remove product.");
        Console.WriteLine("6.Logout.");
        int choice = 0;
        try
        { choice = Int32.Parse(Console.ReadLine()); }
        catch (FormatException)
        {
            Console.Clear();
            Console.WriteLine("Invalid format entered.Try again.");
            Console.WriteLine("Press any key...");
        }
        switch (choice)
        {
            case 1:
                Console.Clear();
                Console.Write("Enter Product name: ");
                string name = Console.ReadLine();
                Console.Write("Choose product category:");
                Console.WriteLine("Categoriese: ");
                int i = 0;
                var cats = proservice.GetAllCategories();
                cats.ForEach(c => Console.WriteLine(c.id + "." + c.name));
                int option = int.Parse(Console.ReadLine());
                var cat = cats.FirstOrDefault(c => c.id == option);
                string catname = cat.name;
                Console.Write("Enter product price: ");
                int price = int.Parse(Console.ReadLine());
                var result = proservice.CreatPro(name, catname, price);
                Console.WriteLine(result._messege);
                break;
            case 2:
                Console.Clear();
                Console.WriteLine("*****List Of Products*****");
                proservice.GetAllPro().ForEach(p => Console.WriteLine($"{p.id}. {p.ToString()}"));
                Console.WriteLine("**************************");
                break;
            case 3:
                Console.Clear();
                Console.Write("Enter the product id: ");
                int option1 = int.Parse(Console.ReadLine());
                try
                {
                    Console.WriteLine(proservice.GetProductById(option1).ToString());
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("NO Product found! Try again.");
                }
                break;
            case 4:
                Console.Clear();
                Console.WriteLine("*****List Of Products*****");
                proservice.GetAllPro().ForEach(p => Console.WriteLine($"{p.id}. {p.ToString()}"));
                Console.WriteLine("**************************");
                Console.Write("Enter the product id: ");
                int option2 = int.Parse(Console.ReadLine());
                Product product = new Product(); 
                try
                { product = proservice.GetProductById(option2); }
                catch (NullReferenceException)
                { 
                    Console.WriteLine("NO Product found! Try again.");
                    break;
                }
                    Console.WriteLine("Wich one do you want yo change?  1-Name  2-Category  3-Price  ");
                    int option3 = int.Parse(Console.ReadLine());
                switch (option3)
                {
                    case 1:
                        Console.Write("Enter The new name: ");
                        string proname = Console.ReadLine();
                        product.name = proname;
                        break;
                    case 2:
                        Console.Write("Enter The new CategoryId: ");
                        int newcatid = int.Parse(Console.ReadLine());
                        var Categories = proservice.GetAllCategories();
                        var newcat = Categories.First(c => c.id == newcatid);
                        product.category = newcat.name;
                        break;
                    case 3:
                        Console.Write("Enter The new price: ");
                        int newprice = int.Parse(Console.ReadLine());
                        product.price = newprice;
                        break;
                    default:
                        Console.WriteLine("Invalid Expression");
                        break;
                }
                if(option3<4)
                Console.WriteLine(proservice.EditPro(product)._messege);
                break;
            case 5:      
                Console.Clear();
                Console.WriteLine("*****List Of Products*****");
                proservice.GetAllPro().ForEach(p => Console.WriteLine($"{p.id}. {p.ToString()}"));
                Console.WriteLine("**************************");
                Console.Write("Enter the product id: ");
                int option4 = int.Parse(Console.ReadLine());
                Console.WriteLine(proservice.DeletePro(option4)._messege);
                break;
            case 6:
                Console.Clear();
                Console.WriteLine(customerservice.Logout()._messege);
                isfinished = true;
                break;
        }
        Console.WriteLine("Press any key...");
        Console.ReadKey();
        Console.Clear();
    } while(!isfinished);
}