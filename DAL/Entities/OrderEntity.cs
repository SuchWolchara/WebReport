using System;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class OrderEntity : BaseEntity
    {
        [Required]
        [Display(Name = "Order price")]
        public int Price { get; set; }

        [Required]
        [Display(Name = "Order date")]
        public DateTime Date { get; set; }
    }
}
