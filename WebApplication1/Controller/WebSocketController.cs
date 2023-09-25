
using System;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace DoranOfficeBackend.Controller
{

    [Route("api/ws")]
    public class WebSocketController : ControllerBase
    {
        private readonly WebSocketService _webSocket;
        private readonly ILogger<WebSocketController> _logger;
        public WebSocketController( WebSocketService webSocket, ILogger<WebSocketController> logger)
        {
            _webSocket = webSocket;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> ConnectWebSocket()
        {
          
            if (HttpContext.WebSockets.IsWebSocketRequest)
            {
                WebSocket webSocket = await HttpContext.WebSockets.AcceptWebSocketAsync();
                  await _webSocket.AddClient(webSocket);
                _logger.LogWarning("WebSocket connection established");
                await Echo(webSocket);

            }
            else
            {
                HttpContext.Response.StatusCode = 400;
            }

            return new EmptyResult();
        }

        private async Task Echo(WebSocket webSocket)
        {
            var buffer = new byte[1024 * 4];
            var result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            _logger.LogWarning( "Message received from Client");

            while (!result.CloseStatus.HasValue)
            {
                var serverMsg = Encoding.UTF8.GetBytes($"Server: Hello. You said: {Encoding.UTF8.GetString(buffer)}");
                await webSocket.SendAsync(new ArraySegment<byte>(serverMsg, 0, serverMsg.Length), result.MessageType, result.EndOfMessage, CancellationToken.None);
                _logger.LogWarning("Message sent to Client");

                buffer = new byte[1024 * 4];
                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
                _logger.LogWarning("Message received from Client");

            }
            await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
            _logger.LogWarning("WebSocket connection closed");
        }
    }
}
