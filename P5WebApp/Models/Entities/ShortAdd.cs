using System.Collections.Generic;
using static P5WebApp.Models.Entities.Photo;

namespace P5WebApp.Models.Entities
{
    public partial class ShortAdd
    {

        // Input fields of ShortAdd class
        public required int Id { get; set; }

        public required string Description { get; set; }

        public required DateOnly ShortAddAvailabilityDate { get; set; }

        public required DateOnly ShortAddDateSold { get; set; }

        public required bool ShortAddSold { get; set; }

        // Virtual coupling.
        public required virtual int ShortAddCarId { get; set; }

        public required double ShortAddBuyPrice { get; set; }


        public const double Margin = 500;

        public required double ShortAddSellingPrice { get; set; }

        // Virtual coupling.
        public required virtual ICollection<Photo> ShortAddPhotosList { get; set; } = [];


        // Virtual couplings below to be able to override children 

        public required virtual Car Car { get; set; }


    }
}