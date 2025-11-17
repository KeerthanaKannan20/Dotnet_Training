using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_1_Assignment
{
    public partial class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public partial class Student
    {
        public void DisplayDetails()
        {
            Console.WriteLine($"Name : {Name}, Age : {Age}");
        }
    }
 

namespace PartialClass
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                Student student = new Student();
                Console.WriteLine("Enter student Name :");
                student.Name = Console.ReadLine();
                Console.WriteLine("Enter student Age :");
                student.Age = Convert.ToInt32(Console.ReadLine());
                student.DisplayDetails();
                Console.ReadLine();

            }
        }
    }

}
