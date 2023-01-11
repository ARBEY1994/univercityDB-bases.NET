using Microsoft.EntityFrameworkCore;
using univercityApiBackend.Models.DataModels;

namespace univercityApiBackend.DataAccess
{
    public class UniversityDbContext: DbContext
    {
        public UniversityDbContext(DbContextOptions<UniversityDbContext> options) : base(options)
        { 

        }
        // Add DbSets (tables of our data base)

        public DbSet<Curso>? cursos { get; set; }
    }
}
