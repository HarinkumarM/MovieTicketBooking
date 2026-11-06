using System.Text.Json.Serialization;
namespace MovieTicketBookingAPI.Entities
{
    public class BookingSeat
    {
        public int BookingSeatId { get; set; }

        public int BookingId { get; set; }

        public int ShowSeatId { get; set; }

        public decimal Price { get; set; }

        // Navigation Properties
        [JsonIgnore]
        public Booking Booking { get; set; } = null!;
        public ShowSeat ShowSeat { get; set; } = null!;
    }
}