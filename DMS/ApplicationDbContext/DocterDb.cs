using Microsoft.EntityFrameworkCore;
using DMS.viewModel;

namespace DMS.ApplicationDbContext
{
    public class DocterDb:DbContext
    {
        public DocterDb(DbContextOptions dbContext):base(dbContext) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DocterDb).Assembly);
        }
        public DbSet<DMS.viewModel.DoctorVM> DoctorVM { get; set; }
    }
    
}
