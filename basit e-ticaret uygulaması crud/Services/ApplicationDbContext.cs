using Microsoft.EntityFrameworkCore;

namespace basit_e_ticaret_uygulaması_crud.Services
{
    public class ApplicationDbContext : DbContext
    {
        //constructor
        public ApplicationDbContext(DbContextOptions options):base(options) { 
        
        }
    }
}
