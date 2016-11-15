using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace myChat.Hubs
{
    public class ChatHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        //send yapan hub fonksiyonu
        public void groupSend(string message, int groupid, int userid)
        {
            Clients.All.sendMessageGroup(message, groupid, userid);
        }
    }
}