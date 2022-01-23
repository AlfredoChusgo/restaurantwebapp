﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Booking.Commands;
using Application.Booking.Queries;
using Application.BookingAvailableSchedules.Query;
using Application.BookingOptions.BasicScheduleRule.Command;
using Application.BookingOptions.BasicScheduleRule.Query;
using Application.BookingOptions.Commands;
using Application.BookingOptions.ExceptionBookingRule.Command;
using Application.BookingOptions.ExceptionBookingRule.Query;
using Application.BookingOptions.Queries;
using Application.Common.Interfaces;
using Application.Contact.Commands;
using Application.Contact.Queries;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using restaurant_web_app.Enums;
using restaurant_web_app.Models;
using restaurant_web_app.ViewModels;

namespace restaurant_web_app.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        protected ISender Mediator { get; }
        private ISecurityTextService SecurityTextService { get; }

        public AdminController(ILogger<HomeController> logger, ISender mediator, ISecurityTextService securityTextService)
        {
            _logger = logger;
            Mediator = mediator;
            SecurityTextService = securityTextService;
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

        public async Task<IActionResult> BookingOptions()
        {
            BookingOptionsVm vm = await Mediator.Send(new GetBookingOptionsQuery());
            
            BookingOptionsViewModel viewModel = new BookingOptionsViewModel(vm);

            return View("BookingOptions",viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBookingOptions(UpdateBookingOptionCommand bookingOption)
        {
            BookingOption result = await Mediator.Send(bookingOption);

            return await BookingOptions();
        }

        #region Booking

        public async Task<IActionResult> BookingEdit(int id)
        {
            BookingConfigurationVm vm = await Mediator.Send(new GetBookingConfigurationQuery());
            GetBookingItemQuery query = new GetBookingItemQuery
            {
                Id = id
            };
            BookingItem item = await Mediator.Send(query);
            BookingViewModel viewModel = new BookingViewModel(vm);
            viewModel.BookingItem = item;

            var listEntries = await GetAvailableSchedules(item.DateString);
            viewModel.AvailableTimes = listEntries;

            return View(viewModel);
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
        public async Task<IActionResult> AddBooking()
        {
            BookingConfigurationVm vm = await Mediator.Send(new GetBookingConfigurationQuery());
            BookingViewModel viewModel = new BookingViewModel(vm);
            
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetAvailableSchedulesBooking()
        {
            string date = HttpContext.Request.Query["date"].ToString();

            var listEntries = await GetAvailableSchedules(date);

            return new JsonResult(listEntries);
        }

        private async Task<List<BasicEntry>> GetAvailableSchedules(string date)
        {
            GetAvailableSchedulesQuery query = new GetAvailableSchedulesQuery();
            query.DateTimeInStringFormat = date;
            Dictionary<int, string> dictionary = await Mediator.Send(query);

            List<BasicEntry> listEntries = new AvailableSchedulesViewModel(dictionary).ListEntries;
            return listEntries;
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

        #endregion



        #region BookingSchedulingRule


        public async Task<IActionResult> AddBasicBookingSchedulingRule()
        {
            BasicBookingScheduleRuleVm vm = await Mediator.Send(new GetSchedulingBookingRuleQuery());
            BasicBookingOptionRuleViewModel viewModel = new BasicBookingOptionRuleViewModel(vm);
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddBasicBookingSchedulerRule([Bind] CreateBasicScheduleRuleCommand basicBookingScheduleRule)
        {

            BasicBookingScheduleRule item = await Mediator.Send(basicBookingScheduleRule);

            return await BookingSchedulingRules();
        }


        public async Task<IActionResult> BookingSchedulingRules()
        {
            List<BasicBookingScheduleRule> vm = await Mediator.Send(new GetAllBasicScheduleRuleQuery());

            return View("BookingSchedulingRules", vm);
        }

        public async Task<IActionResult> DeleteBasicBookingSchedulerRule(int id)
        {
            DeleteBasicScheduleRuleCommand command = new DeleteBasicScheduleRuleCommand(id);

            await Mediator.Send(command);

            return await BookingSchedulingRules();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBookingBasicBookingSchedulerRule([Bind] UpdateSchedulingExceptionBookingRuleCommand basicBookingScheduleRule)
        {
            await Mediator.Send(basicBookingScheduleRule);

            return await BookingSchedulingRules();
        }

        public async Task<IActionResult> BasicBookingSchedulingRuleEdit(int id)
        {
            GetBasicScheduleRuleQuery query = new GetBasicScheduleRuleQuery
            { Id = id };

            BasicBookingScheduleRule item = await Mediator.Send(query);
            BasicBookingScheduleRuleVm vm = await Mediator.Send(new GetSchedulingBookingRuleQuery());

            BasicBookingOptionRuleViewModel viewModel = new BasicBookingOptionRuleViewModel(vm);
            viewModel.BasicBookingScheduleRule = item;

            return View(viewModel);
        }

        #endregion


        #region BookingExceptions



        public async Task<IActionResult> AddBookingSchedulingExceptionRule()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBookingSchedulingExceptionRule([Bind] CreateSchedulingExceptionBookingRuleCommand basicBookingScheduleRule)
        {

            var item = await Mediator.Send(basicBookingScheduleRule);

            return await BookingSchedulingExceptionRules();
        }


        public async Task<IActionResult> BookingSchedulingExceptionRules()
        {
            List<SchedulingExceptionBookingRule> vm = await Mediator.Send(new GetAllSchedulingExceptionBookingRuleQuery());

            return View("BookingSchedulingExceptionRules", vm);
        }

        public async Task<IActionResult> DeleteBookingSchedulerExceptionRule(int id)
        {
            var command = new DeleteSchedulingExceptionBookingRuleCommand(id);

            await Mediator.Send(command);

            return await BookingSchedulingExceptionRules();
        }

        #endregion

        #region ConfirmationEmail

        public async Task<IActionResult> BookingConfirmationAction(string id)
        {
            string decryptedId = SecurityTextService.Decrypt(id);

            GetBookingItemQuery query = new GetBookingItemQuery()
            {
                Id = int.Parse(decryptedId)
            };

            BookingItem vm = await Mediator.Send(query);
            
            return View(vm);
        }

        public async Task<IActionResult> ContactUsList()
        {
            List<ContactUs> contactUsList = await Mediator.Send(new GetAllContactUsQuery());
            return View("ContactUsList",contactUsList);
        }

        public async Task<IActionResult> DeleteContactUs(int id)
        {
            var command = new DeleteContactUsCommand(id);

            await Mediator.Send(command);

            return await ContactUsList();
        }
        #endregion
    }
}
