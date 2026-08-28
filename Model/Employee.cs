namespace Employee_Management.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeeDepartment { get; set; }
        public int Salary { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public bool IsActive { get; set; }
    }
}
