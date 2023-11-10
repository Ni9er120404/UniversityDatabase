namespace LaboratoryWorkOnDatabase.Models
{
    public class Teacher : People
    {
        public int TitleId { get; set; }

        public Title Title { get; set; } = null!;
    }
}