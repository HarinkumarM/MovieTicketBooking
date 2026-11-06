namespace MovieTicketBookingAPI.Entities
{
    public class Show
    {
        public int ShowId { get; set; }

        public int MovieId { get; set; }

        public int ScreenId { get; set; }

        public DateTime ShowDateTime { get; set; }

        public decimal TicketPrice { get; set; }

        // Navigation Properties
        public Movie Movie { get; set; } = null!;

        public Screen Screen { get; set; } = null!;
    }
}