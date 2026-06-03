namespace P5WebApp.Models.Entities
{
    public class FinishType
    {
        public int FinishTypeId { get; set; }

        public string ?FinishTypeName { get; set; }

        public List <int>? AssociatedCarModelIds { get; set; } = new List<int>();

        public List<int>? AssociatedBrandsIds { get; set; } = new List<int>();

        public virtual ICollection<CarModel>? CarModels { get; set; } = new List<CarModel>();

        public virtual ICollection<Brand>? Brands { get; set; } = new List<Brand>();
    }
}
