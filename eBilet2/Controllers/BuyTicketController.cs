using Microsoft.AspNetCore.Mvc;

namespace eBilet2.Controllers
{
    public class BuyTicketController : Controller
    {
        private readonly ICustomerRepository _repoCostomers;
        private readonly IEventRepository _repoEvents;
        private readonly ITicketRepository _repoTickets;


        public BuyTicketController(ICustomerRepository repoCostomers, IEventRepository repoEvents, ITicketRepository repoTickets)
        {
            _repoCostomers = repoCostomers;
            _repoEvents = repoEvents;
            _repoTickets = repoTickets;
        }

        public IActionResult Create(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ev = _repoEvents.LoadEvent(id.Value);

            ViewData["Event"] = $"{ev.Name} - {ev.Localization} - {ev.EventType} - {ev.Date} - {ev.Time}";
                
            return View(new Models.BuyTicket { EventId = id.Value });
        }

        // POST: Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,Name,Surname,Email")] Models.BuyTicket buyTicket)
        {
            if (ModelState.IsValid)
            {
                var ev = _repoEvents.LoadEvent(buyTicket.EventId);

                var newCustomer = new Models.Customer { Name = buyTicket.Name, Surname = buyTicket.Surname, Email = buyTicket.Email, RegisterDate = DateTime.Now, Status = Models.CustomerStatus.Active };

                _repoCostomers.SaveNewCustomer( newCustomer);

                var newTicket = new Models.Ticket { Customer = newCustomer, Event = ev, Number = 0, };

                _repoTickets.SaveNewTicket(newTicket);
                
                newTicket.Number = newTicket.Id;
                _repoTickets.SaveTicket(newTicket);

                return RedirectToAction(nameof(Details), new { Id = newTicket.Id });
            }
            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var ticket = _repoTickets.LoadTicket(id.Value);
            if (ticket == null)
            {
                return NotFound();
            }

            ticket.Customer = _repoCostomers.LoadCustomer(ticket.Customer.Id);
            ticket.Event = _repoEvents.LoadEvent(ticket.Event.Id);

            return View(ticket);
        }
    }
}
