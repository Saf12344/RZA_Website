using RZA_Website.Components;
using RZA_Website.Services;
using RZA_Website.Models;
using Microsoft.EntityFrameworkCore;

namespace RZA_Website.Services
{

    public class CustomerService
    {
        private readonly TlS2302050RzaContext _context;

        public CustomerService(TlS2302050RzaContext context)
        {
            _context = context;
        }
        public async Task AddCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer?> LogIn(Customer customer)
        {
            return await _context.Customers.FirstOrDefaultAsync(
                c => c.Username == customer.Username &&
                c.Password == customer.Password);
        }
    }
}