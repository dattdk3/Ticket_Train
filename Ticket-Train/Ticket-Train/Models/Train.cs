using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "Trường này là bắt buộc.")]
        [RegularExpression(@"^(?=.*\d)[A-Za-z\d]{8}$", ErrorMessage = "Dữ liệu phải có đúng 8 ký tự và chứa ít nhất một số.")]
        public string Description { get; set; }
        public List<Seat> Seats { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }

    }
}
