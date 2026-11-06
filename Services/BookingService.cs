
using MovieTicketBookingAPI.DTOs;
using MovieTicketBookingAPI.Entities;
using MovieTicketBookingAPI.Exceptions;
using MovieTicketBookingAPI.Interfaces;

namespace MovieTicketBookingAPI.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        // Get all bookings
        public async Task<List<BookingResponseDto>> GetAllBookingsAsync()
        {
            var bookings = await _bookingRepository.GetAllAsync();

            return bookings.Select(b => new BookingResponseDto
            {
                BookingId = b.BookingId,
                ShowId = b.ShowId,
                BookingDate = b.BookingDate,
                TotalAmount = b.TotalAmount,
                Status = b.Status
            }).ToList();
        }

        // Get booking by ID
        public async Task<BookingResponseDto?> GetBookingByIdAsync(int id)
        {
            var booking = await _bookingRepository.GetByIdAsync(id);

            if (booking == null)
                return null;

            return new BookingResponseDto
            {
                BookingId = booking.BookingId,
                ShowId = booking.ShowId,
                BookingDate = booking.BookingDate,
                TotalAmount = booking.TotalAmount,
                Status = booking.Status,

                Seats = booking.BookingSeats.Select(bs => new BookingSeatResponseDto
                {
                    SeatId = bs.ShowSeat.SeatId,
                    RowName = bs.ShowSeat.Seat.RowName,
                    SeatNumber = bs.ShowSeat.Seat.SeatNumber,
                    SeatType = bs.ShowSeat.Seat.SeatType,
                    Price = bs.Price
                }).ToList()
            };
        }
        // Create booking
        public async Task<BookingResponseDto> CreateBookingAsync(
            BookingRequestDto request)
        {
            if (request.SeatIds == null || request.SeatIds.Count == 0)
                throw new BadRequestException(
                    "Please select at least one seat.");

            if (request.SeatIds.Count != request.SeatIds.Distinct().Count())
                throw new BadRequestException(
                    "Duplicate seat selection is not allowed.");

            var show = await _bookingRepository.GetShowByIdAsync(
                request.ShowId);

            if (show == null)
                throw new NotFoundException("Show not found.");

            var showSeats =
                await _bookingRepository.GetAvailableShowSeatsAsync(
                    request.ShowId, request.SeatIds);

            if (showSeats.Count != request.SeatIds.Count)
                throw new BadRequestException(
                    "One or more selected seats are unavailable or invalid.");

            decimal totalAmount = show.TicketPrice * showSeats.Count;

            Booking booking = new Booking
            {
                ShowId = request.ShowId,
                BookingDate = DateTime.Now,
                TotalAmount = totalAmount,
                Status = "Confirmed"
            };

            foreach (var showSeat in showSeats)
            {
                BookingSeat bookingSeat = new BookingSeat
                {
                    ShowSeat = showSeat,
                    Price = show.TicketPrice
                };

                booking.BookingSeats.Add(bookingSeat);

                showSeat.Status = "Booked";
            }

            await _bookingRepository.AddAsync(booking);

            return new BookingResponseDto
            {
                BookingId = booking.BookingId,
                ShowId = booking.ShowId,
                BookingDate = booking.BookingDate,
                TotalAmount = booking.TotalAmount,
                Status = booking.Status
            };
        }

        // Cancel booking
        public async Task CancelBookingAsync(int id)
        {
            var booking = await _bookingRepository.GetByIdAsync(id);

            if (booking == null)
                throw new NotFoundException("Booking not found.");

            if (booking.Status == "Cancelled")
                throw new BadRequestException(
                    "Booking is already cancelled.");

            booking.Status = "Cancelled";

            foreach (var bookingSeat in booking.BookingSeats)
            {
                bookingSeat.ShowSeat.Status = "Available";
            }

            await _bookingRepository.UpdateAsync(booking);
        }
    }
}
