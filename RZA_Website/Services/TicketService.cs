using Microsoft.EntityFrameworkCore;
using RZA_Website.Models;


namespace RZA_Website.Services
{
    public class TicketService
    {
        private readonly TlS2302050RzaContext _context;

        public TicketService(TlS2302050RzaContext context)
        {
            _context = context;
        }
        public async Task<List<Ticket>> GetTicketsAsync()
        {
            return await _context.Tickets.ToListAsync();
        }
        public async Task AddTicketAsync(Ticket newTicket)
        {
            await _context.Tickets.AddAsync(newTicket);
            await _context.SaveChangesAsync();
        }
    }
}
