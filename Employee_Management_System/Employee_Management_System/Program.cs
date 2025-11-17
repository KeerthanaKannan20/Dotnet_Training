using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee(101,"Keerthana","IT",50000,6),
                new Employee(102,"Sanjay","HR",90000,8),
                new Employee(111,"Afshan","Finance",35000,3),
                new Employee(106,"Hari","Sales",44000,5),
                new Employee(114,"Dharani","HR",20000,2),
                new Employee(135,"Umesh","IT",15000,1),
                new Employee(173,"Sree","Sales",20000,2),
                new Employee(153,"Aravind","Finance",25000,2),
                new Employee(123,"Karthi","Sales",74000,9),
                new Employee(166,"Sudha","HR",48000,5),
            };

            //Filtering using lambda
            var HighestSalary = employees.Where(e => e.Salary > 50000).ToList(); 
            var ITDepartment = employees.Where(e => e.Department=="IT").ToList();
            var ExperienceOfFive = employees.Where(e => e.Experience > 5).ToList();
            var NameStartWithA = employees.Where(e => e.Name.StartsWith("A")).ToList();

            //Sort the employee list by using lambda
            var SortByName = employees.OrderBy(e => e.Name).ToList();
            var SortBySalary = employees.OrderByDescending(e => e.Salary).ToList();
            var SortByExperience = employees.OrderBy(e => e.Experience).ToList();

            //Promotion list
            var PromotionList = employees.Where(e => e.Salary > 80000 && e.Experience > 7).ToList();

            //Display the output
            Console.WriteLine("********** ALL EMPLOYEES**********");
            employees.ForEach(e => Console.WriteLine(e));

            Console.WriteLine("\n---------- EMPLOYEES WITH SALARY > 50,000 ----------");
            HighestSalary.ForEach(e => Console.WriteLine(e));

            Console.WriteLine("\n---------- IT DEPARTMENT EMPLOYEES -----------");
            ITDepartment.ForEach(e => Console.WriteLine(e));

            Console.WriteLine("\n----------- EXPERIENCE > 5 YEARS-----------");
            ExperienceOfFive.ForEach(e => Console.WriteLine(e));

            Console.WriteLine("\n----------- NAME STARTS WITH 'A' -----------");
            NameStartWithA.ForEach(e => Console.WriteLine(e));

            Console.WriteLine("\n----------- SORTED BY NAME (A–Z) ------------");
            SortByName.ForEach(e => Console.WriteLine(e));

            Console.WriteLine("\n----------- SORTED BY SALARY (HIGH - LOW) -----------");
            SortBySalary.ForEach(e => Console.WriteLine(e));

            Console.WriteLine("\n----------- SORTED BY EXPERIENCE (LOW - HIGH) -----------");
            SortByExperience.ForEach(e => Console.WriteLine(e));

            Console.WriteLine("\n--------- PROMOTION LIST -----------");
            PromotionList.ForEach(e => Console.WriteLine(e));
        }
    }
}
