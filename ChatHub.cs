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
        public void sendMessage(Message m)
        {
            myContext Context = new myContext();
            //Message m = new Message (){MessageContent = message , Name = name  };
            Context.Messages.Add(m);
            Context.SaveChanges();  

            Clients.Others.newMessage(m);
        }

        public void joinGroup(string groupName , string name)
        {
            Groups.Add(Context.ConnectionId, groupName);
            Clients.OthersInGroup(groupName).newMember(name, groupName);
        }

        public void sendGroupMessage(string groupName , string message , string name) 
        {
            Clients.OthersInGroup(groupName).sendMessage(name, message , groupName);
        }
    }
}