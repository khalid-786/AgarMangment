using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoomManage.Models
{
    public class Barrenness
    {
        public int Id { get; set; }
        [Required(ErrorMessage = " حقل وصف العقار فارغ")]
        public string barrenessDescription { get; set; }
        [Required(ErrorMessage = " حقل نوع العقار فارغ")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = " حقل سعر الإيجار فارغ")]
        public string leasePrice { get; set; }
        [Required(ErrorMessage = " حقل طريقة الدفع فارغ")]
        public string paymentMethod { get; set; }
        [Required(ErrorMessage = " حقل العدد المتاح غارغ")]
        public int Number { get; set; }
        [Required(ErrorMessage = " حقل الولاية فارغ")]
        public DateTime publishDate { get; set; }
        public string UserId { get; set; }
        [Required(ErrorMessage = " حقل الولاية فارغ")]
        public string state { get; set; }
        [Required(ErrorMessage = " حقل عنوان العقار فارغ")]
        public string fullLocation { get; set; }
        public bool status { get; set; }
        public virtual Category Category { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}