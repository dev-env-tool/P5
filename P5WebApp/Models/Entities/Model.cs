using static P5WebApp.Models.Entities.Photo;

namespace P5WebApp.Models.Entities
{
    public class Model : Vehicle
    {

        public int Id { get; set; }
        public string? Name { get; set; }

        public int AsociatedBrandId { get; set; }
        public Brand ?AssociatedBrand { get; set; }

    }
}
