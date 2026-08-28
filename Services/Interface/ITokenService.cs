namespace Employee_Management.Services.Interface
{
    public interface ITokenService
    {
        string GenerateToken(string username);
    }
}
