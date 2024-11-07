namespace Ticket_Train.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int? NumTickets { get; set; }

        public virtual Passenger? Passenger { get; set; }
        public virtual Schedule? Schedule { get; set; }
    }
}
