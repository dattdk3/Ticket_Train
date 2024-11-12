namespace Ticket_Train.Models
{

    public class Seat
    {
        public int SeatId { get; set; }           // Primary Key
        public int TrainId { get; set; }          // Foreign Key to Train
        public int? ScheduleId { get; set; } = null;     // Foreign Key to Schedule, liên kết với chuyến đi cụ thể
        public bool Status { get; set; }        // Trạng thái ghế: "Available", "Booked", "Reserved", etc.
        public decimal Price { get; set; }

        public bool? IsActive { get; set; } = true;
        // Navigation properties
        public Train Train { get; set; }

        public Schedule Schedule { get; set; }
    }
}
