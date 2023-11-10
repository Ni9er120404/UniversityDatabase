namespace LaboratoryWorkOnDatabase.Models
{
    public class Plan
    {
        public int PlanId { get; set; }

        public int PlanClassNumber { get; set; }

        public int TeacherDisciplineId { get; set; }

        public TeacherDiscipline TeacherDiscipline { get; set; } = null!;
    }
}