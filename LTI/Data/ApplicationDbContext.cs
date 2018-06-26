using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LTI.Models;

namespace LTI.Data
{
    class ApplicationDbContext : DbContext
    {
        

        //Database tables
        public DbSet<Configuration> Configurations { get; set; }
        public DbSet<Complain> Complains { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<Norma> Normas { get; set; } 
        public DbSet<HistoryStudent> HistoryStudents { get; set; }
        public DbSet<HistoryTeacher> HistoryTeachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Trimestre> Trimestres { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }

        //Relations
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);

            builder.UseSqlServer(@"Data Source=tcp:GOISTER\SQLEXPRESS;Initial Catalog=LTI;User ID=goister;Password=Pplg4856");

            //Specify all relation here -- EF CORE 2 

            //// HistoryStudent - Student (1 - *)
            //builder.Entity<Student>()
            //    .HasOne(st => st.HistoryStudent)
            //    .WithMany(hs => hs.Students)
            //    .HasForeignKey(st => st.HistoryStudentID);

            //// HistoryTeacher - Teacher (1 - *)
            //builder.Entity<Teacher>()
            //    .HasOne(tc => tc.HistoryTeacher)
            //    .WithMany(hc => hc.Teachers)
            //    .HasForeignKey(tc => tc.HistoryTeacherID);

            //// Teacher - Suggestion (1 - *)
            //builder.Entity<Suggestion>()
            //    .HasOne(sg => sg.Teacher)
            //    .WithMany(tc => tc.Suggestions)
            //    .HasForeignKey(sg => sg.TeacherID);

            //// Teacher - Claim (1 - *)
            //builder.Entity<Claim>()
            //    .HasOne(cl => cl.Teacher)
            //    .WithMany(tc => tc.Claims)
            //    .HasForeignKey(cl => cl.TeacherID);

            //// Teacher - Complain (1 - *)
            //builder.Entity<Complain>()
            //    .HasOne(cp => cp.Teacher)
            //    .WithMany(tc => tc.Complains)
            //    .HasForeignKey(cp => cp.TeacherID);

            //// Student - Suggestion (1 - *)
            //builder.Entity<Suggestion>()
            //    .HasOne(sg => sg.Student)
            //    .WithMany(st => st.Suggestions)
            //    .HasForeignKey(sg => sg.StudentID);

            //// Student - Claim (1 - *)
            //builder.Entity<Claim>()
            //    .HasOne(cl => cl.Student)
            //    .WithMany(st => st.Claims)
            //    .HasForeignKey(cl => cl.StudentID);

            //// Student - Complain (1 - *)
            //builder.Entity<Complain>()
            //    .HasOne(cp => cp.Student)
            //    .WithMany(st => st.Complains)
            //    .HasForeignKey(st => st.StudentID);

            //// Teacher - Subject (1 - *)
            //builder.Entity<Subject>()
            //    .HasOne(sb => sb.Teacher)
            //    .WithMany(tc => tc.Subjects)
            //    .HasForeignKey(sb => sb.TeacherID);



        }
    }
}
