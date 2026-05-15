using System.Collections.Generic;
using static P5WebApp.Models.Entities.Photo;

namespace P5WebApp.Models.Entities
{
    public partial class Add
    {
       

        // Input fields of Add class
        public int Id { get; set; }

        public DateOnly AddAvailabilityDate { get; set; }

        public DateOnly AddDateSold { get; set; }

        public bool AddSold { get; set; }

        public int AddCarId { get; set; }

        public double AddBuyPrice { get; set; }


        public const double Margin = 500;

        public double AddSellingPrice { get; set; }


        // Virtual couplings below to be able to override children parameters from parent class

        public virtual Car? Car { get; set; }

        public virtual ICollection<Photo>? AddPhotosList { get; set; } = [];
    }
}