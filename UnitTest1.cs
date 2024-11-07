using RZA_Website.Components;
using RZA_Website.Services;
using RZA_Website.Models;
using Microsoft.EntityFrameworkCore;


namespace UnitTest
{
    public class Tests
    {

        private TlS2302050RzaContext _context;
        private CustomerService _customerService;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<TlS2302050RzaContext>().UseInMemoryDatabase(databaseName: "TestDatabase").Options;
            _context = new TlS2302050RzaContext(options);
            _customerService = new CustomerService(_context);

        }

        [Test]
        public async Task Test1()
        {
            Customer tempCustomer = new Customer()
            {
                Username = "admin",
                Password = "admin",
            };
            await _customerService
        }
        [TearDown]

        public void TearDown()
        {
            _context.Dispose();
        }
    }
}