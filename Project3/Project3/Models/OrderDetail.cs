using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project3.Models
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        [Key]
        [Column("OrderDetailId")]
        [Display(Name = "Order Detail code")]
        public int OrderDetailId { get; set; }

        [Column("OrderDetailStatus")]
        [Display(Name = "Order Detail Status")]
        public string? OrderDetailStatus { get; set; }

        [Column("OrdersId")]
        [Display(Name = "Orders")]
        public int? OrdersId { get; set; }

        [Display(Name = "Orders")]
        public Orders? Orders { get; set; }
    }
}
