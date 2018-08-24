using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControllerExtensibility.Models
{
    public class RemoteService
    {
        public string GetRemoteData()
        {
            System.Threading.Thread.Sleep(5000);
            return "Hello from the other side of the world";
        }
    }
}