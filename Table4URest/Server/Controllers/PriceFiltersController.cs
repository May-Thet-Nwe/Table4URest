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
    public class PriceFiltersController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        //public LocationFiltersController(ApplicationDbContext context)
        public PriceFiltersController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/LocationFilters
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<LocationFilter>>> GetLocationFilters()
        public async Task<IActionResult> GetPriceFilters()
        {
            var pricefilters = await _unitOfWork.PriceFilters.GetAll();
            return Ok(pricefilters);
        }

        // GET: api/LocationFilters/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<LocationFilter>> GetLocationFilter(int id)
        public async Task<IActionResult> GetPriceFilter(int id)
        {

            var pricefilter = await _unitOfWork.PriceFilters.Get(q => q.Id == id);

            if (pricefilter == null)
            {
                return NotFound();
            }

            return Ok(pricefilter);
        }

        // PUT: api/LocationFilters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPriceFilter(int id, PriceFilter pricefilter)
        {
            if (id != pricefilter.Id)
            {
                return BadRequest();
            }

            //_context.Entry(locationFilter).State = EntityState.Modified;
            _unitOfWork.PriceFilters.Update(pricefilter);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!LocationFilterExists(id))
                if (!await PriceFilterExists(id))
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
        public async Task<ActionResult<PriceFilter>> PostPriceFilter(PriceFilter pricefilter)
        {
            await _unitOfWork.PriceFilters.Insert(pricefilter);
            await _unitOfWork.Save(HttpContext);
            return CreatedAtAction("GetPriceFilter", new { id = pricefilter.Id }, pricefilter);
        }

        // DELETE: api/LocationFilters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePriceFilter(int id)
        {
            var pricefilter = await _unitOfWork.PriceFilters.Get(q => q.Id == id);
            if (pricefilter == null)
            {
                return NotFound();
            }
            await _unitOfWork.PriceFilters.Delete(id);
            await _unitOfWork.Save(HttpContext);
            return NoContent();
        }

        private async Task<bool> PriceFilterExists(int id)
        {
            //return (_context.LocationFilters?.Any(e => e.Id == id)).GetValueOrDefault();
            var pricefilter = await _unitOfWork.PriceFilters.Get(q => q.Id == id);
            return pricefilter != null;
        }
    }
}

