using System.Data.Entity;

namespace EmployeeManagement.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext()
            : base("name=EmployeeContext")
        {
        }

        public DbSet<StaffMember> StaffMember { get; set; }
    }
}
