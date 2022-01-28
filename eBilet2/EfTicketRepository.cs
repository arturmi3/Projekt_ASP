using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using eBilet2.Models;

namespace eBilet2
{
    public class EfTicketRepository : ITicketRepository
    {
        private eBilet2.Data.eBilet2Context _context;
        private static int counter = 0;

        public EfTicketRepository(eBilet2.Data.eBilet2Context context)
        {
            _context = context;
        }

        public void SaveNewTicket(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            _context.SaveChanges();
        }

        public void SaveTicket(Ticket ticket)
        {
            var ticket_ = _context.Tickets.Find(ticket.Id);
            ticket_.Number = ticket.Number;
            ticket_.Customer = ticket.Customer;
            ticket_.Event = ticket.Event;

            _context.SaveChanges();
        }

        public Ticket LoadTicket(int id)
        {
            var ticket = _context.Tickets.Find(id);
            
            _context.Entry(ticket).Reference(x => x.Customer).Load();
            _context.Entry(ticket).Reference(x => x.Event).Load();

            return _context.Tickets.Find(id);
        }

        public void DeleteTicket(int id)
        {
            var ticket_ = _context.Tickets.Find(id);
            _context.Tickets.Remove(ticket_);
            _context.SaveChanges();
        }

        public IEnumerable<Ticket> ListTickets()
        {
            return _context.Tickets.ToList();
        }

        public int TicketsSold(int eventId)
        {
            return _context.Tickets.Where(t => t.Event.Id == eventId).Count();
        }
    }
}
