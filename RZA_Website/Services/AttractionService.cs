using Microsoft.EntityFrameworkCore;
using RZA_Website.Models;


namespace RZA_Website.Services
{
    public class AttractionService
    {
        private readonly TlS2302050RzaContext _context;

        public AttractionService(TlS2302050RzaContext context)
        {
            _context = context;
        }
        public async Task<List<Attraction>> GetAttractionsAsync()
        {
            return await _context.Attractions.ToListAsync();
        }
    }
}
