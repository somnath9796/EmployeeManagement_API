using Employee_Management.Model;
using Microsoft.EntityFrameworkCore;

namespace Employee_Management.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
       
    }
}
