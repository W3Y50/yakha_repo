using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text;
using Newtonsoft.Json;
using ClassLibrary;
using Microsoft.AspNetCore.SignalR;

namespace DigitalTwin_Api.Controllers
{
    [Route("api/")]
    public class SeismicController : Controller
    {

        //Create the ObservableCollection
        private readonly SharedDataModel _sharedData;
        private readonly ILogger<SeismicController> _logger;

        ClientWebSocket client = new ClientWebSocket(); //Define the WebSocket connection

        public SeismicController(ILogger<SeismicController> logger, SharedDataModel sharedData)
        {
            _logger = logger;
            _sharedData = sharedData;
        }

        [HttpPost("StartListeningSeismicEvents")]
        public async Task<string> GetSeimicEvents()
        {
            //Create and subscribe to the CollectionChanged event
            SeismicEventHandling evHandling = new SeismicEventHandling();
            _sharedData._seismicEvents.CollectionChanged += evHandling.SeismicEvents_CollectionChanged;
            
            //Establish a WebSocket connection
            await client.ConnectAsync(new Uri("wss://www.seismicportal.eu/standing_order/websocket"), CancellationToken.None);

            //To continuously receive data - for closing use the POST request
            while (client.State == WebSocketState.Open)
            {
                var buffer = new byte[1024 * 4];
                var result = await client.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None); //Listen to new seismic events

                if (result.MessageType == WebSocketMessageType.Close)
                {
                    await client.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, CancellationToken.None);
                    return $"Connection was closed!";
                }
                else
                {
                    string receivedMessage = Encoding.UTF8.GetString(buffer, 0, result.Count); //Get the event Data as string
                    var eventObj = JsonConvert.DeserializeObject<SeismicEventModel>(receivedMessage); //Parse the string into SeismicEventModel
                    _sharedData._seismicEvents.Add(eventObj); //Put the event into a gloabl list - to handle it
                    Console.WriteLine($"Received: {receivedMessage}");
                }

            }

            return $"Connection was closed!";
        }

        [HttpGet("GetAllSeismicEvents")] //Get a list of all detected seismic events since starting the process
        public async Task<ActionResult<List<SeismicEventModel>>> GetAllSeismicEvents()
        {
            return Ok(_sharedData._seismicEvents);
        }
    }
    public class ItemHub : Hub
    {
        public async Task AddItem(string item)
        {
            await Clients.All.SendAsync("ReceiveItem", item);
        }
    }
}
