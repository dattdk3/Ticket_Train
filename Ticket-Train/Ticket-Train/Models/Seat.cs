namespace Ticket_Train.Models
{


        public class Seat
        {
            public int SeatId { get; set; }           // Primary Key
            public int TrainId { get; set; }          // Foreign Key to Train
            public int ClassId { get; set; }          // Foreign Key to Class, nếu có phân loại ghế
            public int ScheduleId { get; set; }       // Foreign Key to Schedule, liên kết với chuyến đi cụ thể
            public string Status { get; set; }        // Trạng thái ghế: "Available", "Booked", "Reserved", etc.
            public decimal Price { get; set; }
            // Navigation properties
            public Train Train { get; set; }
            public Class Class { get; set; }
            public Schedule Schedule { get; set; }


        }


}
