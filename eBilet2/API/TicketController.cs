using Microsoft.AspNetCore.Mvc;

using eBilet2.Models;

namespace eBilet2.API
{
    [Route("/api/ticket")]
    public class TicketController : Controller
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        [HttpGet]
        [Route("id")]
        public IActionResult Get(int id)
        {
            var c = _ticketRepository.LoadTicket(id);
            return new ObjectResult(c);
        }
    }
}