namespace LaboratoryWorkOnDatabase.Models
{
    public class TeacherDiscipline
    {
        public int TeacherDisciplineId { get; set; }

        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; } = null!;

        public int DisciplineId { get; set; }

        public Discipline Discipline { get; set; } = null!;
    }
}