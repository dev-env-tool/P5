namespace P5WebApp.Models.Entities
{
    public class FinishType : Car
    {
        public required int FinishTypeId { get; set; }

        public required string FinishTypeName { get; set; }


        public required int AssociatedCarId { get; set; }

        public required virtual Car AssociatedCar { get; set; }


        public required int AssociatedCarModelId { get; set; }

        public required virtual CarModel AssociatedCarModel { get; set; }

        public required virtual ICollection<CarModel>? CarModels { get; set; } = [];



        public required int AssociatedBrandId { get; set; }

        public required virtual Brand AssociatedBrand { get; set; }

    }
}
