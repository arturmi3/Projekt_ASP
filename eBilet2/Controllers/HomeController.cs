using System;
using System.Linq;


using eBilet2.Models;
using Microsoft.AspNetCore.Mvc;


using System.Diagnostics;


namespace eBilet2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEventRepository _repoEvents;
        private readonly ITicketRepository _repoTickets;

        public HomeController(ILogger<HomeController> logger, IEventRepository repoEvents, ITicketRepository repoTickets)
        {
            _logger = logger;
            _repoEvents = repoEvents;
            _repoTickets = repoTickets;
        }

        public IActionResult Index()
        {
            var ticketsSold = _repoEvents.ListEvents().Select(e => new Models.EventPlusTicketsAvailable { Id = e.Id, Date = e.Date, Time = e.Time,  EventType = e.EventType, Localization = e.Localization, Name = e.Name, TicketLimit = e.TicketLimit, TicketAvailable = e.TicketLimit - _repoTickets.TicketsSold(e.Id),  }).ToList();
            return View(ticketsSold);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}