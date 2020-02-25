using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoomManage.Models
{
    public class ApplyForBarrennes
    {
        public int Id { get; set; }
        [Display(Name = "رسالة الباحث عن للعقار")]
        public string Message { get; set; }
        [Display(Name = "تاريخ التقدم للعقار")]
        public DateTime ApplyDate { get; set; }
        public int BarrennessId { get; set; }
        public string UserId { get; set; }
        public virtual Barrenness barrennes { get; set; }
        public virtual ApplicationUser user { get; set; }
    }
}