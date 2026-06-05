using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace P5WebApp.Models.Entities
{
    public class Car
    {
        public int CarId { get; set; }


        public string ?CarVinCode { get; set; }

        public DateOnly? CarYear { get; set; }

        public DateOnly CarBuyDate { get; set; }

        public double CarBuyPrice { get; set; }

        public int CarBrandId { get; set; }

        public int CarModelId { get; set; }

        public int CarFinishTypeId { get; set; }

        public List<int>? AssociatedFixIds { get; set; } = new List<int>();

        public ICollection<Fix> CarFixesList { get; set; } = new List<Fix>();

    }
}


