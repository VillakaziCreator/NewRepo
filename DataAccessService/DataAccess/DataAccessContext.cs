using Microsoft.EntityFrameworkCore;

namespace DataAccessService.DataAccess
{
    public class DataAccessContext : DbContext
    {
        public DataAccessContext(DbContextOptions<DataAccessContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Student>().HasData(new Student
            //{
            //    StudentNumber = "21963258",
            //    FirstName = "Nhlanhla"

            //}, new Student
            //{
            //    StudentNumber = "21623112",
            //    FirstName = "Aphiwe"
            //});


            //modelBuilder.Entity<Course>().HasData(new Course
            //{
            //    CourseID = "1",
            //    Description = "Information Technology",
            //    CoursePath = "Informatics",
            //    NumberOfStudents = "2"

            //}, new Course
            //{
            //    CourseID = "2",
            //    Description = "Bachelour of Education",
            //    CoursePath = "Teaching",
            //    NumberOfStudents = "5"
            //});

        }
    }
}