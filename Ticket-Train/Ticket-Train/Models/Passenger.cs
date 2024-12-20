﻿namespace Ticket_Train.Models
{
    public partial class Passenger
    {
        public Passenger()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int PassengerId { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }

    }
}
