using System.Collections.Generic;

namespace P5WebApp.Models.Entities
{
    public partial class Add
    {

        private readonly List<AddLine>? _addList;

        public Add() 
        { 
            _addList = new List<AddLine>();
        }
        public int Id { get; set; }

        public DateOnly AddAvailabilityDate { get; set; }

        public DateOnly AddDateSold { get; set; }

        public bool AddSold { get; set; }

        public int AddCarId { get; set; }

        public double AddBuyPrice { get; set; }


        public const double Margin = 500;

        public double AddSellingPrice { get; set; }

        public virtual ICollection<Photo> ?AddPhotosList { get; set; }

        
        // Virtual couplings below

        public virtual Car ?Car { get; set; }


        public class AddLine
        {
            public int AddLineId { get; set; }

        }

    }
}