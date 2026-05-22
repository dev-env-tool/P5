namespace P5WebApp.Models.Entities
{
    public class Photo
    {

        // Input fields of Photo class
        public required int PhotoId { get; set; }

        public required string PhotoPath { get; set; }

        // Foreign Key
        public required int AssociatedShortAddId { get; set; }

        public required virtual ShortAdd AssociatedShortAdd { get; set; }
    }
}
