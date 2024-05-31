using Microsoft.EntityFrameworkCore;

namespace ProjektPraktyki_2._0.Models
{
    public class CompanyContext  : DbContext
    {

        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {

        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Company> Companys  { get; set; }
        
    }

    
}
