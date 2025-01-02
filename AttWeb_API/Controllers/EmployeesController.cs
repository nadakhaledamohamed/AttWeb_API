using AttWeb_API.Models;
using AttWeb_API.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AttWeb_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeRepository _repository;

        public EmployeesController(EmployeeRepository repository)
        {
            _repository = repository;
        }

        //[HttpPost("details")]
        //public async Task<IActionResult> GetEmployeeDetails([FromBody] TimeDetails request, bool isStudent = false)
        //{
        //    if (request == null)
        //    {
        //        return BadRequest("Invalid request.");
        //    }

        //    if (isStudent && string.IsNullOrEmpty(request.Alias))
        //    {
        //        return BadRequest("Alias is required for student procedure.");
        //    }

        //    try
        //    {

        //        if (isStudent)
        //        {
        //            // Fetch student details


        //            var studentDetails = await _repository.GetStudentDetails(
        //                request.StartDate ?? DateTime.MinValue,
        //                request.EndDate ?? DateTime.MinValue,
        //                request.Alias,
        //                request.EmpName,
        //                request.EmpCode,
        //                request.DeptName);

        //            Console.WriteLine($"Fetched {studentDetails?.Count} student records in controller.");
        //            foreach (var student in studentDetails)
        //            {
        //                Console.WriteLine($"Fullname: {student.Fullname}, Room: {student.Room}");
        //            }

        //            if (studentDetails == null || studentDetails.Count == 0)
        //            {
        //                return NotFound("No student records found.");
        //            }

        //            return Ok(studentDetails);
        //        }
        //        else
        //        {
        //            // Fetch employee details
        //            var employeeDetails = await _repository.GetEmployeeDetails(
        //                request.StartDate ?? DateTime.MinValue,
        //                request.EndDate ?? DateTime.MinValue,
        //                alias: null, // Alias is not used for employees
        //                request.EmpName,
        //                request.EmpCode,
        //                request.DeptName,
        //                isStudent: false);

        //            if (employeeDetails == null || employeeDetails.Count == 0)
        //            {
        //                return NotFound("No employee records found.");
        //            }

        //            return Ok(employeeDetails);
        //        }
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Internal server error: {ex.Message}");
        //    }
        //}

        //        [HttpPost("details")]
        //        public async Task<IActionResult> GetEmployeeDetails([FromBody] TimeDetails request, bool isStudent = false)
        //        {
        //            if (request == null)
        //            {
        //                Console.WriteLine("Request is null.");
        //                return BadRequest("Invalid request.");
        //            }

        //            if (isStudent && string.IsNullOrEmpty(request.Alias))
        //            {
        //                Console.WriteLine("Alias is required for student procedure.");
        //                return BadRequest("Alias is required for student procedure.");
        //            }

        //            try
        //            {
        //                if (isStudent)
        //                {
        //                    // Fetch student details
        //                    Console.WriteLine("Fetching student records...");
        //                    var studentDetails = await _repository.GetStudentDetails(
        //                        request.StartDate ?? DateTime.MinValue,
        //                        request.EndDate ?? DateTime.MinValue,
        //                        request.Alias,
        //                        request.EmpName,
        //                        request.EmpCode,
        //                        request.DeptName);

        //                    Console.WriteLine($"Controller fetched {studentDetails?.Count} student records.");
        //                    if (studentDetails == null || studentDetails.Count == 0)
        //                    {
        //                        Console.WriteLine("No student records found in controller.");
        //                        return NotFound("No student records found.");
        //                    }

        //                    foreach (var student in studentDetails)
        //                    {
        //                        Console.WriteLine($"Fullname: {student.Fullname}, Room: {student.Room}");
        //                    }

        //                    return Ok(studentDetails);
        //                }
        //                else
        //                {
        //                    // Fetch employee details
        //                    Console.WriteLine("Fetching employee records...");
        //                    var employeeDetails = await _repository.GetEmployeeDetails(
        //                        request.StartDate ?? DateTime.MinValue,
        //                        request.EndDate ?? DateTime.MinValue,
        //                        alias: null, // Alias is not used for employees
        //                        request.EmpName,
        //                        request.EmpCode,
        //                        request.DeptName,
        //                        isStudent: false);

        //                    Console.WriteLine($"Controller fetched {employeeDetails?.Count} employee records.");
        //                    if (employeeDetails == null || employeeDetails.Count == 0)
        //                    {
        //                        Console.WriteLine("No employee records found in controller.");
        //                        return NotFound("No employee records found.");
        //                    }

        //                    return Ok(employeeDetails);
        //                }
        //            }
        //            catch (ArgumentException ex)
        //            {
        //                Console.WriteLine($"Argument exception in controller: {ex.Message}");
        //                return BadRequest(ex.Message);
        //            }
        //            catch (Exception ex)
        //            {
        //                Console.WriteLine($"Internal server error in controller: {ex.Message}");
        //                return StatusCode(500, $"Internal server error: {ex.Message}");
        //            }
        //        }

        //    }
        //}




        // Fetch student details



        [HttpPost("student-details")]
        public async Task<IActionResult> GetStudentDetails([FromBody] TimeDetails request)
        {
            if (request == null)
            {
                Console.WriteLine("Request is null.");
                return BadRequest("Invalid request.");
            }

            if (string.IsNullOrEmpty(request.Alias))
            {
                Console.WriteLine("Alias is required for student procedure.");
                return BadRequest("Alias is required for student procedure.");
            }

            try
            {
                Console.WriteLine("Fetching student records...");
                var studentDetails = await _repository.GetStudentDetails(
                    request.StartDate ?? DateTime.MinValue,
                    request.EndDate ?? DateTime.MinValue,
                    request.Alias,
                    request.EmpName,
                    request.EmpCode,
                    request.DeptName);

                Console.WriteLine($"Controller fetched {studentDetails?.Count} student records.");
                if (studentDetails == null || studentDetails.Count == 0)
                {
                    Console.WriteLine("No student records found in controller.");
                    return NotFound("No student records found.");
                }

                foreach (var student in studentDetails)
                {
                    Console.WriteLine($"Fullname: {student.Fullname}, Room: {student.Room}");
                }

                return Ok(studentDetails);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Argument exception in controller: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Internal server error in controller: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // Fetch employee details
        [HttpPost("employee-details")]
        public async Task<IActionResult> GetEmployeeDetails([FromBody] TimeDetails request)
        {
            if (request == null)
            {
                Console.WriteLine("Request is null.");
                return BadRequest("Invalid request.");
            }

            try
            {
                Console.WriteLine("Fetching employee records...");
                var employeeDetails = await _repository.GetEmployeeDetails(
                    request.StartDate ?? DateTime.MinValue,
                    request.EndDate ?? DateTime.MinValue,
                    alias: null, // Alias is not used for employees
                    request.EmpName,
                    request.EmpCode,
                    request.DeptName,
                    isStudent: false);

                Console.WriteLine($"Controller fetched {employeeDetails?.Count} employee records.");
                if (employeeDetails == null || employeeDetails.Count == 0)
                {
                    Console.WriteLine("No employee records found in controller.");
                    return NotFound("No employee records found.");
                }

                return Ok(employeeDetails);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Argument exception in controller: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Internal server error in controller: {ex.Message}");
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}




//Async Task: When GetEmployeeDetails in EmployeesController is marked as async Task,
//it allows the API to handle the database request asynchronously.
//Rather than blocking the thread while waiting for the GetEmployeeDetailsByRoomAndTimeInterval method to finish
//querying the database, the thread can continue handling other tasks.

//Await: When you use await before GetEmployeeDetailsByRoomAndTimeInterval,
//the API pauses at that line but doesn't block the server.
//It only resumes after the query is complete, allowing other tasks to proceed in the meantime.

//This asynchronous setup is especially useful in web applications where handling multiple requests
//concurrently is critical for efficiency.
//It prevents the API from getting "stuck" on slower database operations,
//thereby improving response times and scalability.