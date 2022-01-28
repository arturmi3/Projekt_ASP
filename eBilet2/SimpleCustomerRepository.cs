using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using eBilet2.Models;

namespace eBilet2
{
    public class SimpleCustomerRepository : ICustomerRepository
    {
        private static List<Customer> _lista = new List<Customer>();
        private static int counter = 0;

        public SimpleCustomerRepository()
        {
            //_lista = new List<Customer>();
            //counter = 0;
        }

        public void SaveNewCustomer(Customer customer)
        {
            customer.Id = ++counter;
            _lista.Add(customer);
        }

        public void SaveCustomer(Customer customer)
        {
            var customer_ = _lista.Find(X => X.Id == customer.Id);
            customer_.Name = customer.Name;
            customer_.Surname = customer.Surname;
            customer_.Email = customer.Email;
            customer_.RegisterDate = customer.RegisterDate;
            customer_.Status = customer.Status;
        }

        public Customer LoadCustomer(int id)
        {
            return _lista.Find(X => X.Id == id);
        }

        public void DeleteCustomer(int id)
        {
            var customer_ = _lista.Find(X => X.Id == id);
            _lista.Remove(customer_);
        }

        public IEnumerable<Customer> ListCustomers()
        {
            return _lista;
        }
    }
}
