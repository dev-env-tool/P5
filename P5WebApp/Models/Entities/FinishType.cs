namespace P5WebApp.Models.Entities
{
    public class FinishType : Car
    {
        public required int FinishTypeId { get; set; }

        public required string FinishTypeName { get; set; }


        public required int AssociatedModelId { get; set; }

        public required virtual CarModel AssociatedCarModel { get; set; }

        public required int AssociatedBrandlId { get; set; }

        public required virtual Brand AssociatedBrand { get; set; }

    }
}
