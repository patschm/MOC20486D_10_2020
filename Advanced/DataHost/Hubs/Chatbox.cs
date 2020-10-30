using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataHost.Hubs
{
    public class Chatbox: Hub
    {
        public async Task IkDoeMee(string nick)
        {
            await Clients.All.SendAsync("Joehoe", $"{nick} doet mee");
        }
        public async Task Blaat(string nick, string msg)
        {
            await Clients.All.SendAsync("Joehoe", $"{nick}> {msg}");
        }
    }
}
