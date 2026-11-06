using Microsoft.EntityFrameworkCore;
using MovieTicketBookingAPI.Entities;

namespace MovieTicketBookingAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Theatre> Theatres { get; set; }

        public DbSet<Screen> Screens { get; set; }

        public DbSet<Seat> Seats { get; set; }

        public DbSet<Show> Shows { get; set; }

        public DbSet<ShowSeat> ShowSeats { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<BookingSeat> BookingSeats { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Decimal precision
            modelBuilder.Entity<Booking>()
                .Property(b => b.TotalAmount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<BookingSeat>()
                .Property(bs => bs.Price)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Show>()
                .Property(s => s.TicketPrice)
                .HasPrecision(18, 2);

            // Theatre - Screen
            modelBuilder.Entity<Screen>()
                .HasOne(s => s.Theatre)
                .WithMany()
                .HasForeignKey(s => s.TheatreId)
                .OnDelete(DeleteBehavior.NoAction);

            // Screen - Seat
            modelBuilder.Entity<Seat>()
                .HasOne(s => s.Screen)
                .WithMany()
                .HasForeignKey(s => s.ScreenId)
                .OnDelete(DeleteBehavior.NoAction);

            // Movie - Show
            modelBuilder.Entity<Show>()
                .HasOne(s => s.Movie)
                .WithMany()
                .HasForeignKey(s => s.MovieId)
                .OnDelete(DeleteBehavior.NoAction);

            // Screen - Show
            modelBuilder.Entity<Show>()
                .HasOne(s => s.Screen)
                .WithMany()
                .HasForeignKey(s => s.ScreenId)
                .OnDelete(DeleteBehavior.NoAction);

            // Show - ShowSeat
            modelBuilder.Entity<ShowSeat>()
                .HasOne(ss => ss.Show)
                .WithMany()
                .HasForeignKey(ss => ss.ShowId)
                .OnDelete(DeleteBehavior.NoAction);

            // Seat - ShowSeat
            modelBuilder.Entity<ShowSeat>()
                .HasOne(ss => ss.Seat)
                .WithMany()
                .HasForeignKey(ss => ss.SeatId)
                .OnDelete(DeleteBehavior.NoAction);

            // Show - Booking
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Show)
                .WithMany()
                .HasForeignKey(b => b.ShowId)
                .OnDelete(DeleteBehavior.NoAction);

            // Booking - BookingSeat
            modelBuilder.Entity<BookingSeat>()
                .HasOne(bs => bs.Booking)
                .WithMany(b => b.BookingSeats)
                .HasForeignKey(bs => bs.BookingId)
                .OnDelete(DeleteBehavior.NoAction);

            // ShowSeat - BookingSeat
            modelBuilder.Entity<BookingSeat>()
                .HasOne(bs => bs.ShowSeat)
                .WithMany()
                .HasForeignKey(bs => bs.ShowSeatId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
    }