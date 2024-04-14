using CBA_MenuApp;
using CBA_MenuApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;



namespace CBA_MenuApp
{
    public class Menu
    {
        public int ColPos { get; set; }
        public int RowPos { get; set; }
        public int SelectedItem{get; set;}

        StudentSubMenu subMenu = new StudentSubMenu();
        
        public List<MenuItem> MenuItems { get; set; }
       

        //main menu

        public Menu()
        {
            ColPos = 20;
            RowPos = 10;
            SelectedItem = 0;
            MenuItems = new List<MenuItem>
            {
                new MenuItem("Add Student",true),
                new MenuItem("Select Student",false),
                new MenuItem("Delete Student",false),
                new MenuItem("Display All",false),
                new MenuItem("Quit",false)
            };
        }
     
      
        public void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            MenuData.addTempStudents();

            Console.Clear();
            bool isRunning = true;
            bool isDisplay=true;

            while (isRunning) //to check the actions
            {
                Console.SetCursorPosition(ColPos, RowPos);

                for(int i = 0; i<MenuItems.Count; i++)
                {
                    Console.SetCursorPosition(ColPos, RowPos + i);
                    if (MenuItems[i].IsSelected)
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                        if(isDisplay==true) Console.Write(MenuItems[i].Title);
                    }
                    else
                    {

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        if (isDisplay == true) Console.Write(MenuItems[i].Title);
                    }
                    
                }

                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.DownArrow) 
                { 
                    MenuItems[SelectedItem].IsSelected = false;
                    SelectedItem = (SelectedItem+1)%MenuItems.Count;
                    
                    MenuItems[SelectedItem].IsSelected = true;
                }
                if(key.Key == ConsoleKey.UpArrow)
                {
                    MenuItems[SelectedItem].IsSelected = false;
                    SelectedItem = SelectedItem - 1;

                    if(SelectedItem < 0)
                    {
                        SelectedItem = MenuItems.Count - 1;
                    }

                    MenuItems[SelectedItem].IsSelected = true;
                }
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = ConsoleColor.Black;
                    
                    Console.SetCursorPosition(2, 0);
                
              
                    bool isStop = false;
                   
                    while (!isStop)
                    {
                        switch (MenuItems[SelectedItem].Title)
                        {
                            case "Add Student":
                                Console.Clear();
                                MenuData.dispRelaventStud();
                                Console.WriteLine("You selected Add Student.");
                                MenuData.addStudent();
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.SetCursorPosition(2, 25);
                                Console.WriteLine("Press 'Enter' to add another Student");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(2, 0);
                                break;

                            case "Select Student":
                                
                                Console.Clear();
                                
                                MenuData.dispRelaventStud();
                                
                                Console.WriteLine("You selected Select Student.\n");
                                
                                Console.WriteLine("Enter the Student Id:");

                                int studentID=Convert.ToInt32(Console.ReadLine());
                                bool isStudentSelect = false;
                                foreach(var student in MenuData.students)
                                {
                                    if(student.ID == studentID)
                                    {
                                        isStudentSelect=true;
                                        
                                        subMenu.displaySubMenu(student);
                                        break;
                                    }
                                }

                                if(isStudentSelect==false) { Console.WriteLine("\nInvalid Student Id"); }


                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.SetCursorPosition(2, 25);
                                Console.WriteLine("Press any key to select student again");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(2, 0);
                                break;

                            case "Delete Student":
                                Console.Clear();
                                MenuData.dispRelaventStud();
                                Console.WriteLine("You selected Delete Student.\n");
                                Console.WriteLine("Enter the student Id you want to delete:");
                                int deleteId=Convert.ToInt32(Console.ReadLine());
                                bool isStudentDelete=false;

                                foreach (var student in MenuData.students)
                                {
                                    if (student.ID == deleteId)
                                    {
                                        MenuData.displayStudent(student);
                                        Console.WriteLine("\nDo you want to delete this student! \nIf Yes enter 'Y' else enter 'N'");
                                        string ans = Console.ReadLine();

                                        if ((ans == "Y") || (ans == "y"))
                                        {
                                            MenuData.deleteStudent(student);
                                            isStudentDelete=true;
                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                            Console.WriteLine($"\nStudent {student.ID} is Removed Successfuly !");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }
                                        break;
                                    }
                                }
                                if (isStudentDelete == false) { Console.WriteLine("\nInvalid Student Id or Student is already Deleted \a"); }

                               
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.SetCursorPosition(2, 25);
                                Console.WriteLine("Press any key to insert again");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(2, 0);
                                break;

                            case "Display All":
                                Console.Clear();
                                Console.WriteLine("You selected Display All Students.\n");
                                MenuData.print();
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.SetCursorPosition(2, 25);
                                Console.WriteLine("Press any key to insert again");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(2, 0);
                                break;

                            case "Quit":
                                Console.Clear();
                                Console.SetCursorPosition(1, 1);
                                Console.WriteLine("You selected Quit. \a");
                              
                                Console.SetCursorPosition(70, 7);
                                Console.WriteLine("Exiting........\a");

                                Console.SetCursorPosition(70, 20);
                                Console.WriteLine("");
                                isRunning = false;
                                isStop = true;
                                break; 
                               
                            default:
                                Console.Clear();
                                Console.WriteLine("Invalid ");
                                break;
                        }

                        if (isStop!= true) {
                            Console.SetCursorPosition(2, 26);

                            Console.WriteLine("Enter 'B' to go back to the Main Menu");
                            string response = Console.ReadLine().ToLower();

                            Console.Clear();
                            if ((response == "B")||(response=="b"))
                            {
                                isStop = true;
                            }
                            Console.SetCursorPosition(2, 0);
                        }   
                    }
                }
            }
        }
    };
}
