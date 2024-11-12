namespace Ticket_Train.Models
{
    public partial class Schedule
    {
        public Schedule()
        {
            Reservations = new HashSet<Reservation>();

        }

        public int ScheduleId { get; set; }
        public int TrainId { get; set; }
        public int RouteId { get; set; }
        public DateTime DepartureTime { get; set; }
        public bool? IsActive { get; set; } = true;

        public virtual Routes Route { get; set; } = null!;
        public virtual Train Train { get; set; } = null!;
        public virtual ICollection<Reservation> Reservations { get; set; }


    }
}
