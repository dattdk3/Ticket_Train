namespace Ticket_Train.Models
{
    public partial class Station
    {
        public Station()
        {
            RouteDestinations = new HashSet<Routes>();
            RouteOrigins = new HashSet<Routes>();
        }

        public int StationId { get; set; }
        public string? Name { get; set; }

        public bool? IsActive { get; set; } = true;

        public virtual ICollection<Routes> RouteDestinations { get; set; }
        public virtual ICollection<Routes> RouteOrigins { get; set; }

    }
}
