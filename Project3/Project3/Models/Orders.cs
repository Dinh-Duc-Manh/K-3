using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Project3.Models
{
    [Table("Orders")]
    public class Orders
    {
        [Key]
        [Column("OrdersId")]
        [Display(Name = "Orders code")]
        public int OrdersId { get; set; }

        [Column("ReceiverName")]
        [Display(Name = "Receiver name")]
        public string? ReceiverName { get; set; }

        [Column("ReceiverAddress")]
        [Display(Name = "Receiver address")]
        public string? ReceiverAddress { get; set; }

        [Column("ReceiverPhone")]
        [Display(Name = "Receiver phone")]
        public string? ReceiverPhone { get; set; }

        [Column("Note")]
        [Display(Name = "Note")]
        public string? Note { get; set; }

        [Column("OrderDate")]
        [Display(Name = "Order date")]
        public DateTime? OrderDate { get; set; }

        [Column("CartId")]
        [Display(Name = "Cart")]
        public int? CartId { get; set; }

        [Column("ProductId")]
        [Display(Name = "Product")]
        public int? ProductId { get; set; }

        [Column("AccountId")]
        [Display(Name = "Account")]
        public int? AccountId { get; set; }

        [Display(Name = "Cart")]
        public Cart? Cart { get; set; }

        [Display(Name = "Product")]
        public Product? Product { get; set; }

        [Display(Name = "Account")]
        public Account? Account { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
