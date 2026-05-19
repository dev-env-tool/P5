using System.Collections.Generic;
using static P5WebApp.Models.Entities.Photo;

namespace P5WebApp.Models.Entities
{
    public partial class Add
    {

        // Input fields of Add class
        public int Id { get; set; }

        public string ?Title { get; set; }

        public string ?Description { get; set; }

        public DateOnly AddAvailabilityDate { get; set; }

        public DateOnly AddDateSold { get; set; }

        public bool AddSold { get; set; }

        // Virtual coupling.
        public virtual int AddVehicleId { get; set; }

        public double AddBuyPrice { get; set; }


        public const double Margin = 500;

        public double AddSellingPrice { get; set; }

        // Virtual coupling.
        public virtual ICollection<Photo>? AddPhotosList { get; set; } = [];


        // Virtual couplings below to be able to override children 

        public virtual Car? Car { get; set; }


    }
}