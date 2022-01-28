using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using eBilet2.Models;

namespace eBilet2
{
    public class EfCustomerRepository : ICustomerRepository
    {
        private eBilet2.Data.eBilet2Context _context;

        public EfCustomerRepository(eBilet2.Data.eBilet2Context context)
        {
            _context = context;
        }

        public void SaveNewCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public void SaveCustomer(Customer customer)
        {
            var customer_ = _context.Customers.Find(customer.Id);
            customer_.Name = customer.Name;
            customer_.Surname = customer.Surname;
            customer_.Email = customer.Email;
            customer_.RegisterDate = customer.RegisterDate;
            customer_.Status = customer.Status;

            _context.SaveChanges();
        }

        public Customer LoadCustomer(int id)
        {
            return _context.Customers.Find(id);
        }

        public void DeleteCustomer(int id)
        {
            var customer_ = _context.Customers.Find(id);
            _context.Customers.Remove(customer_);
            _context.SaveChanges();
        }

        public IEnumerable<Customer> ListCustomers()
        {
            return _context.Customers.ToList();
        }
    }
}
