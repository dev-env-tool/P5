using Microsoft.CodeAnalysis.CSharp.Syntax;
using P5WebApp.Models.ViewModels;

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

        //public virtual List<FixViewModel> CarFixesViewModel { get; set; } = new List<FixViewModel>();

        public virtual ICollection<Fix> CarFixesList { get; set; } = new List<Fix>();


        public string? CarDescription { get; set; }


        public DateOnly? CarAddAvailabilityDate { get; set; }

        public bool CarPublished { get; set; }

        public DateOnly? CarDateSold { get; set; }


        public const double CarMargin = 500;


        public double CarSellingPrice { get; set; }
    }
}


