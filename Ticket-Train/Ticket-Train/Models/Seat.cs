namespace Ticket_Train.Models
{

        public class Seat
        {
            public int SeatId { get; set; }           // Primary Key
            public int TrainId { get; set; }          // Foreign Key to Train     
            public string Status { get; set; }        // Trạng thái ghế: "Available", "Booked", "Reserved", etc.
            public decimal Price { get; set; }
        //public string NewColumn { get; set; }
        public bool? IsActive { get; set; } = true;
        // Navigation properties
        public Train Train { get; set; }

        }
}
