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
    public class ServeFiltersController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        //public LocationFiltersController(ApplicationDbContext context)
        public ServeFiltersController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/LocationFilters
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<LocationFilter>>> GetLocationFilters()
        public async Task<IActionResult> GetServeFilters()
        {
            var servefilters = await _unitOfWork.ServeFilters.GetAll();
            if (servefilters == null)
            {
                return NotFound();
            }
            return Ok(servefilters);
        }

        // GET: api/LocationFilters/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<LocationFilter>> GetLocationFilter(int id)
        public async Task<IActionResult> GetServeFilter(int id)
        {

            var servefilter = await _unitOfWork.ServeFilters.Get(q => q.Id == id);

            if (servefilter == null)
            {
                return NotFound();
            }

            return Ok(servefilter);
        }

        // PUT: api/LocationFilters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServeFilter(int id, ServeFilter servefilter)
        {
            if (id != servefilter.Id)
            {
                return BadRequest();
            }

            //_context.Entry(locationFilter).State = EntityState.Modified;
            _unitOfWork.ServeFilters.Update(servefilter);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!LocationFilterExists(id))
                if (!await ServeFilterExists(id))
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
        public async Task<ActionResult<ServeFilter>> PostServeFilter(ServeFilter servefilter)
        {
            await _unitOfWork.ServeFilters.Insert(servefilter);
            await _unitOfWork.Save(HttpContext);
            return CreatedAtAction("GetServeFilter", new { id = servefilter.Id }, servefilter);
        }

        // DELETE: api/LocationFilters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServeFilter(int id)
        {
            var servefilter = await _unitOfWork.ServeFilters.Get(q => q.Id == id);
            if (servefilter == null)
            {
                return NotFound();
            }
            await _unitOfWork.ServeFilters.Delete(id);
            await _unitOfWork.Save(HttpContext);
            return NoContent();
        }

        private async Task<bool> ServeFilterExists(int id)
        {
            //return (_context.LocationFilters?.Any(e => e.Id == id)).GetValueOrDefault();
            var servefilter = await _unitOfWork.ServeFilters.Get(q => q.Id == id);
            return servefilter != null;
        }
    }
}