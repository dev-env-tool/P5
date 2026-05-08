namespace P5WebApp.Models.Entities
{
    public partial class Fix : Vehicle
    {
        public int FixId { get; set; }

        public string? FixDescription { get; set; }

        public DateOnly FixDate { get; set; }

        public double FixCost { get; set; }
    }
}
