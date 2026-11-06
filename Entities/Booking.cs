namespace MovieTicketBookingAPI.Entities
{
    public class Booking
    {
        public int BookingId { get; set; }

        public int ShowId { get; set; }

        public DateTime BookingDate { get; set; }

        public decimal TotalAmount { get; set; }

        public string Status { get; set; } = "Confirmed";

        // Navigation Properties
        public Show Show { get; set; } = null!;

        public ICollection<BookingSeat> BookingSeats { get; set; }
            = new List<BookingSeat>();
    }
}