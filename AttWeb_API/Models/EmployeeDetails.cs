using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AttWeb_API.Models
{
    public class EmployeeDetails
    {
        public string Fullname { get; set; } = "";
        [Column("EmpCode")]
        public string EmpCode { get; set; } = "";
        [Column("StartTime")]
        public DateTime StartTime { get; set; }
        [Column("EndTime")]
        public DateTime EndTime { get; set; }
        [Column("Department")]
        public string Department { get; set; } = "";
        [Column("position_name")]
        public string PositionName { get; set; } = "";
  
    }
}
