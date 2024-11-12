namespace Ticket_Train.Models
{
    public partial class Train
    {
        public Train()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int TrainId { get; set; }
        public string Name { get; set; } = null!;

        public bool? IsActive { get; set; } = true;
        // Danh sách ghế liên quan đến tàu này
        //public string description { get; set; } = null;
        public List<Seat> Seats { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }

    }
}
