namespace LaboratoryWorkOnDatabase.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        public string StudentLastName { get; set; } = null!;

        public string? StudentMiddleName { get; set; }

        public string StudentFirstName { get; set; } = null!;

        public DateOnly StudentBorn { get; set; }

        public bool StudentSex { get; set; }

        public int FormId { get; set; }
    }
}