namespace MovieTicketBookingAPI.DTOs
{
    public class BookingRequestDto
    {
        public int ShowId { get; set; }

        public List<int> SeatIds { get; set; } = new List<int>();
    }
}