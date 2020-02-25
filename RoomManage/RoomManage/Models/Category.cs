using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using RoomManage.Resources;

namespace RoomManage.Models
{
    public class Category
    {
       
        public int Id { get; set; }
        [Required]
        [Display()]
        public string CategoryTitle { get; set; }
        [Required]
        [Display]
        public string CstegoryDescrption { get; set; }
        public virtual ICollection<Barrenness> barrenness { get; set; }
    }
}