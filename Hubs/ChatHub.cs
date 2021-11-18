using Microsoft.AspNetCore.SignalR;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medan_Rodica_Lab2_EB.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string name, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, name, message);
        }
       
    }
    
}
