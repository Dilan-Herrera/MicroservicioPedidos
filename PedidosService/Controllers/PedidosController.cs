using Microsoft.AspNetCore.Mvc;
using PedidosService.Interfaces;
using PedidosService.Models;

namespace PedidosService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoService _pedidoService;

        public PedidosController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerPedidos()
        {
            var pedidos = await _pedidoService.ObtenerPedidosAsync();
            return Ok(pedidos);
        }

        [HttpPost]
        public async Task<IActionResult> CrearPedido([FromBody] Pedido pedido)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var nuevoPedido = await _pedidoService.CrearPedidoAsync(pedido);
            return CreatedAtAction(nameof(ObtenerPedidos), new { id = nuevoPedido.Id }, nuevoPedido);
        }
    }
}
