using Employee_Management.DTO;
using Employee_Management.DTO.Employee;
using Employee_Management.DTO.PaginationPage;
using Employee_Management.Model;
using Employee_Management.Repo.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management.Controllers.EmployeeController
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //https://localhost:7279/swagger/index.html
        private readonly IEmployee _employee;
        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }

        
        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetAllEmployee([FromQuery]PaginationPageDto pagination)
        {
            try
            {
                var employeeData = await _employee.GetAllEmployees(pagination);

                if (employeeData == null)
                {
                    return NotFound("No Data Found");
                }

                return Ok(employeeData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                var employeeData = await _employee.GetEmployeeById(id);

                if (employeeData == null)
                {
                    return NotFound("No Data Found");
                }

                return Ok(employeeData);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployeeData(CreateEmployeeDto employeeDto)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await _employee.AddEmployee(employeeDto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, UpdatemployeeDto employee)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id== 0 )
                {
                    return BadRequest("Enter Valid EmployeeId");
                }

                var result = await _employee.UpdateEmployee(id,employee);

                if (result == null)
                    return NotFound();

                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {

                if (id == 0)
                {
                    return BadRequest("Enter Valid EmployeeId");
                }

                var result = await _employee.DeleteEmployee(id);

                if (result == false)
                    return NotFound("No Employee Data Found");

                return Ok(new
                {
                    status = 200,
                    message = "Employee Data Deleted"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
