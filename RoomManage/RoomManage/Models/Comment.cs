using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoomManage.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Display(Name = "المستخدم")]
        public string UserId { get; set; }
        [Display(Name = "الرسالة")]

        public string message { get; set; }
        [Display(Name = "التاريخ")]

        public string sendDate { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}