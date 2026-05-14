using static P5WebApp.Models.Entities.Photo;

namespace P5WebApp.Models.Entities
{
    public partial class Fix : Vehicle
    {

        // Input fields of Fix class

        public int FixId { get; set; }

        public string? FixDescription { get; set; }

        public DateOnly FixDate { get; set; }

        public double FixCost { get; set; }

        public ICollection<FixListForAnAdd> ?FixListOfAnAdd { get; set; }



        public class FixList
        {
            public int FixlistId { get; set; }

            public ICollection<FixListForAnAdd> ?FixListOfAnAdd { get; set; }

        }

        // Creating many to many relationship between a Fix and its FixList
        public class FixListForAnAdd
        {
            public int FixID { get; set; }

            public int FixId { get; set; }
            public Fix ?Fix {  get; set; }


            public int FixListId { get; set; }
            public FixList? FixList { get; set; }
        }
    }
}
