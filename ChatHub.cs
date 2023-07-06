using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SignalR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR
{
    [HubName("chat")]
    public class ChatHub : Hub
    {
        public void sendMessage(string name ,string message)
        {
            myContext Context = new myContext();
            Message m = new Message (){MessageContent = message , Name = name  };
            Context.Messages.Add(m);
            Context.SaveChanges();  

            Clients.Others.newMessage(name, message);
        }
    }
}