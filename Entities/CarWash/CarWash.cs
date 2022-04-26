namespace Entities
{
    using System.Collections.Generic;

    public class CarWash: EntityBase
    {
        public string Phone { set; get; }

        public string Name { set; get; }

        public string Longitude { set; get; }

        public string Latitude { set; get; }

        public string Location { set; get; }

        public string StartWorkTime { set; get; }

        public string EndWorkTime { set; get; }

        public int BoxesQuantity { set; get; }

        public List<WashService> Services { set; get; }

        public List<User> Users { set; get; }
    }
}
