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

        public DbSet<Curso>? Cursos { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<Chapter>? Chapters{ get; set; }
    }
}
