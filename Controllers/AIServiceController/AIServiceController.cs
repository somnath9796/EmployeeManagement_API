using EmployeeMgmt_API.DTO.AI;
using EmployeeMgmt_API.Repo.Interface.AI;
using EmployeeMgmt_API.Repo.Repository.AI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMgmt_API.Controllers.AIServiceController
{
    //[Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AIServiceController : ControllerBase
    {
        private readonly IAIService _aiService;
        public AIServiceController(IAIService aiService)
        {
            _aiService = aiService;
        }

        [HttpPost("ask")]
        public async Task<IActionResult> Ask([FromBody] AIRequestDto aIRequestDto, CancellationToken cancellationToken)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(aIRequestDto.Question))
                {
                    return BadRequest(
                        new
                        {
                            message = "Question Is Required."
                        });  
                }

                var response = await _aiService.AskAsync(aIRequestDto.Question, cancellationToken);

                return Ok(
                    new
                    {
                        response
                    });
            }
            catch (Exception) 
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new
                    {
                        message = "An unexpected error occurred while procssing your request"
                    }
                    );
            }
        }
    }
}
