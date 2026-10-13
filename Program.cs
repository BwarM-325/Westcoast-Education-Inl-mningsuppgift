using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection;
using System.Runtime;
using System.Security.Cryptography.X509Certificates;
namespace WestCoastEdu;


class Program
{
    static List<Students> studentList = new List<Students>();
    static readonly List<Teachers> teacherList = new List<Teachers>();
    static readonly List<Courses> courseList = new List<Courses>();
    static readonly List<Supervisors> supervisorList = new List<Supervisors>();
    static readonly List<Admins> adminList = new List<Admins>();


    static void Main()
    {
        Console.Clear();
        Console.WriteLine("Starting application...");

        //Testing purpose until I try doing JSON Serialisation

        DataManagment.LoadData(studentList, teacherList, courseList, supervisorList, adminList);
        /*
        studentList.Add(new Students("John", "Kennedy", "0105073343", "0733654312", "Propellergatan 7", "Lund", "39123"));
        studentList.Add(new Students("Sven", "Svensson", "0204275679", "0700535642", "Eriksvägen 34", "Malmö", "32378"));
        studentList.Add(new Students("Jörgen", "Kolgana", "0407142354", "078724111", "Nobelsgatan 6", "Malmö", "29128"));
        studentList.Add(new Students("Helena", "Stuvart", "0410165456", "076675555", "Nobelsgatan 3", "Trelleborg", "29128"));
        studentList.Add(new Students("Berg", "Stefan", "0407276567", "070002342", "Eriksvägen 27", "Malmö", "21539"));

        teacherList.Add(new Teachers("Stölvart", "Ungeberga", "8906149943", "0700023452", "Förodladegatan 4", "Simrishamn", "55643", "English", "English"));
        teacherList.Add(new Teachers("Jeff", "Mittervald", "9210166523", "0761024172", "Nystensvägen 4", "Malmö", "22633", "Mathematics", "Mathematics"));
        
        supervisorList.Add(new Supervisors("Jonny", "Möller", "9410014442", "0767774772", "Propellergatan 7", "Malmö", "24433", "Swedish", "English", "2020-03-10"));

        courseList.Add(new Courses("122342", "Mathamatics", "8", "2026-09-22"));
        courseList.Add(new Courses("122342", "English 1", "12", "2026-08-12"));
        */

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
                Console.WriteLine("3. List a database");
                Console.WriteLine("0. Exit program (saving not included)");
                Console.WriteLine("--------------------------");

                var input = Console.ReadLine();

                if(string.IsNullOrWhiteSpace(input)|| input == "x" || input == "0")
                {
                    DataManagment.SaveData(studentList, teacherList, courseList, supervisorList, adminList);
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
                            AddToDatabase("Tea");
                        }
                        else if (inpu == "3")
                        {
                            AddToDatabase("Sup");
                        }
                        else if (inpu == "4")
                        {
                            AddToDatabase("Cou");
                        }
                        
                        break;

                    case "2":
                        AddAdmin();
                        break;
                    case "3":
                        Console.WriteLine("What data would you like to list");
                        Console.WriteLine("1. Student");
                        Console.WriteLine("2. Teacher");
                        Console.WriteLine("3. Supervisor");
                        Console.WriteLine("4. Course");


                        var inp = Console.ReadLine();

                        if(string.IsNullOrWhiteSpace(inp))
                        {
                            Environment.Exit(0);
                        }
                        else if (inp == "1")
                        {
                            DisplayList("Stu");
                            Console.WriteLine("Press Enter to continue...");
                            Console.ReadLine();
                        }
                        else if (inp == "2")
                        {
                            DisplayList("Tea");
                            Console.WriteLine("Press Enter to continue...");
                            Console.ReadLine();
                        }
                        else if (inp == "3")
                        {
                            DisplayList("Sup");
                            Console.WriteLine("Press Enter to continue...");
                            Console.ReadLine();
                        }
                        else if (inp == "4")
                        {
                            DisplayList("Cou");
                            Console.WriteLine("Press Enter to continue...");
                            Console.ReadLine();
                        }

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
                Console.WriteLine("Subject");
                var subj = Console.ReadLine();
                Console.WriteLine("Courses they are incharge of");
                var course = Console.ReadLine();
                Console.WriteLine("Date hired (leave empty if today)");
                var hiredDate = Console.ReadLine();

                if(!string.IsNullOrEmpty(hiredDate) && !DateTime.TryParseExact(hiredDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var _date))
                {
                    throw new Exception("Wrong formatting. Try again");   
                }



                supervisorList.Add(new Supervisors(fName, lName, id, num, address, city, postal, subj, course, hiredDate));
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

    static void DisplayList(string options)
    {
        dynamic listOptions = null;
        if(options == "Stu")
        {
            listOptions = studentList;
        }
        else if (options == "Tea")
        {
            listOptions = teacherList;
        }
        else if (options == "Cou")
        {
            listOptions = courseList;
        }
        else if (options == "Sup")
        {
            listOptions = supervisorList;
        }
        
        int amount = listOptions.Count;
        for(int i=0; i < amount; i++)
        {
            Console.WriteLine(listOptions[i]);
            Console.WriteLine("-----------");
        }
    }
    
    static void AddAdmin()
    {
        Console.WriteLine("Write down Administrators information");

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
            Console.WriteLine("Date hired (leave empty if today)");
            var hiredDate = Console.ReadLine();

            if(!string.IsNullOrEmpty(hiredDate) && !DateTime.TryParseExact(hiredDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var _date))
            {
                throw new Exception("Wrong formatting. Try again");   
            }



            adminList.Add(new Admins(fName, lName, id, num, address, city, postal, subj, course, hiredDate));
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
