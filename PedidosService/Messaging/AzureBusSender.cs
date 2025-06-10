using Azure.Messaging.ServiceBus;
using PedidosService.Models;
using System.Text.Json;

namespace PedidosService.Messaging
{
    public class AzureBusSender : IAzureBusSender
    {
        private readonly ServiceBusClient _client;
        private readonly ServiceBusSender _sender;

        public AzureBusSender(IConfiguration configuration)
        {
            var connectionString = Environment.GetEnvironmentVariable("AZURE_SERVICEBUS_CONNECTION");
            var queueName = Environment.GetEnvironmentVariable("AZURE_SERVICEBUS_QUEUE");

            _client = new ServiceBusClient(connectionString);
            _sender = _client.CreateSender(queueName);
        }

        public async Task EnviarMensajeAsync(Pedido pedido)
        {
            var body = JsonSerializer.Serialize(pedido);
            var message = new ServiceBusMessage(body);

            try
            {
                await _sender.SendMessageAsync(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar mensaje a Azure Service Bus: {ex.Message}");
            }
        }
    }
}
