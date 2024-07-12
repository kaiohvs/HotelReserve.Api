using HotelReserve.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReserve.Api.Data
{
    public class HotelContext : DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options) : base(options) { }

        public DbSet<Hotel> Hotels{ get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
