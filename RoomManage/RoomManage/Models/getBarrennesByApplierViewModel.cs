using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoomManage.Models
{
    public class getBarrennesByApplierViewModel
    {
        public int apply_id { get; set; }
        public string applier_id { get; set; }
        [Display(Name = "صاحب العقار")]
        public string publisher_id { get; set; }
        [Display(Name = "العقار")]
        public string barrennessDesc { get; set; }
        [Display(Name = "سعر الإيجار")]
        public string price { get; set; }
        [Display(Name = " الولاية")]
        public string state { get; set; }
        [Display(Name = " عنوانه بالكامل")]
        public string fulladdress { get; set; }
    }
}