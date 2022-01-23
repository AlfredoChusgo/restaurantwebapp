using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Application.Booking.Commands;
using Application.Contact.Commands;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using restaurant_web_app.Enums;
using restaurant_web_app.Models;
using restaurant_web_app.ViewModels;

namespace restaurant_web_app.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly ILogger<RestaurantController> _logger;
        protected ISender Mediator { get; }
        public RestaurantController(ILogger<RestaurantController> logger, ISender mediator)
        {
            Mediator = mediator;
            _logger = logger;
        }


        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult RestaurantEmailConfirmation()
        {
            EmailConfirmationViewModel model = new EmailConfirmationViewModel
            {
                Title = "Reserva",
                Description = "Reserva confirmada con exito"
            };
            return View(model);
        }

        public IActionResult Index()
        {
            return View("Home");
        }

        public IActionResult Home()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
        public IActionResult Menu()
        {
            return View();
        }        
        public IActionResult Contact()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ContactUsSend([Bind] ContactUs item)
        {
            //BookingItem item = new GetBookingDetail(id).Execute();
            //todo bug with BookingStatus always 0
            CreateContactUsCommand command = new CreateContactUsCommand(item);

            ContactUs itemCreated = await Mediator.Send(command);

            return View("ContactUsSend");
        }
    }
}
