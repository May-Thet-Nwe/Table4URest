using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Table4URest.Client.Static
{
    public static class Endpoints
    {
        private static readonly string Prefix = "api";      /*constructing api endpoints for each entity*/

        public static readonly string CustomersEndpoint = $"{Prefix}/customers";
        public static readonly string LocationFiltersEndpoint = $"{Prefix}/locationfilters";
        public static readonly string PriceFiltersEndpoint = $"{Prefix}/pricefilters";
        public static readonly string ReservationsEndpoint = $"{Prefix}/reservations";
        public static readonly string RestaurantsEndpoint = $"{Prefix}/restaurants";
        public static readonly string ReviewsEndpoint = $"{Prefix}/reviews";
        public static readonly string ServeFiltersEndpoint = $"{Prefix}/servefilters";
        public static readonly string StaffsEndpoint = $"{Prefix}/staffs";
    }
}
