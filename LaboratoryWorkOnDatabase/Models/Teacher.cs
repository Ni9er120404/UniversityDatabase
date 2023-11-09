namespace LaboratoryWorkOnDatabase.Models
{
    public class Teacher
    {
        public int TeacherId { get; set; }

        public string TeacherLastName { get; set; } = null!;
        
        public string? TeacherMiddleName { get; set; }

        public string TeacherFirstName { get; set; } = null!;

        public DateOnly TeacherBorn { get; set; }

        public bool TeacherSex { get; set; }

        public int TitleId { get; set; }
    }
}