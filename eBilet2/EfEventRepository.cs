using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using eBilet2.Models;

namespace eBilet2
{
    public class EfEventRepository : IEventRepository
    {
        private eBilet2.Data.eBilet2Context _context;

        public EfEventRepository(eBilet2.Data.eBilet2Context context)
        {
            _context = context;
        }

        public void SaveNewEvent(Event event_)
        {
            _context.Events.Add(event_);
            _context.SaveChanges();
        }

        public void SaveEvent(Event event_)
        {
            var e = _context.Events.Find(event_.Id);
            e.Name = e.Name;
            e.EventType = e.EventType;
            e.Date = e.Date;
            e.Time = e.Time;

            _context.SaveChanges();
        }

        public Event LoadEvent(int id)
        {
            return _context.Events.Find(id);
        }

        public void DeleteEvent(int id)
        {
            var event_ = _context.Events.Find(id);
            _context.Events.Remove(event_);
            _context.SaveChanges();
        }

        public IEnumerable<Event> ListEvents()
        {
            return _context.Events.ToList();
        }
    }
}
