#pragma warning disable OPENAI001

using EmployeeMgmt_API.Repo.Interface.AI;
using OpenAI.Responses;

namespace EmployeeMgmt_API.Repo.Repository.AI
{
    public class AIServiceRepository : IAIService
    {
        private readonly ResponsesClient _responsesClient;
        private readonly IConfiguration _config;
        private readonly ILogger<AIServiceRepository> _logger;


        public AIServiceRepository(ResponsesClient responsesClient, IConfiguration configuration, ILogger<AIServiceRepository> logger)
        {
            _config = configuration;
            _responsesClient = responsesClient;
            _logger = logger;
        }

        public async Task<string> AskAsync(string question, CancellationToken cancellationToken)
        {

            try
            {

                _logger.LogInformation("Processing LLM Request");

                var model = _config["OpenAI:Model"] ?? "gpt-5.2";

                var response = await _responsesClient.CreateResponseAsync(
                    model, question,cancellationToken:cancellationToken);

                return response.Value.GetOutputText();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while processing LLM request");
                throw;
            }

            
        }
    }
}
