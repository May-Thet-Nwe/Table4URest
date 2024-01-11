using Table4URest.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Table4URest.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<LocationFilter> LocationFilters { get; }
        IGenericRepository<ServeFilter> ServeFilters { get; }
        IGenericRepository<PriceFilter> PriceFilters { get; }
        IGenericRepository<Restaurant> Restaurants { get; }
        IGenericRepository<Reservation> Reservations { get; }
        IGenericRepository<Customer> Customers { get; }
        IGenericRepository<Review> Reviews { get; }
        IGenericRepository<Staff> Staffs { get; }
    }
}