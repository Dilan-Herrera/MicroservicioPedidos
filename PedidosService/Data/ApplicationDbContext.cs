using Microsoft.EntityFrameworkCore;
using PedidosService.Models;

namespace PedidosService.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Pedido> Pedidos => Set<Pedido>();
    }
}
