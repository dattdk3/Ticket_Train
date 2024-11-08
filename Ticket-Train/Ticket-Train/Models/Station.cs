namespace Ticket_Train.Models
{
    public partial class Station
    {
        public Station()
        {
            RouteDestinations = new HashSet<Route>();
            RouteOrigins = new HashSet<Route>();
        }

        public int StationId { get; set; }
        public string? Name { get; set; }

        public bool? IsActive { get; set; } = true;

        public virtual ICollection<Route> RouteDestinations { get; set; }
        public virtual ICollection<Route> RouteOrigins { get; set; }

    }
}
