using Employee_Management.Data;
using Employee_Management.DTO;
using Employee_Management.DTO.Employee;
using Employee_Management.DTO.PaginationPage;
using Employee_Management.Model;
using Employee_Management.Repo.Interface;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management.Repo.Repository
{
    public class EmployeeRepository : IEmployee
    {
        private readonly ApplicationDBContext _context;

        public EmployeeRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<EmployeeResponseDto> AddEmployee(CreateEmployeeDto _createemployee)
        {

            var employee = new Employee
            {
                EmployeeName = _createemployee.EmployeeName,
                EmployeeEmail = _createemployee.EmployeeEmail,
                EmployeeDepartment = _createemployee.EmployeeDepartment,
                DateOfJoining = _createemployee.DateOfJoining,
                Salary = _createemployee.Salary,
                IsActive = _createemployee.IsActive,
            };

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();


            var responseData = new EmployeeResponseDto
            {
                EmployeeId = employee.EmployeeId,
                EmployeeName = employee.EmployeeName,
                EmployeeEmail = employee.EmployeeEmail,
                EmployeeDepartment = employee.EmployeeDepartment,
                DateOfJoining = employee.DateOfJoining,
                Salary = employee.Salary,
                IsActive = employee.IsActive,
            };


            return responseData;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            //check if existing

            var existibgEmployee = await _context.Employees.FindAsync(id);
         
            if(existibgEmployee == null)
            {
                return false;
            }

            existibgEmployee.IsActive = false;
            //_context.Employees.Remove(existibgEmployee);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<EmployeeResponseDto>> GetAllEmployees(PaginationPageDto pagination)
        {
            var getEmpData = await _context.Employees.ToListAsync();

            var responseData = getEmpData.Select(EmpData => new EmployeeResponseDto
            {
                EmployeeId = EmpData.EmployeeId,
                EmployeeName = EmpData.EmployeeName,
                EmployeeEmail = EmpData.EmployeeEmail,
                EmployeeDepartment = EmpData.EmployeeDepartment,
                DateOfJoining = EmpData.DateOfJoining,
                Salary = EmpData.Salary,
                IsActive = EmpData.IsActive,
            }).Skip((pagination.PageNumber - 1) * pagination.PageSize).Take(pagination.PageSize).ToList();


            return responseData;
        }

        public async Task<EmployeeResponseDto> GetEmployeeById(int id)
        {
            var getEmpById  = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);

            if (getEmpById == null)
            {
                return null;
            }


            var responseData = new EmployeeResponseDto
            {
                EmployeeId = getEmpById.EmployeeId,
                EmployeeName = getEmpById.EmployeeName,
                EmployeeEmail = getEmpById.EmployeeEmail,
                EmployeeDepartment = getEmpById.EmployeeDepartment,
                DateOfJoining = getEmpById.DateOfJoining,
                Salary = getEmpById.Salary,
                IsActive = getEmpById.IsActive,
            };


            return responseData;
        }

        public async Task<EmployeeResponseDto> UpdateEmployee(int id, UpdatemployeeDto employee)
        {
            // Check if employee Exists


            if(id == 0 )
            { return null; }

        var ExistingEmp = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeId == id);

            if(ExistingEmp == null)
            {
                return null;
            }

            ExistingEmp.EmployeeName = employee.EmployeeName;
            ExistingEmp.EmployeeEmail = employee.EmployeeEmail;
            ExistingEmp.EmployeeDepartment = employee.EmployeeDepartment;
            ExistingEmp.Salary = employee.Salary;
            ExistingEmp.DateOfJoining = employee.DateOfJoining;
            ExistingEmp.IsActive = employee.IsActive;

            await _context.SaveChangesAsync();

            var ResponseData = new EmployeeResponseDto
            {
                EmployeeId = employee.EmployeeId,
                EmployeeName = employee.EmployeeName,
                EmployeeEmail = employee.EmployeeEmail,
                EmployeeDepartment = employee.EmployeeDepartment,
                DateOfJoining = employee.DateOfJoining,
                Salary = employee.Salary,
                IsActive = employee.IsActive,
            };

            return ResponseData;
        }
    }
}
