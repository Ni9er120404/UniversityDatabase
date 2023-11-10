using LaboratoryWorkOnDatabase.Models;
using Microsoft.EntityFrameworkCore;

namespace LaboratoryWorkOnDatabase.Data
{
    public class Context(DbContextOptions<Context> options) : DbContext(options)
    {
        public DbSet<Discipline> Disciplines { get; set; }

        public DbSet<Form> Forms { get; set; }

        public DbSet<People> Peoples { get; set; }

        public DbSet<Plan> Plans { get; set; }

        public DbSet<Sheet> Sheets { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<TeacherDiscipline> TeacherDisciplines { get; set; }

        public DbSet<Title> Titles { get; set; }
    }
}