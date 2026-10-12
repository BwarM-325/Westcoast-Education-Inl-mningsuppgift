using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
namespace WestCoastEdu;


class Program
{
    static readonly List<Students> studentList = new List<Students>();
    static readonly List<Teachers> teacherList = new List<Teachers>();
    static readonly List<Courses> courseList = new List<Courses>();


    static void Main()
    {
        Console.Clear();
        Console.WriteLine("Starting application...");
        studentList.Add(new Students("John", "Kennedy", "0105073343", "0733654312", "Propellergatan 7", "Lund", "39123"));
        studentList.Add(new Students("Sven", "Svensson", "0204275679", "0700535642", "Eriksvägen 34", "Malmö", "32378"));

        App();


    }

    static void App()
    {
        
        try
        {
            while (true)
            {
                int amountStudents;

                if(studentList.Count > 0)
                {
                    amountStudents = studentList.Count;
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
                Console.WriteLine("3. List all Courses");
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
                            AddToDatabase("Cou");
                        }
                        
                        break;

                    case "2":
                        Console.WriteLine("Option 2 has been selected");
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine("------ All Courses -------");
                        DisplayCourses();
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();

                        break;
                    case "4":
                        Console.Clear();
                        Console.WriteLine("------ All Students -------");
                        DisplayPerson();
                        Console.WriteLine("Press enter to continue...");
                        Console.ReadLine();
                        Console.Clear();
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
            Console.WriteLine("Write down the students information");
            //Might need optimisation here for better info dumping
            // Can probably duplicate this for Teacher and Supervisors too
            try
            {
                Console.WriteLine("First Name");
                var fName = Console.ReadLine();
                Console.WriteLine("Last Name");
                var lName = Console.ReadLine();
                Console.WriteLine("Social Security Number --- 10 digit");
                var id = Console.ReadLine();
                Console.WriteLine("Phone Number");
                var num = Console.ReadLine();
                Console.WriteLine("Home Adress");
                var address = Console.ReadLine();
                Console.WriteLine("City");
                var city = Console.ReadLine();
                Console.WriteLine("Postal number");
                var postal = Console.ReadLine();


                
                
                studentList.Add(new Students(fName, lName, id, num, address, city, postal));
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
        else if (option == "Tea")
        {
            Console.WriteLine("Write down the teachers information");

            try
            {
                Console.WriteLine("First Name");
                var fName = Console.ReadLine();
                Console.WriteLine("Last Name");
                var lName = Console.ReadLine();
                Console.WriteLine("Social Security Number");
                var id = Console.ReadLine();
                Console.WriteLine("Phone Number");
                var num = Console.ReadLine();
                Console.WriteLine("Home Adress");
                var address = Console.ReadLine();
                Console.WriteLine("City");
                var city = Console.ReadLine();
                Console.WriteLine("Postal number");
                var postal = Console.ReadLine();
                Console.WriteLine("Subject");
                var subj = Console.ReadLine();
                Console.WriteLine("Courses they are incharge of");
                var course = Console.ReadLine();

                
                //Change to teacher list
                teacherList.Add(new Teachers(fName, lName, id, num, address, city, postal, subj, course));
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
        else if (option == "Sup")
        {
            Console.WriteLine("Write down the supervisor information");

            try
            {
                Console.WriteLine("First Name");
                var fName = Console.ReadLine();
                Console.WriteLine("Last Name");
                var lName = Console.ReadLine();
                Console.WriteLine("Social Security Number");
                var id = Console.ReadLine();
                Console.WriteLine("Phone Number");
                var num = Console.ReadLine();
                Console.WriteLine("Home Adress");
                var address = Console.ReadLine();
                Console.WriteLine("City");
                var city = Console.ReadLine();
                Console.WriteLine("Postal number");
                var postal = Console.ReadLine();

                
                //Change to supervisor list
                studentList.Add(new Students(fName, lName, id, num, address, city, postal));
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
        
        else if (option == "Cou")
        {
            Console.WriteLine("Write down the Course information");

            try
            {
                Console.WriteLine("Name of course");
                var title = Console.ReadLine();
                Console.WriteLine("Length of course dated in weeks");
                var length = Console.ReadLine();
                Console.WriteLine("Start date (empty for today or write in format YYYY-MM-DD with spaces)");
                var date = Console.ReadLine();

                if(!string.IsNullOrEmpty(date) && !DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var _date))
                {
                    throw new Exception("Wrong formatting");   
                }

                Random rnd = new();

                string courseId = rnd.Next(0, 100000).ToString("D5");

                
                courseList.Add(new Courses(courseId, title, length, date));
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


    static void DisplayPerson()
    {
        int amount = studentList.Count;
        for(int i=0; i < amount; i++)
        {
            Console.WriteLine(studentList[i]);
            Console.WriteLine("-----------");
        }
    }

    static void DisplayCourses()
    {
        int amount = courseList.Count;
        for(int i=0; i < amount; i++)
        {
            Console.WriteLine(courseList[i]);
            Console.WriteLine("-----------");
        }
    }
}
