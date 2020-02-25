using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoomManage.Models
{
    public class Chating
    {
        public int Id { get; set; }
        public int applyId { get; set; }
        public string sender { get; set; }
        public string reciver { get; set; }
        public string message { get; set; }
        public string sendDate { get; set; }
    }
}