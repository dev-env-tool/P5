namespace P5WebApp.Models.Entities
{
    public partial class Add
    {
        public int Id { get; set; }

        public DateOnly AddAvailabilityDate { get; set; }

        public DateOnly AddDateSold { get; set; }

        public bool AddSold { get; set; }
    }
}
