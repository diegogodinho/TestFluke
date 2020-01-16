using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bussines.Contracts;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

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

        [HttpPost]
        public IActionResult Index([FromBody]GetEventModel model)
        {
            return Ok(this.eventService.GetEvents(model));
        }

        [HttpPost]
        [Route("GetByID")]
        public IActionResult GetByID([FromBody]GetEventByIdModel model)
        {
            return Ok(eventService.GetEvent(model));
        }
    }
}