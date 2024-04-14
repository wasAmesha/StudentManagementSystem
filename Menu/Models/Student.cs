using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;   
using System.Text;
using System.Threading.Tasks;

namespace CBA_MenuApp.Models
{
    public  class Student
    {
       

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }

        public string Address { get; set; }
        public List<Module> Modules = new List<Module>();
        public Student(int iD, string firstName, string lastName, string dateOfBirth, string address)
        {
            ID = iD;
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Address = address;

        }public double calGPA(Student student)
        {
            double points=0;
            double creditSum=0.0000000001; //to prevent getting 0/0
            
            foreach (var mode in student.Modules) {
                points =points +(mode.GradePoint) * (mode.CreditPoint);
                creditSum=creditSum + mode.CreditPoint;
            }
            double gpa=points/creditSum;

            return gpa;

        }
    }
}
