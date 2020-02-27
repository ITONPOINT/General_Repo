using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnPointSport.Core.Models;
using OnPointSport.Core.Interfaces;

namespace adminlte.Controllers
{
    public class BookingsController : Controller
    {
        private IBookingRepository bookingRepository;
        private ICustomerRepository customerRepository;
        private IProductServiceRepository productServiceRepository;
        public BookingsController(IBookingRepository bookingRepository, ICustomerRepository customerRepository, IProductServiceRepository productServiceRepository)
        {
            this.bookingRepository = bookingRepository;
            this.customerRepository = customerRepository;
            this.productServiceRepository = productServiceRepository;
        }
        // GET: Bookings
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BookingsInformation()
        {
            var bookings = bookingRepository.GetBookings();
            return View(bookingRepository);
        }
        [HttpGet]
        public ActionResult BookingsInformation(Boolean Active = true, string search = "")
        {
            var bookings = bookingRepository.GetFullBookings(bookingRepository.GetBookings(), customerRepository).Where(x => (x.Code.Contains(search))
            && x.Active == Active);
            return View(bookings);
        }
        public ActionResult CreateBooking(string Code = "")
        {
            var model = new Booking();
            var booking = bookingRepository.GetByCode(Code);
            var customers = customerRepository.GetCustomers().Where(x => x.Active == true).ToList();
            var productServices = productServiceRepository.GetProductServices().Where(x => x.Active == true).ToList();

            ViewBag.customers = customers;
            ViewBag.productServices = productServices;
            if (booking != null)
            {
                model.Id = booking.Id;
                model.Code = booking.Code;
                model.CustomerCode = booking.CustomerCode;
                model.BookingDate = booking.BookingDate;
                model.BookingDebutTime = booking.BookingDebutTime;
                model.BookingFinTime = booking.BookingFinTime;
                model.Active = booking.Active;
                model.Description = booking.Description;
                return View(model);
            }
            return View();
        }

        [HttpPost]
        public ActionResult CreateBooking(Booking model)
        {
            if(ModelState.IsValid)
            {
                var booking = bookingRepository.GetByCode(model.Code) == null ? new OnPointSport.Core.Domain.Booking() : bookingRepository.GetByCode(model.Code);
                booking.Code = booking.Id == 0 ? GetCode() : model.Code;
                booking.CustomerCode = model.CustomerCode;
                booking.BookingDate = model.BookingDate;
                booking.BookingDebutTime = model.BookingDebutTime;
                booking.BookingFinTime = model.BookingFinTime;
                booking.Active = model.Active;
                booking.Description = model.Description;

                bookingRepository.Save(booking);
                return Redirect("BookingsInformation");
            }
            return View(model);
        }
        private string GetCode()
        {
            var lastBookings = bookingRepository.GetBookings().Count == 0 ? null : bookingRepository.GetBookings().Last();
            string code = lastBookings == null ? (1).ToString("0000000000") : (Convert.ToInt64(lastBookings.Code) + 1).ToString("0000000000");
            return code;
        }
    }
}