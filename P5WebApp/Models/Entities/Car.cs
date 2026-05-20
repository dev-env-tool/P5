using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace P5WebApp.Models.Entities
{
    public class Car
    {
        public int CarId { get; set; }


        public required string CarVinCode { get; set; }

        public required DateOnly CarYear { get; set; }

        public required DateOnly CarBuyDate { get; set; }

        public required double CarBuyPrice { get; set; }

        public required int CarBrandId { get; set; }

        public required virtual Brand? Brand { get; set; }

        public required int CarModelId { get; set; }

        public required virtual CarModel CarModel { get; set; }

        public required int CarFinishTypeId { get; set; }

        public required virtual FinishType FinishType { get; set; }

        // Virtual couplings below to be able to override children parameters from parent class

        public required virtual ICollection<Fix> CarFixesList { get; set; } = [];

        public required int AssociatedShortAddId { get; set; }

        public required virtual ShortAdd AssociatedShortAdd { get; set; }
    }
}


