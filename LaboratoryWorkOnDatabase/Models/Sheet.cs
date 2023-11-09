namespace LaboratoryWorkOnDatabase.Models
{
    public class Sheet
    {
        public int SheetId { get; set; }

        public int StudentId { get; set; }

        public int PlanId { get; set; }

        public int SheetPoint { get; set; }

        public DateOnly SheetDate { get; set; }
    }
}