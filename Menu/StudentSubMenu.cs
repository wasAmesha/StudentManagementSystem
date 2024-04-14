using CBA_MenuApp;
using CBA_MenuApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace CBA_MenuApp
{
    public class StudentSubMenu
 
    {
        public int ColPosSub { get; set; }
        public int RowPosSub { get; set; }
        public int SelectedItemSub { get; set; }


        public List<MenuItem> MenuItemsSub { get; set; }


        //sub menu
        public StudentSubMenu()
        {
            ColPosSub = 20;
            RowPosSub = 10;
            SelectedItemSub = 0;
            MenuItemsSub = new List<MenuItem>
            {
                new MenuItem("Modify Student",true),
                new MenuItem("Add Modules",false),
                new MenuItem("Remove Modules",false),
                new MenuItem("Add Grade",false),
                new MenuItem("Delete Student",false),
                new MenuItem("Back",false)
            };
        }

       

        public void displaySubMenu(Student getStudent)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkCyan;

            Console.Clear();
            Console.CursorVisible = false;
            bool isRunningSub = true;
            bool isDisplaySub = true;

            while (isRunningSub) //to check the actions
            {
                Console.SetCursorPosition(ColPosSub, RowPosSub);

                for (int i = 0; i < MenuItemsSub.Count; i++)
                {
                    Console.SetCursorPosition(ColPosSub, RowPosSub + i);
                    if (MenuItemsSub[i].IsSelected)
                    {

                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        if (isDisplaySub == true) Console.Write(MenuItemsSub[i].Title);
                    }
                    else
                    {

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        if (isDisplaySub == true) Console.Write(MenuItemsSub[i].Title);
                    }

                }

                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.DownArrow)
                {
                    MenuItemsSub[SelectedItemSub].IsSelected = false;
                    SelectedItemSub = (SelectedItemSub + 1) % MenuItemsSub.Count;

                    MenuItemsSub[SelectedItemSub].IsSelected = true;
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    MenuItemsSub[SelectedItemSub].IsSelected = false;
                    SelectedItemSub = SelectedItemSub - 1;

                    if (SelectedItemSub < 0)
                    {
                        SelectedItemSub = MenuItemsSub.Count - 1;
                    }

                    MenuItemsSub[SelectedItemSub].IsSelected = true;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.SetCursorPosition(2, 0);
                    
                    
               
                    bool stopSub = false;
                    
                    while (!stopSub)
                    {


                         switch (MenuItemsSub[SelectedItemSub].Title)
                        {
                            case "Modify Student":
                                Console.Clear();
                               
                                Console.CursorVisible= true;
                                
                                MenuData.displayStudent(getStudent);
                                Console.WriteLine("");
                                Console.WriteLine("1.Change First Name");
                                Console.WriteLine("2.Change Last Name");
                                Console.WriteLine("3.Change Date of Birth");
                                Console.WriteLine("4.Change Address");

                                Console.WriteLine("\nEnter the relavent number:");
                                string edit=Console.ReadLine();
                               
                                switch (edit)
                                {
                                    case "1":
                                        Console.WriteLine("Enter the First Name:");
                                        getStudent.FirstName = Console.ReadLine();
                                        MenuData.displayStudent(getStudent);
                                        break;
                                    case "2":
                                        Console.WriteLine("Enter the Last Name:");
                                        getStudent.LastName = Console.ReadLine();
                                        MenuData.displayStudent(getStudent);
                                        break;
                                    case "3":
                                        Console.WriteLine("Enter the Date of Birth:");
                                        getStudent.DateOfBirth = Console.ReadLine();
                                        MenuData.displayStudent(getStudent);
                                        break;
                                    case "4":
                                        Console.WriteLine("Enter the Address:");
                                        getStudent.Address = Console.ReadLine();
                                        MenuData.displayStudent(getStudent);
                                        break;
                                    default:
                                        Console.WriteLine("Invalid Index!");
                                        break;
                                }
                                
                                
                                Console.CursorVisible = false;
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("Press 'Enter' to insert again");
                                Console.ForegroundColor = ConsoleColor.White;
                                break;

                            case "Add Modules":
                                Console.Clear();
                                MenuData.moduleList(getStudent);
                                Console.WriteLine("You selected Add Modules.");
                                MenuData.Dis_modules();
                                MenuData.displayStudent(getStudent);

                                Console.WriteLine($"\nEnter the Module Id to you want to Add: ");
                                int selectedId = Convert.ToInt32(Console.ReadLine());
                                bool isAdded = false;

                                foreach (var module in getStudent.Modules)
                                {
                                    if (module.Id == selectedId)
                                    {
                                        Console.WriteLine("\nModule has already Added");
                                        isAdded = true;
                                        break;
                                    }
                                }

                                if (isAdded == false) MenuData.addModule(getStudent.ID, selectedId);
                                
                                MenuData.moduleList(getStudent);
                               
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.SetCursorPosition(2, 24);
                                Console.WriteLine("Press 'Enter' to insert again");
                                Console.ForegroundColor = ConsoleColor.White;
                                break;

                            case "Delete Student":
                                Console.Clear();
                                Console.WriteLine("You selected Delete Student.");
                                MenuData.displayStudent(getStudent);
                                Console.WriteLine("\nDo you want to delete this student! \nIf Yes enter 'Y' else enter 'N'");
                                string ans = Console.ReadLine();

                                if ((ans == "Y") || (ans == "y"))
                                {
                                    MenuData.deleteStudent(getStudent);
                                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                                    Console.WriteLine($"Student {getStudent.FirstName} is Removed Successfuly !");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                
                                isRunningSub = false;
                                stopSub = true;
                                break;

                            case "Remove Modules":
                                Console.Clear();
                                MenuData.moduleList(getStudent);
                                Console.WriteLine("You selected Remove Modules.");
                                MenuData.displayStudent(getStudent);
                                Console.WriteLine($"\nEnter the Module Id you want to delete:");
                                int idSelected = Convert.ToInt32(Console.ReadLine());
                                bool isdeleted = false;

                                foreach (var module in getStudent.Modules)
                                {
                                    if (module.Id == idSelected)
                                    {
                                        getStudent.Modules.Remove(module);
                                        isdeleted = true;
                                        break;
                                    }
                                }

                                Console.Clear();

                                if (isdeleted == false) Console.WriteLine("Invalid Module Id or Module is already deleted");
                                MenuData.displayStudent(getStudent);
                                MenuData.moduleList(getStudent);
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.SetCursorPosition(2, 24);
                                Console.WriteLine("Press 'Enter' to insert again");
                                Console.ForegroundColor = ConsoleColor.White;
                                break;

                            case "Add Grade":
                                Console.Clear();
                                MenuData.moduleList(getStudent);
                                Console.WriteLine("You selected Remove Modules");
                                MenuData.displayStudent(getStudent);
                                Console.WriteLine($"\nEnter the Module Id to Add Module Grade:");
                                int selectedModId =Convert.ToInt32(Console.ReadLine());
                                bool isRegistered = false;

                                foreach (var module in getStudent.Modules)
                                {
                                    if(module.Id == selectedModId)
                                    {
                                        Console.WriteLine("\nGrades are:");
                                        Console.WriteLine("\tA\n\tB\n\tC\n\tE\n");
                                        Console.Write("Enter the Grade:");
                                        
                                        string grade= Console.ReadLine();
                                        isRegistered= true;

                                        switch(grade)
                                        {
                                            case "A":
                                                module.GradePoint = 4;
                                                Console.WriteLine("\nGrade A added");
                                                break;
                                            case "B":
                                                module.GradePoint = 3;
                                                Console.WriteLine("\nGrade B added");
                                                break;
                                            case "C":
                                                module.GradePoint = 2.5;
                                                Console.WriteLine("\nGrade C added");
                                                break;
                                            case "E":
                                                module.GradePoint = 0;
                                                Console.WriteLine("\nGrade E added");
                                                break;
                                            default: 
                                                Console.WriteLine("\nInvalid Grade");
                                                break;
                                        }
                                        break;
                                    }
                                }
                                if (isRegistered == false) { Console.WriteLine("\nInvalid Index!"); }
                                
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.SetCursorPosition(2, 24);
                                Console.WriteLine("Press 'Enter' to insert again");
                                Console.ForegroundColor = ConsoleColor.White;
                                break;

                            case "Back":
                                Console.Clear(); 

                                isRunningSub = false;
                                stopSub = true;
                                break;

                            default:
                                Console.Clear();
                                Console.WriteLine("Invalid ");
                                break;
                        }
                        if (stopSub != true)
                        {
                            Console.SetCursorPosition(2, 25);
                            Console.WriteLine("Enter 'B' to go back");
                           
                            string response = Console.ReadLine().ToLower();
                            Console.Clear();
                            if ((response == "B") || (response == "b"))
                            {
                                stopSub = true;

                            }
                            Console.SetCursorPosition(2, 0);
                        }
                    }
                }
            }
        }
    };
}
