namespace P5WebApp.Models.Entities
{
    public partial class Photo : Add
    {

        // Input fields of Photo class
        public int PhotoId { get; set; }

        public string? PhotoPath { get; set; }

        public ICollection<PhotoListForAnAdd>? PhotoListOfAnAdd { get; set; }



        public class PhotoList
        {
            public int PhotoListId { get; set; }

            public ICollection<PhotoListForAnAdd>? PhotoListOfAnAdd { get; set; }

        }

        // Creating many to many relationship between a Fix and its FixList
        public class PhotoListForAnAdd
        {
            public int ID { get; set; }

            public int PhotoId { get; set; }
            public Photo? Photo { get; set; }


            public int PhotoListId { get; set; }
            public PhotoList? PhotoList { get; set; }
        }
    }
}
