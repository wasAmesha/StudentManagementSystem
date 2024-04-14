using CBA_MenuApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CBA_MenuApp
{
    public static class MenuData
    {
        public static List<Student> students = new List<Student>();
         public static int studentID = 1006;


        //add users to the list
        public static void addStudent()
        {
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"\nNew Student ID: {studentID} ");

            Console.CursorVisible = true;
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();

            Console.Write("Enter Date of Birth DD/MM/YEAR: ");
            string dateOfBirth = Console.ReadLine();

            Console.Write("Enter Address: ");
            string address = Console.ReadLine();

            Student student = new Student(studentID, firstName, lastName, dateOfBirth, address);
            students.Add(student);
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.White;

            studentID++;
        }

        //temp users
        public static void addTempStudents()
        {
            Student student1 = new Student(1001, "Tom", "Foster", "12/02/1999", "London");
            students.Add(student1);
            Student student2 = new Student(1002, "Anne", "Harper", "08/05/1998", "York");
            students.Add(student2);
            Student student3 = new Student(1003, "Jack", "Archer", "31/10/2000", "Winchester");
            students.Add(student3);
            Student student4 = new Student(1004, "Emma", "Charlotte", "25/01/2001", "London");
            students.Add(student4);
            Student student5 = new Student(1005, "Peter", "Keller", "16/07/1999", "Stamford");
            students.Add(student5);

        }

        
        //display modules
        public static void Dis_modules()
        {
            Console.WriteLine("\nModules List\n");
            Console.WriteLine(" 3301 - Analog Electronics");
            Console.WriteLine(" 3302 - Data Structures and Algorithems");
            Console.WriteLine(" 3203 - Electrical and Electronic Measurements");
            Console.WriteLine(" 3305 - Signals and Systems");
            Console.WriteLine(" 3251 - GUI Programming");
            Console.WriteLine(" 3250 - Programming Project\n");
            

        }
       
        //to add modules for users
        public static void addModule(int studID,int modId)
        {
        
            foreach (var student in students)
            {
               
                if(student.ID == studID){ 
                   
                    switch (modId)
                    {
                        
                        case 3301:
                            Module AE = new Module(3301, "Analog Electronics", 3);
                            Console.WriteLine($"Student {modId} is registered to {AE.Name}");
                            student.Modules.Add(AE);
                            break;
                        case 3302:
                            Module DAA = new Module(3302, "Data Structures and Algorithems", 3);
                            student.Modules.Add(DAA);
                            Console.WriteLine($"Student {modId} is registered to {DAA.Name}");
                            break;
                        case 3203:
                            Module EM = new Module(3203, "Electrical and Electronic Measurements", 2);
                            student.Modules.Add(EM);
                            Console.WriteLine($"Student {modId} is registered to {EM.Name}");
                            break;
                        case 3305:
                            Module SAS = new Module(3305, "Signals and Systems", 3);
                            student.Modules.Add(SAS);
                            Console.WriteLine($"Student {modId} is registered to {SAS.Name}");
                            break;
                        case 3251:
                            Module GUI = new Module(3251, "GUI Programming", 2);
                            student.Modules.Add(GUI);
                            Console.WriteLine($"Student {modId} is registered to {GUI.Name}");
                            break;
                        case 3250:
                            Module PP = new Module(3250, "Programming Project", 3);
                            student.Modules.Add(PP);
                            Console.WriteLine($"Student {modId} is registered to {PP.Name}");
                            break;
                        default:
                            Console.WriteLine("Invalid Module Id");
                            break;
                    }
                    break;
                }
            }
            
        }
        
        //display the modules
        public static void moduleList(Student studentMod)
        {
            Console.SetCursorPosition(100, 0);
            int i = 1;
           
            Console.WriteLine("  ----- Registered Modules List ----");
            foreach (var mod in studentMod.Modules)
            {
                Console.SetCursorPosition(100, i+1);
                Console.WriteLine($"   {mod.Id} {mod.Name}");
                i=i+1;
            }
            Console.SetCursorPosition(2, 0);
           

        }

        public static void print()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(40, 0);
            int i = 1;
            Console.WriteLine("ID\tFirst Name\t  Last Name\t      DOB\t    Address\t\t                     GPA");
            Console.SetCursorPosition(40, 1);
            Console.WriteLine("--\t----------\t  ---------\t      ---\t    -------\t\t                     ---");
            foreach (var student in students)
            {
                Console.SetCursorPosition(39, i+1);
                i = i + 1;
                Console.WriteLine($"{student.ID,-10}{student.FirstName,-18}{student.LastName,-17}{student.DateOfBirth,-15}{student.Address,-42}{student.calGPA(student),-5}");
            }
            Console.SetCursorPosition(2, 0);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void dispRelaventStud()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(75, 0);
            
            Console.WriteLine("ID\t\tFirst Name\t\tLast Name");
            Console.SetCursorPosition(75, 1);
            Console.WriteLine("");
            int i = 2;
            foreach (var student in students)
            {
                Console.SetCursorPosition(75, i);
                i = i + 1;
                Console.WriteLine($"{student.ID}\t\t{student.FirstName,-15}\t\t{student.LastName,-15}");
            }
            Console.SetCursorPosition(2, 0);
            Console.ForegroundColor = ConsoleColor.White;
        }

        //delete a user
        public static void deleteStudent(Student studentDelete)
        {
            students.Remove(studentDelete);
           
        }
        
        //display only one user

        public static void displayStudent(Student s)
        {
           
            Console.WriteLine("ID\tFirst Name\t  Last Name\t      DOB\t    Address");
            Console.WriteLine($"{s.ID,-10}{s.FirstName,-18}{s.LastName,-17}{s.DateOfBirth,-15}{s.Address,-42}");

        }

    }
}
