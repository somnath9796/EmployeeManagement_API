namespace EmployeeMgmt_API.Repo.Interface.AI
{
    public interface IAIService
    {
        Task<string> AskAsync(string question, CancellationToken cancellationToken);
    }
}
