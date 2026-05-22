using System.Collections.Generic;
using static P5WebApp.Models.Entities.Photo;

namespace P5WebApp.Models.Entities
{
    public partial class ShortAdd
    {

        // Input fields of ShortAdd class
        public required int Id { get; set; }

        public string ?Description { get; set; }

        public DateOnly ShortAddAvailabilityDate { get; set; }

        public DateOnly ShortAddDateSold { get; set; }

        public bool ShortAddSold { get; set; }

        // Virtual coupling.
        public virtual int ShortAddCarId { get; set; }

        public double ShortAddBuyPrice { get; set; }


        public const double Margin = 500;

        public double ShortAddSellingPrice { get; set; }

        // Virtual coupling.
        public virtual ICollection<Photo> ShortAddPhotosList { get; set; } = new List<Photo>();


        // Virtual couplings below to be able to override children 

        public required virtual Car Car { get; set; }


    }
}