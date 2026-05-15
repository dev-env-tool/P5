namespace P5WebApp.Models.Entities
{
    public partial class Photo : Add
    {

        // Input fields of Photo class
        public int PhotoId { get; set; }

        public string ?PhotoPath { get; set; }

        // Foreign Key
        public int AssociatedAddId { get; set; }

        public virtual Add ?AssocitedAdd { get; set; }
    }
}
