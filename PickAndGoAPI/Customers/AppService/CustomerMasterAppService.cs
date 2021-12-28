using Microsoft.EntityFrameworkCore;
using PickAndGoAPI.Data;
using PickAndGoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PickAndGoAPI.Customers.AppService
{
    public class CustomerMasterAppService
    {
        private readonly DataContext _context;

        public CustomerMasterAppService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            List<Customer> customers = await _context.Customers.ToListAsync();
            return customers;
        }

        public async Task<Customer> GetCustomer(int id)
        {
            Customer customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            return customer;
        }

        public void AddCustomer( Customer customer)
        {
            _context.AddAsync(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
        }

        public async Task<string> DeleteCustomer(int id)
        {
            Customer customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customer == null)
            {
                return "El cliente no existe";
            }
            _context.Customers.Remove(customer);
            return "El cliente se ha eliminado";
        }

    }
}
