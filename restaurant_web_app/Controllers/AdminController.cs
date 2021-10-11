using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Booking.Commands;
using Application.Booking.Queries;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using restaurant_web_app.Enums;

namespace restaurant_web_app.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        protected ISender Mediator { get; }

        public AdminController(ILogger<HomeController> logger, ISender mediator)
        {
            _logger = logger;
            Mediator = mediator;
        }

        public async Task<IActionResult> Index(BookingStatus status, ActionType action, bool applyFilter = false)
        {
            
            //GetBookingFilteredQuery query = new GetBookingFilteredQuery(status,applyFilter);
            GetAllBookingQuery query2 = new GetAllBookingQuery();
            GetBookingsVm bookingVm = await Mediator.Send(query2);
                //query.Execute();

            switch (action)
            {
                case ActionType.Info:
                    bookingVm.AlertData = AlertData.MakeInfoAlert();
                break;
                case ActionType.Created:
                    bookingVm.AlertData = AlertData.MakeCreateSuccessAlert();
                    break;
                case ActionType.Updated:
                    bookingVm.AlertData = AlertData.MakeUpdateSuccessAlert();
                    break;
                case ActionType.Deleted:
                    bookingVm.AlertData = AlertData.MakeRemovedDataAlert();
                    break;
            }

            return View("Index",bookingVm);
        }

        public IActionResult BookingOptions()
        {
            return View();
        }

        public async Task<IActionResult> BookingEdit(int id)
        {
            GetBookingItemQuery query = new GetBookingItemQuery
            {
                Id = id
            };
            BookingItem item = await Mediator.Send(query);

            return View(item);
        }

        public async Task<IActionResult> BookingDetail(int id)
        {
            GetBookingItemQuery query = new GetBookingItemQuery
            {
                Id = id
            };
            BookingItem item = await Mediator.Send(query);

            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> BookingUpdate([Bind] BookingItem item)
        {
            UpdateBookingItemCommand command = new UpdateBookingItemCommand(item);
            await Mediator.Send(command);

            return await Index(BookingStatus.Pending, ActionType.Updated);
        }

        [HttpGet]
        public IActionResult AddBooking()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBooking([Bind] BookingItem item)
        {
            //BookingItem item = new GetBookingDetail(id).Execute();
            //todo bug with BookingStatus always 0
            CreateBookingItemCommand command = new CreateBookingItemCommand(item);
            BookingItem itemCreated = await Mediator.Send(command);

            return await Index(BookingStatus.Pending, ActionType.Created);
        }

       public async Task<IActionResult> DeleteBooking(int id)
        {
            DeleteBookingItemCommand command = new DeleteBookingItemCommand(id);
            await Mediator.Send(command);
            return await Index(BookingStatus.Pending, ActionType.Deleted);
        }
    }
}
