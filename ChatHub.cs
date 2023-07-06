using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR
{
    public class ChatHub : Hub
    {
        public void sendMessage(string name ,string message)
        {
            Clients.All.newMessage(name, message);
        }
    }
}