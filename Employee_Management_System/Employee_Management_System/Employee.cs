using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Management_System
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
        public int Experience { get; set; }

        public Employee(int EmpId, string Name, string Department, double Salary, int Experience)
        {
            this.EmpId = EmpId;
            this.Name = Name;
            this.Department = Department;
            this.Salary = Salary;
            this.Experience = Experience;
        }

        public override string ToString()
        {
            return $"EmpId: {EmpId} | Name: {Name} | Dept: {Department} | Salary: {Salary} | Exp: {Experience} yrs";
        }
    }
}
