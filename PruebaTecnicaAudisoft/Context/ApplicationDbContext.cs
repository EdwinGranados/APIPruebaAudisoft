using Microsoft.EntityFrameworkCore;
using PruebaTecnicaAudisoft.Models;

namespace PruebaTecnicaAudisoft.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Estudiante>? Estudiante { get; set; }
        public DbSet<Nota>? Nota { get; set; }
        public DbSet<Profesor>? Profesor { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        }
    }
}
