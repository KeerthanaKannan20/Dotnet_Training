using EmployeeRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class PayrollProcessor
{
    //Dictionary initializer
    private static readonly Dictionary<int, decimal> BaseSalaries = new()
    {
        [101] = 65000m,
        [102] = 120000m,
        [103] = 30000m
    };
    private readonly IEmployeeDataReader _employeeReader;

    // Constructor Injection
    public PayrollProcessor(IEmployeeDataReader employeeReader)
    {
        _employeeReader = employeeReader;
    }

    // Pattern matching
    public decimal CalculateTotalCompensation(int employeeId)
    {
        
        var emp = _employeeReader.GetEmployeeRecords(employeeId);
        BaseSalaries.TryGetValue(employeeId, out decimal baseSalary);
        decimal bonus = emp switch
        {
            { Role: "Manager", IsVeteran: true } => 10000m,
            { Role: "Manager", IsVeteran: false } => 5000m,
            { Role: "Developer" } => 2000m,
            { Role: "Intern" } => 500m,
            _ => 0m 
        };
        return baseSalary + bonus;
    }
}
