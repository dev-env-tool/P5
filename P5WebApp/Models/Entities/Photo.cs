namespace P5WebApp.Models.Entities
{
    public class Photo
    {
        // Input fields of Photo class
        public int PhotoId { get; set; }

        public string PhotoName { get; set; }
        public string PhotoPath { get; set; }

        // Foreign Key
        public int AssociatedCarId { get; set; }
    }
}
