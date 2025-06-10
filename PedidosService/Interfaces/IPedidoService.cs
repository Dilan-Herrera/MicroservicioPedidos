using PedidosService.Models;

namespace PedidosService.Interfaces
{
    public interface IPedidoService
    {
        Task<IEnumerable<Pedido>> ObtenerPedidosAsync();
        Task<Pedido> CrearPedidoAsync(Pedido pedido);
    }

}
