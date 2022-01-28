using Microsoft.AspNetCore.Mvc;

using eBilet2.Models;

namespace eBilet2.API
{
    [Route("/api/events")]
    public class EventsController : Controller
    {
        private readonly IEventRepository _eventRepository;

        public EventsController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        [HttpGet]
        [Route("id")]
        public IActionResult Get(int id)
        {
            var c = _eventRepository.LoadEvent(id);
            return new ObjectResult(c);
        }
    }
}