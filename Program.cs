using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using StudentBank;
namespace WestCoastEdu;


class Program
{
    static readonly List<Students> studentList = new List<Students>();

    static void Main()
    {
        Console.Clear();
        Console.WriteLine("Starting application...");

        App();


    }

    static void App()
    {
        
        try
        {
            while (true)
            {
                int amountStudents;

                if(studentList.Capacity > 0)
                {
                    amountStudents = studentList.Capacity;
                }
                else
                {
                    amountStudents = 0;
                }
                
                //Temp UI until I figure out how to do headers maybe
                Console.WriteLine("--------------------------");
                Console.WriteLine("Welcome to WestCoast Educations manager");
                Console.WriteLine("Choose what you would like to do");
                Console.WriteLine($"Students: {amountStudents}");
                Console.WriteLine("1. Add new data to the database");
                Console.WriteLine("2. Add Administrator");
                Console.WriteLine("3. List all courses");
                Console.WriteLine("4. List all Students");
                Console.WriteLine("0. Exit program (saving not included)");
                Console.WriteLine("--------------------------");

                var input = Console.ReadLine();

                if(string.IsNullOrWhiteSpace(input)|| input == "x" || input == "0")
                {
                    Environment.Exit(0);
                }

                switch(input)
                {
                    case "1":
                        
                        Console.WriteLine("What data would you like to add to the database");
                        Console.WriteLine("1. Student");
                        Console.WriteLine("2. Teacher");
                        Console.WriteLine("3. Supervisor");
                        Console.WriteLine("4. Course");

                        var inpu = Console.ReadLine();

                        if(string.IsNullOrWhiteSpace(inpu))
                        {
                            Environment.Exit(0);
                        }
                        else if (inpu == "1")
                        {
                            AddToDatabase("Stu");
                        }
                        else if (inpu == "2")
                        {
                            Console.WriteLine("Option 2 has been selected");
                        }
                        else if (inpu == "3")
                        {
                            Console.WriteLine("Option 3 has been selected");
                        }
                        else if (inpu == "4")
                        {
                            Console.WriteLine("Option 4 has been selected");
                        }
                        
                        break;

                    case "2":
                        Console.WriteLine("");
                        break;
                }
            }
        }

        catch(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ResetColor();
            App();
        }
        finally
        {
            Console.WriteLine("Finished");
        }
    }

    static void AddToDatabase(string option)
    {
        if(option == "Stu")
        {
            Console.WriteLine("Write down the Students information");
            //Might need optimisation here for better info dumping
            // Can probably duplicate this for Teacher and Supervisors too
            try
            {
                Console.WriteLine("First Name");
                var fName = Console.ReadLine();
                Console.WriteLine("Last Name");
                var lName = Console.ReadLine();
                Console.WriteLine("Social Security Number");
                var id = Console.ReadLine();

                if(int.TryParse(id, out int _id))
                {
                    throw new Exception("Value you have written down is not a number");
                    
                }

                Console.WriteLine("Phone Number");
                var num = Console.ReadLine();

                if(int.TryParse(num, out int _num))
                {
                    throw new Exception("Value you have written down is not a number");
                    
                }
                Console.WriteLine("Home Adress");
                var address = Console.ReadLine();
                Console.WriteLine("City");
                var city = Console.ReadLine();
                Console.WriteLine("Postal number");
                var postal = Console.ReadLine();

                if(int.TryParse(postal, out int _postal))
                {
                    throw new Exception("Value you have written down is not a number");
                    
                }

                
                
                studentList.Add(new Students(fName, lName, _id, _num, address, city, _postal));
            }
            catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
                App(); 
            }
            finally
            {
                Console.WriteLine("Finished");
            }

            
            
        }
    }
}
