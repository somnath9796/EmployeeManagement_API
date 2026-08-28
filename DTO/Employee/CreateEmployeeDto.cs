using System.ComponentModel.DataAnnotations;

namespace Employee_Management.DTO.Employee
{
    public class CreateEmployeeDto
    {
        [Required(ErrorMessage ="Enter Employee Name")]
        [StringLength(50)]
        public string EmployeeName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Enter Employee Email")]
        [EmailAddress]
        public string EmployeeEmail { get; set; } = string.Empty;

        [Required]
        public string EmployeeDepartment { get; set; } = string.Empty;

        [Range(1000, 1000000)]
        public int Salary { get; set; }

        public DateTime? DateOfJoining { get; set; }

        public bool IsActive { get; set; }
    }
}
