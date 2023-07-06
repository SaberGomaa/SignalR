using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalR.Models
{
    public class Message
    {
        public int Id { get; set; }
        public DateTime  Date { get; set; } = DateTime.Now;
        public string Name { get; set; }
        public string MessageContent { get; set; }
    }
}