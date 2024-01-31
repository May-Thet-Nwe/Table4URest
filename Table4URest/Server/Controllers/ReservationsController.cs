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
    public class ReservationsController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        //public LocationFiltersController(ApplicationDbContext context)
        public ReservationsController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/LocationFilters
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<LocationFilter>>> GetLocationFilters()
        public async Task<IActionResult> GetReservations()
        {
            var reservations = await _unitOfWork.Reservations.GetAll(includes: q=>q.Include(x=>x.Restaurant).Include(x=>x.Customer)) ;
            if (reservations == null)
            {
                return NotFound();
            }
            return Ok(reservations);
        }

        // GET: api/LocationFilters/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<LocationFilter>> GetLocationFilter(int id)
        public async Task<IActionResult> GetReservation(int id)
        {

            var reservation = await _unitOfWork.Reservations.Get(q => q.Id == id);

            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }

        // PUT: api/LocationFilters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservation(int id, Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return BadRequest();
            }

            //_context.Entry(locationFilter).State = EntityState.Modified;
            _unitOfWork.Reservations.Update(reservation);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!LocationFilterExists(id))
                if (!await ReservationExists(id))
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
        public async Task<ActionResult<Reservation>> PostReservation(Reservation reservation)
        {
            await _unitOfWork.Reservations.Insert(reservation);
            await _unitOfWork.Save(HttpContext);
            return CreatedAtAction("GetReservation", new { id = reservation.Id }, reservation);
        }

        // DELETE: api/LocationFilters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var reservation = await _unitOfWork.Reservations.Get(q => q.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }
            await _unitOfWork.Reservations.Delete(id);
            await _unitOfWork.Save(HttpContext);
            return NoContent();
        }

        private async Task<bool> ReservationExists(int id)
        {
            //return (_context.LocationFilters?.Any(e => e.Id == id)).GetValueOrDefault();
            var reservation = await _unitOfWork.Reservations.Get(q => q.Id == id);
            return reservation != null;
        }
    }
}