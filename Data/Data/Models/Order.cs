using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Data.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
//        public OrderItem[] Items { get; set; } = new OrderItem[0];
        public int TotalCount { get; set; }
        public int TotalPrice { get; set; }
//        public DateTime OrderDate { get; set; }
    }
}
