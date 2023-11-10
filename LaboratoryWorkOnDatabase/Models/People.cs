namespace LaboratoryWorkOnDatabase.Models
{
    public class People
    {
        public int Id { get; set; }

        public string LastName { get; set; } = null!;

        public string? MiddleName { get; set; }

        public string FirstName { get; set; } = null!;

        public DateOnly DateBorn { get; set; }

        public bool Sex { get; set; }
    }
}