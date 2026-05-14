using static P5WebApp.Models.Entities.Photo;

namespace P5WebApp.Models.Entities
{
    public class Model : Vehicle
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public class ModelList
        {
            public int ModelListId { get; set; }
            ICollection<Model>? ModelListForVehicle { get; set; }
        }
        public ICollection<BrandModel>? BrandAndModelListForVehicle { get; set; }

        public class BrandModel
        {
            public int ID { get; set; }

            public int BrandId { get; set; }
            public Brand? Brand { get; set; }


            public int ModelListId { get; set; }
            public ModelList? ModelList { get; set; }
        }

    }
}
