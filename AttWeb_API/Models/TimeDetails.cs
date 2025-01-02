using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AttWeb_API.Models
{
    public class TimeDetails
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string EmpName { get; set; } = "";
        public string EmpCode { get; set; } = "";
        public string DeptName { get; set; } = "";
        [Column("Room")]
        public string Alias { get; set; } = ""; // Mandatory for students
    }
}
