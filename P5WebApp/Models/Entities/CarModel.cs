namespace P5WebApp.Models.Entities
{
    public class CarModel
    {
        public int Id { get; set; }
        public string ?Name { get; set; }

        public required int AssociatedBrandId { get; set; }
        public virtual Brand AssociatedBrand { get; set; }

        public virtual ICollection<FinishType>? FinishTypes { get; set; } = new List<FinishType>();

    }
}
