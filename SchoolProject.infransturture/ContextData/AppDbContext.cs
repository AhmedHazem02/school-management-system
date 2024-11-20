using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entites;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using EntityFrameworkCore.EncryptColumn.Extension;

namespace SchoolProject.infransturture.Data
{
    public class AppDbContext:DbContext
    {
        private readonly IEncryptionProvider _encryptionProvider;
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext>options):base(options) 
        {
            _encryptionProvider=new GenerateEncryptionProvider("8487e014e5e244f2ab85af391ea165aa");
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<DepartmentSubject> DepartmentSubjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set;}
        public DbSet<Instructor_Subject> Instructor_Subject { get; set; }
        public DbSet<Instructor> Instructors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instructor_Subject>()
                .HasKey(x => new { x.SubId, x.InstId });
            modelBuilder.Entity<StudentSubject>()
                .HasKey(x => new { x.StudentId, x.SubjectId });
            modelBuilder.Entity<DepartmentSubject>()
                .HasKey(x => new {x.SubjectId,x.DepartmentId});

            modelBuilder.Entity<Instructor>()
                .HasOne(x=>x.SuperVisor)
                .WithMany(x=>x.Instructors)
                .HasForeignKey(x=>x.SuperVisorId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Department>()
                .HasOne(x => x.Instructor)
                .WithOne(x => x.Department_Manager)
                .HasForeignKey<Department>(x => x.Ins_Manager)
                 .OnDelete(DeleteBehavior.Restrict); ; 


            base.OnModelCreating(modelBuilder);
            modelBuilder.UseEncryption(_encryptionProvider); 
        }
    }
}
