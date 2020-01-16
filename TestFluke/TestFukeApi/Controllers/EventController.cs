﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bussines.Contracts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestFukeApi.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        [HttpGet]
        public IActionResult Index(string sortBy)
        {
            return Ok(this.eventService.GetEvents(sortBy));
        }

        [HttpGet]
        [Route("GetEventsByStatus")]
        public IActionResult GetEvents(string statusEvent, string sortBy)
        {
            return Ok(this.eventService.GetEventsByStatus(statusEvent, sortBy));
        }

        [HttpGet]
        [Route("GetEventsByCategory")]
        public IActionResult GetEventsByCategory(int category, string sortBy)
        {
            try
            {
                return Ok(this.eventService.GetEventsByCategory(category, sortBy));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetEventsByDate")]
        public IActionResult GetEvents(DateTime datetimeClosed, string sortBy)
        {
            return Ok(this.eventService.GetEventsByDate(datetimeClosed, sortBy));
        }
    }
}