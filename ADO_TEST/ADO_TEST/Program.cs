using ADO.NET_Assign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_TEST
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Connected connected = new Connected();

            Console.WriteLine("--------- Connected Architecture ----------");

            Console.WriteLine("TASK - 2.1");
            connected.DisplayCourse();
            Console.WriteLine("--------------------------------");


            Console.WriteLine("TASK - 2.2");
            connected.AddNewStudent();
            Console.WriteLine("--------------------------------");


            Console.WriteLine("TASK - 2.3");
            Console.WriteLine("Enter Department: ");
            string department = Console.ReadLine();
            connected.SearchStudent(department);
            Console.WriteLine("--------------------------------");

            
            Console.WriteLine("TASK - 2.4");
            Console.WriteLine("Enter Student Id: ");
            int studentId = int.Parse(Console.ReadLine()); 
            connected.DisplayEnrolledCourses(studentId); 
            Console.WriteLine("--------------------------------");
            

            Console.WriteLine("TASK - 2.5");
            Console.WriteLine("Enter Enrollment Id: ");
            int EnrollmentId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the Grade: ");
            string Grade = Console.ReadLine();
            connected.UpdateGrade(EnrollmentId,Grade);
            Console.WriteLine("-------------------------------");

            Console.WriteLine("TASK PROCEDURE");
            connected.GetCourseBySem();
            Console.WriteLine("--------------------------------------------------------------------");

            

            DisConnected disConnected = new DisConnected();
            Console.WriteLine("----------- Disconnected Architecture ----------");

            Console.WriteLine("TASK - 3.1");
            disConnected.LoadData();
            Console.WriteLine("--------------------------------");


            Console.WriteLine("TASK - 3.2");
            disConnected.Modify();
            Console.WriteLine("--------------------------------");


            Console.WriteLine("TASK - 3.3");
            disConnected.InsertNewCourse();
            Console.WriteLine("--------------------------------");

            Console.WriteLine("TASK - 3.4");
            disConnected.DeleteStudent();
            Console.WriteLine("--------------------------------");
        }
    }
}
