namespace LaboratoryWorkOnDatabase.Models
{
    public class Student : People
    {
        public int FormId { get; set; }

        public Form Form { get; set; } = null!;
    }
}