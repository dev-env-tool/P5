namespace P5WebApp.Models.Entities
{
    public class CarModel
    {
        public required int Id { get; set; }
        public string ?Name { get; set; }

        public required int AssociatedBrandId { get; set; }
        public required virtual Brand AssociatedBrand { get; set; }

        public virtual ICollection<FinishType>? FinishTypes { get; set; } = new List<FinishType>();

    }
}
