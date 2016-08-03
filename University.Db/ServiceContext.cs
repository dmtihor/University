using System.Data.Entity;
using University.Db.Entity;

namespace University.Db
{
    public class ServiceContext : DbContext
    {
        public ServiceContext() : base("UniversityDb")
        {
            Database.SetInitializer<ServiceContext>(new ServiceInitializer());
        }

        public virtual DbSet<Seminar> Seminars { get; set; }
        public virtual DbSet<Lecturer> Lecturers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lecturer>()
                  .HasMany<Seminar>(s => s.Seminars)
                  .WithMany(c => c.Lecturers)
                  .Map(cs =>
                  {
                      cs.MapLeftKey("LecturerId");
                      cs.MapRightKey("SeminarId");
                      cs.ToTable("LecturerSeminar");
                  });
        }
    }
}
