using Microsoft.EntityFrameworkCore;
using PedidosService.Data;
using PedidosService.Interfaces;
using PedidosService.Messaging;
using PedidosService.Models;

namespace PedidosService.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAzureBusSender _busSender;

        public PedidoService(ApplicationDbContext context, IAzureBusSender busSender)
        {
            _context = context;
            _busSender = busSender;
        }

        public async Task<IEnumerable<Pedido>> ObtenerPedidosAsync() =>
            await _context.Pedidos.ToListAsync();

        public async Task<Pedido> CrearPedidoAsync(Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            await _busSender.EnviarMensajeAsync(pedido);
            return pedido;
        }
    }

}
