namespace P5WebApp.Models.Entities
{
    public class CarModel : Car
    {
        public required int Id { get; set; }
        public required string Name { get; set; }

        public required int AsociatedBrandId { get; set; }
        public required virtual Brand ?AssociatedBrand { get; set; }

    }
}
