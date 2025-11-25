using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRecord
{
    // Interface
    public interface IEmployeeDataReader
    {
        Employeerecord GetEmployeeRecords(int employeeid);
    }
    // Concrete class
    public class MockEmployeeDataReader : IEmployeeDataReader
    {
        public Employeerecord GetEmployeeRecords(int employeeid)
        {
            if (employeeid == 102)
            {
                return new Employeerecord
                {
                    Id = 102,
                    Name = "Keerthana",
                    Role = "Manager",
                    IsVeteran = true
                };
            }
            if (employeeid == 101)
            {
                return new Employeerecord
                {
                    Id = 101,
                    Name = "Sanjay",
                    Role = "Developer",
                    IsVeteran = false
                };
            }
            if (employeeid == 103)
            {
                return new Employeerecord
                {
                    Id = 103,
                    Name = "Karthi",
                    Role = "Intern",
                    IsVeteran = false
                };
            }
            return new Employeerecord
            {
                Id = employeeid,
                Name = "Unknown",
                Role = "Unknown",
                IsVeteran = false
            };
        }
    }
}
