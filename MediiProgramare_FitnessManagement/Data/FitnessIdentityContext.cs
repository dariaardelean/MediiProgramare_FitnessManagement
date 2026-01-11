using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MediiProgramare_FitnessManagement.Data
{
    public class FitnessIdentityContext : IdentityDbContext<IdentityUser>
        
    {
        public FitnessIdentityContext(DbContextOptions<FitnessIdentityContext> options)
            : base(options)
        {
        }
    }
}
