using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using eBilet2.Models;

namespace eBilet2
{
    public class SimpleTicketRepository : ITicketRepository
    {
        private static List<Ticket> _lista = new List<Ticket>();
        private static int counter = 0;

        public SimpleTicketRepository()
        {
            //_lista = new List<Ticket>();
            //counter = 0;
        }

        public void SaveNewTicket(Ticket Ticket)
        {
            Ticket.Id = ++counter;
            _lista.Add(Ticket);
        }

        public void SaveTicket(Ticket ticket)
        {
            var ticket_ = _lista.Find(X => X.Id == ticket.Id);
            ticket_.Number = ticket.Number;
            ticket_.Customer = ticket.Customer;
            ticket_.Event = ticket.Event;
        }

        public Ticket LoadTicket(int id)
        {
            return _lista.Find(X => X.Id == id);
        }

        public void DeleteTicket(int id)
        {
            var ticket_ = _lista.Find(X => X.Id == id);
            _lista.Remove(ticket_);
        }

        public IEnumerable<Ticket> ListTickets()
        {
            return _lista;
        }

        public int TicketsSold(int eventId)
        {
            return _lista.Where(t => t.Event.Id == eventId).Count();
        }

    }
}
