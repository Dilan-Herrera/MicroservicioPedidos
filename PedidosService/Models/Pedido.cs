namespace PedidosService.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public DateTime Fecha { get; set; } = DateTime.UtcNow;
        public EstadoPedido Estado { get; set; } = EstadoPedido.Pendiente;
    }

}
