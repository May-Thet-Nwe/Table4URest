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
    public class ReviewsController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        //public LocationFiltersController(ApplicationDbContext context)
        public ReviewsController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/LocationFilters
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<LocationFilter>>> GetLocationFilters()
        public async Task<IActionResult> GetReviews()
        {
            var reviews = await _unitOfWork.Reviews.GetAll();
            return Ok(reviews);
        }

        // GET: api/LocationFilters/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<LocationFilter>> GetLocationFilter(int id)
        public async Task<IActionResult> GetReview(int id)
        {

            var review = await _unitOfWork.Reviews.Get(q => q.Id == id);

            if (review == null)
            {
                return NotFound();
            }

            return Ok(review);
        }

        // PUT: api/LocationFilters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(int id, Review review)
        {
            if (id != review.Id)
            {
                return BadRequest();
            }

            //_context.Entry(locationFilter).State = EntityState.Modified;
            _unitOfWork.Reviews.Update(review);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!LocationFilterExists(id))
                if (!await ReviewExists(id))
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
        public async Task<ActionResult<PriceFilter>> PostReview(Review review)
        {
            await _unitOfWork.Reviews.Insert(review);
            await _unitOfWork.Save(HttpContext);
            return CreatedAtAction("GetReview", new { id = review.Id }, review);
        }

        // DELETE: api/LocationFilters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var review = await _unitOfWork.Reviews.Get(q => q.Id == id);
            if (review == null)
            {
                return NotFound();
            }
            await _unitOfWork.Reviews.Delete(id);
            await _unitOfWork.Save(HttpContext);
            return NoContent();
        }

        private async Task<bool> ReviewExists(int id)
        {
            //return (_context.LocationFilters?.Any(e => e.Id == id)).GetValueOrDefault();
            var review = await _unitOfWork.Reviews.Get(q => q.Id == id);
            return review != null;
        }
    }
}