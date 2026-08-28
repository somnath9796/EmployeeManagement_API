using Employee_Management.DTO;
using Employee_Management.DTO.Employee;
using Employee_Management.DTO.PaginationPage;
using Employee_Management.Model;

namespace Employee_Management.Repo.Interface
{
    public interface IEmployee
    {
        Task<List<EmployeeResponseDto>> GetAllEmployees(PaginationPageDto pagination);

        Task<EmployeeResponseDto> GetEmployeeById(int id);
        Task<EmployeeResponseDto> AddEmployee(CreateEmployeeDto employee);
        Task<EmployeeResponseDto> UpdateEmployee(int id, UpdatemployeeDto employee);
        Task<bool> DeleteEmployee(int id);
    }
}
