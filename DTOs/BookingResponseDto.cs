namespace MovieTicketBookingAPI.DTOs
{
    public class BookingResponseDto
    {
        public int BookingId { get; set; }
        public int ShowId { get; set; }
        public DateTime BookingDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; } = string.Empty;

        public List<BookingSeatResponseDto> Seats { get; set; }
            = new List<BookingSeatResponseDto>();
    }
}