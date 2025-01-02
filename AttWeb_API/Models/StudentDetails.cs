//using System.ComponentModel.DataAnnotations.Schema;

//namespace AttWeb_API.Models
//{
//    public class StudentDetails
//    {

//        public string Fullname { get; set; } = "";
//        [Column("EmpCode")]
//        public string EmpCode { get; set; } = "";
//        [Column("StartTime")]
//        public DateTime StartTime { get; set; }
//        [Column("EndTime")]
//        public DateTime EndTime { get; set; }
//        [Column("Department")]
//        public string Department { get; set; } = "";
//        [Column("position_name")]
//        public string PositionName { get; set; } = "";
//        [Column("alias")]
//        public string Room { get; set; } = "";
//    }

//}

using System.ComponentModel.DataAnnotations.Schema;

public class StudentDetails
{
    public string Fullname { get; set; } = ""; // Maps to Fullname
    [Column("EmpCode")]
    public string EmpCode { get; set; } = ""; // Maps to EmpCode
    [Column("StartTime")]
    public DateTime? StartTime { get; set; } // Nullable datetime
    [Column("EndTime")]
    public DateTime? EndTime { get; set; } // Nullable datetime
    [Column("Room")]
    public string Room { get; set; } = ""; // Maps to Room, non-nullable
    [Column("Department")]
    public string Department { get; set; } = ""; // Maps to Department
    [Column("position_name")]
    public string PositionName { get; set; } = ""; // Maps to position_name
}
