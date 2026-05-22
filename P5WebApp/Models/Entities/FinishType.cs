namespace P5WebApp.Models.Entities
{
    public class FinishType
    {
        public required int FinishTypeId { get; set; }

        public string ?FinishTypeName { get; set; }

        public virtual ICollection<CarModel>? CarModels { get; set; } = new List<CarModel>();

        public virtual ICollection<Brand>? Brands { get; set; } = new List<Brand>();
    }
}
