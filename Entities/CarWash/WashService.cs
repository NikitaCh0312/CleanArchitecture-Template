namespace Entities
{
    public class WashService : EntityBase
    {
        public bool Enabled { set; get; } = true;
        public string Name { set; get; }
        public int Price { set; get; }
        public int DurationMinutes { set; get; }
        public string Description { set; get; }

        public int CarWashId { set; get; }
        public CarWash CarWash { set; get; }
    }
}
