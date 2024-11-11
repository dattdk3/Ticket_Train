namespace Ticket_Train.Models
{
    public partial class Routes
    {
        public Routes()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int RouteId { get; set; }
        public int? OriginId { get; set; }
        public int? DestinationId { get; set; }
        public int Distance { get; set; }
        public bool? IsActive { get; set; } = true;

        public virtual Station? Destination { get; set; }
        public virtual Station? Origin { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }

    }
}
