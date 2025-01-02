
using AttWeb_API.Data;
using AttWeb_API.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AttWeb_API.Repository
{
    public class EmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Fetch employee details
        public async Task<List<EmployeeDetails>> GetEmployeeDetails(
            DateTime startDate,
            DateTime endDate,
            string alias = null,
            string empName = null,
            string empCode = null,
            string deptName = null,
            bool isStudent = false)
        {
            var startDateParam = new SqlParameter("@start_date", startDate);
            var endDateParam = new SqlParameter("@end_date", endDate);
            var empNameParam = new SqlParameter("@emp_name", empName ?? (object)DBNull.Value);
            var empCodeParam = new SqlParameter("@emp_code", empCode ?? (object)DBNull.Value);
            var deptNameParam = new SqlParameter("@dept_name", deptName ?? (object)DBNull.Value);

            string storedProcedure = "[dbo].[GetEmployeeDetailsByRoomAndTimeIntervalforEmp]";

            return await _context.EmployeeDetails
                .FromSqlRaw(
                    $"EXEC {storedProcedure} @start_date, @end_date, @emp_name, @emp_code, @dept_name",
                    startDateParam, endDateParam, empNameParam, empCodeParam, deptNameParam)
                .ToListAsync();
        }

        // Fetch student details
        public async Task<List<StudentDetails>> GetStudentDetails(
            DateTime startDate,
            DateTime endDate,
           string alias,
            string empName = null,
            string empCode = null,
            string deptName = null
          

            )
        {
            if (string.IsNullOrEmpty(alias))
            {
                throw new ArgumentException("Alias is required for the student procedure.");
            }

            var startDateParam = new SqlParameter("@start_date", startDate);
            var endDateParam = new SqlParameter("@end_date", endDate);
            var empNameParam = new SqlParameter("@emp_name", empName ?? (object)DBNull.Value);
            var empCodeParam = new SqlParameter("@emp_code", empCode ?? (object)DBNull.Value);
            var deptNameParam = new SqlParameter("@dept_name", deptName ?? (object)DBNull.Value);
            var aliasParam = new SqlParameter("@alias", alias);

            Console.WriteLine("Executing stored procedure with parameters:");
            Console.WriteLine($"StartDate: {startDate}");
            Console.WriteLine($"EndDate: {endDate}");
            Console.WriteLine($"EmpName: {empName}");
            Console.WriteLine($"EmpCode: {empCode}");
            Console.WriteLine($"DeptName: {deptName}");
            Console.WriteLine($"Alias: {alias}");


            return await _context.StudentDetails
                .FromSqlRaw(
                    "EXEC [dbo].[GetEmployeeDetailsByRoomAndTimeIntervalforStud] @start_date, @end_date, @emp_name, @emp_code, @dept_name, @alias", 
                    startDateParam, endDateParam, empNameParam, empCodeParam, deptNameParam, aliasParam)
                .ToListAsync();
        }
    }
}


//input jason data for testing 
//{
//    "startDate": "2024-11-20",
//  "endDate": "2024-12-10",
//  "empName": "",
//  "empCode": "8000066",
//  "deptName": "IT"
//}


//{
//    "startDate": "2024-11-20",
//  "endDate": "2024-12-10",
//  "empName": "",
//  "empCode": "",
//  "deptName": "",
//  "alias": "Dent-LecHall-020"
//}


