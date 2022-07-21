
using Microsoft.EntityFrameworkCore;

namespace decentraMed.Models
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<DoctorInfo> DoctorInfo { get; set; }
        public DbSet<Vaccination> Vaccination { get; set; }
        public DbSet<Diagnosis> Diagnosis { get; set; }
        public DbSet<Allergies> Allergies { get; set; }

        public DbSet<UserTokens> userTokens { get; set; }
        


    }
}
