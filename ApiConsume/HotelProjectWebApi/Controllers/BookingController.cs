using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProjectWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddBooking(Booking booking)
        {
            _bookingService.TInsert(booking);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBooking(int id)
        {
            var values = _bookingService.TGetByID(id);
            _bookingService.TDelete(values);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateBooking(Booking booking)
        {
            _bookingService.TUpdate(booking);
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var values = _bookingService.TGetByID(id);
            return Ok(values);
        }


        [HttpGet("BookingStatusChangeApproved/{id}")]
        public IActionResult BookingStatusChangeApproved(int id)
        {
            _bookingService.TBookingStatusChangeApproved(id);
            return Ok("Rezervasyon Durumu Değiştirildi");
        }

        [HttpGet("BookingStatusChangeCancelled/{id}")]
        public IActionResult BookingStatusChangeCancelled(int id)
        {
            _bookingService.TBookingStatusChangeCancelled(id);
            return Ok("Rezervasyon Durumu Değiştirildi");
        }

        [HttpGet("BookingStatusChangeWait/{id}")]
        public IActionResult BookingStatusChangeWait(int id)
        {
            _bookingService.TBookingStatusChangeWait(id);
            return Ok("Rezervasyon Durumu Değiştirildi");
        }
    }
}
