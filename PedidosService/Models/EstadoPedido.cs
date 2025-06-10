using System.Text.Json.Serialization;

namespace PedidosService.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EstadoPedido
    {
        Pendiente,
        Procesando,
        Enviado,
        Completado,
        Cancelado
    }

}
