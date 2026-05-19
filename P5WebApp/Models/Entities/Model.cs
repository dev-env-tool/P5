namespace P5WebApp.Models.Entities
{
    public class Model : Vehicle
    {

        public int Id { get; set; }
        public string? Name { get; set; }

        public int AsociatedBrandId { get; set; }
        public virtual Brand ?AssociatedBrand { get; set; }

    }
}
