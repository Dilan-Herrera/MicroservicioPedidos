using PedidosService.Models;

namespace PedidosService.Messaging
{
    public interface IAzureBusSender
    {
        Task EnviarMensajeAsync(Pedido pedido);
    }
}
