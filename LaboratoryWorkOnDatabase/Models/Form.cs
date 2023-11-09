namespace LaboratoryWorkOnDatabase.Models
{
    public class Form
    {
        public int FormId { get; set; }

        public DateOnly FormCreatedDate { get; set; }

        public string FormLetter { get; set; } = null!;

        public int? TeacherId { get; set; }
    }
}