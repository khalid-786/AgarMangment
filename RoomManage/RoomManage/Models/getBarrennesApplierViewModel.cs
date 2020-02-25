using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoomManage.Models
{
    public class getBarrennesApplierViewModel
    {
        public int apply_id { get; set; }
        public string applier_id { get; set; }
        public string publisher_id { get; set; }
        [Display(Name = "إسم المتقدم")]
        public string username { get; set; }
        [Display(Name = " رقم التلفون")]  
        public string phoneNumber { get; set; }
        [Display(Name = " عنوانه بالكامل")]
        public string address { get; set; }
        
    }
}