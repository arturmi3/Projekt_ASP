#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eBilet2.Models;

namespace eBilet2.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventRepository _repository;

        public EventsController(IEventRepository context)
        {
            _repository = context;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            return View(_repository.ListEvents());
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ev = _repository.LoadEvent(id.Value);
            if (ev == null)
            {
                return NotFound();
            }

            return View(ev);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Localization,Date,Time,EventType,TicketLimit")] Event ev)
        {
            if (ModelState.IsValid)
            {
                _repository.SaveNewEvent(ev);
                return RedirectToAction(nameof(Index));
            }
            return View(ev);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ev = _repository.LoadEvent(id.Value);
            if (ev == null)
            {
                return NotFound();
            }
            return View(ev);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Localization,Date,Time,EventType,TicketLimit")] Event ev)
        {
            if (id != ev.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repository.SaveEvent(ev);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(ev.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ev);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ev = _repository.LoadEvent(id.Value);
            if (ev == null)
            {
                return NotFound();
            }

            return View(ev);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ev = _repository.LoadEvent(id);
            _repository.DeleteEvent(id);
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return (_repository.LoadEvent(id) != null);
        }
    }
}
