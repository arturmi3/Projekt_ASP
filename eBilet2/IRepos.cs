
using System;
using eBilet2.Models;

public interface IEventRepository
{
    void SaveNewEvent(Event event_);
    void SaveEvent(Event event_);
    Event LoadEvent(int id);
    void DeleteEvent(int id);
    IEnumerable<Event> ListEvents();
}

public interface ICustomerRepository
{
    void SaveNewCustomer(Customer customer);
    void SaveCustomer(Customer customer);
    Customer LoadCustomer(int id);
    void DeleteCustomer(int id);
    IEnumerable<Customer> ListCustomers();
}

public interface ITicketRepository
{
    void SaveNewTicket(Ticket ticket);
    void SaveTicket(Ticket ticket);
    Ticket LoadTicket(int id);
    void DeleteTicket(int id);
    IEnumerable<Ticket> ListTickets();

    int TicketsSold(int eventId);
}

