using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using eBilet2.Models;

namespace eBilet2
{
    public class SimpleEventRepository : IEventRepository
    {
        private static List<Event> _lista = new List<Event>();
        private int counter = 0;

        public SimpleEventRepository()
        {
            //_lista = new List<Event>();
            //counter = 0;
        }

        public void SaveNewEvent(Event event_)
        {
            event_.Id = ++counter;
            _lista.Add(event_);
        }

        public void SaveEvent(Event event_)
        {
            var e = _lista.Find(X => X.Id == event_.Id);
            e.Name = e.Name;
            e.EventType = e.EventType;
            e.Date = e.Date;
            e.Time = e.Time;
            _lista.Add(e);
        }

        public Event LoadEvent(int id)
        {
            return _lista.Find(X => X.Id == id);
        }

        public void DeleteEvent(int id)
        {
            var event_ = _lista.Find(X => X.Id == id);
            _lista.Remove(event_);
        }

        public IEnumerable<Event> ListEvents()
        {
            return _lista;
        }
    }
}
