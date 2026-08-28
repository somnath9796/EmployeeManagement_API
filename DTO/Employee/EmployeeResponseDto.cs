namespace Employee_Management.DTO.Employee
{
    public class EmployeeResponseDto
    {
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; } = string.Empty;

        public string EmployeeEmail { get; set; } = string.Empty;

        public string EmployeeDepartment { get; set; } = string.Empty;

        public int Salary { get; set; }

        public DateTime? DateOfJoining { get; set; }

        public bool IsActive { get; set; }
    }
}
