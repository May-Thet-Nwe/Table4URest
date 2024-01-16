using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Table4URest.Server.Data;
using Table4URest.Server.IRepository;
using Table4URest.Shared.Domain;

namespace Table4URest.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        //public LocationFiltersController(ApplicationDbContext context)
        public CustomersController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/LocationFilters
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<LocationFilter>>> GetLocationFilters()
        public async Task<IActionResult> GetConstomers()
        {
            var customers = await _unitOfWork.Customers.GetAll();
            return Ok(customers);
        }

        // GET: api/LocationFilters/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<LocationFilter>> GetLocationFilter(int id)
        public async Task<IActionResult> GetCustomer(int id)
        {

            var customer = await _unitOfWork.Customers.Get(q => q.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/LocationFilters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            //_context.Entry(locationFilter).State = EntityState.Modified;
            _unitOfWork.Customers.Update(customer);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!LocationFilterExists(id))
                if (!await CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }

            return NoContent();
        }

        // POST: api/LocationFilters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            await _unitOfWork.Customers.Insert(customer);
            await _unitOfWork.Save(HttpContext);
            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // DELETE: api/LocationFilters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _unitOfWork.Customers.Get(q => q.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            await _unitOfWork.Customers.Delete(id);
            await _unitOfWork.Save(HttpContext);
            return NoContent();
        }

        private async Task<bool> CustomerExists(int id)
        {
            //return (_context.LocationFilters?.Any(e => e.Id == id)).GetValueOrDefault();
            var customer = await _unitOfWork.Customers.Get(q => q.Id == id);
            return customer != null;
        }
    }
}