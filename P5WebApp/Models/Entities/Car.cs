using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace P5WebApp.Models.Entities
{
    public class Car
    {
        public required int CarId { get; set; }


        public string ?CarVinCode { get; set; }

        public DateOnly CarYear { get; set; }

        public DateOnly CarBuyDate { get; set; }

        public double CarBuyPrice { get; set; }

        public int CarBrandId { get; set; }

        public virtual Brand? Brand { get; set; }

        public int CarModelId { get; set; }

        public virtual CarModel ?CarModel { get; set; }

        public int CarFinishTypeId { get; set; }

        public virtual FinishType ?FinishType { get; set; }

        // Virtual couplings below to be able to override children parameters from parent class

        public ICollection<Fix> CarFixesList { get; set; } = new List<Fix>();

        public int AssociatedShortAddId { get; set; }

        public virtual ShortAdd ?AssociatedShortAdd { get; set; }
    }
}


