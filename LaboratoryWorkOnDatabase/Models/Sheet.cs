namespace LaboratoryWorkOnDatabase.Models
{
    public class Sheet
    {
        public int SheetId { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; } = null!;

        public int PlanId { get; set; }

        public Plan Plan { get; set; } = null!;

        public int SheetPoint { get; set; }

        public DateOnly SheetDate { get; set; }
    }
}