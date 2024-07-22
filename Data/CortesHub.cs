using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace PruebaAnalisisDeImagen.Data
{
    public class CortesHub : Hub
    {
        public async Task SendCorteUpdate(int buttonId, int corteId, string color)
        {
            await Clients.All.SendAsync("ReceiveCorteUpdate", buttonId, corteId, color);
        }
    }
}
