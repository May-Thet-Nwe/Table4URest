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
    public class RestaurantsController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        //public LocationFiltersController(ApplicationDbContext context)
        public RestaurantsController(IUnitOfWork unitOfWork)
        {
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/LocationFilters
        [HttpGet]
        //public async Task<ActionResult<IEnumerable<LocationFilter>>> GetLocationFilters()
        public async Task<IActionResult> GetRestaurants()
        {
            var restaurants = await _unitOfWork.Restaurants.GetAll();
            return Ok(restaurants);
        }

        // GET: api/LocationFilters/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<LocationFilter>> GetLocationFilter(int id)
        public async Task<IActionResult> GetRestaurant(int id)
        {

            var restaurant = await _unitOfWork.Restaurants.Get(q => q.Id == id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }

        // PUT: api/LocationFilters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurant(int id, Restaurant restaurant)
        {
            if (id != restaurant.Id)
            {
                return BadRequest();
            }

            //_context.Entry(locationFilter).State = EntityState.Modified;
            _unitOfWork.Restaurants.Update(restaurant);

            try
            {
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //if (!LocationFilterExists(id))
                if (!await RestaurantExists(id))
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
        public async Task<ActionResult<Restaurant>> PostRestaurant(Restaurant restaurant)
        {
            await _unitOfWork.Restaurants.Insert(restaurant);
            await _unitOfWork.Save(HttpContext);
            return CreatedAtAction("GetRestaurant", new { id = restaurant.Id }, restaurant);
        }

        // DELETE: api/LocationFilters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            var restaurant = await _unitOfWork.Restaurants.Get(q => q.Id == id);
            if (restaurant == null)
            {
                return NotFound();
            }
            await _unitOfWork.Restaurants.Delete(id);
            await _unitOfWork.Save(HttpContext);
            return NoContent();
        }

        private async Task<bool> RestaurantExists(int id)
        {
            //return (_context.LocationFilters?.Any(e => e.Id == id)).GetValueOrDefault();
            var restaurant = await _unitOfWork.Restaurants.Get(q => q.Id == id);
            return restaurant != null;
        }
    }
}