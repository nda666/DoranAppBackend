using Newtonsoft.Json;
using System.Net.WebSockets;
using System.Text;

namespace DoranOfficeBackend
{
    public class WebSocketService
    {
        private List<WebSocket> _clients = new List<WebSocket>();
        private readonly ILogger<WebSocketService> _logger;

        public WebSocketService(ILogger<WebSocketService> logger)
        {
            _logger = logger;
        }
        public async Task AddClient(WebSocket webSocket)
        {
            _clients.Add(webSocket);
        }

        public List<WebSocket> GetClients()
        {
           return _clients;
        }

        public async Task RemoveClient(WebSocket webSocket)
        {
            _clients.Remove(webSocket);
        }

        public async Task SendToAll(string eventName, object data)
        {
            var message = new
            {
                EventName = eventName,
                Data = data
            };
            try
            {
                var jsonMessage = JsonConvert.SerializeObject(message, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                var buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(jsonMessage));
               

                foreach (var client in _clients)
                {
                    if (client.State == WebSocketState.Open)
                    {

                      await client.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
                      _logger.LogWarning($"WebSocket Send: {jsonMessage}");
                    }
                }
            } catch (Exception ex)
            {
                ConsoleDump.Extensions.Dump(ex);
            }
            
        }
    }
}
