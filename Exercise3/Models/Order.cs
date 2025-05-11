using System.ComponentModel.DataAnnotations;

namespace Exercise3.Models
{
    public class Order
    {
        public int OrderID { get; set; }

        [Required(ErrorMessage = "Order Date is required.")]
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Agent is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid agent.")]
        public int AgentID { get; set; }

        public Agent Agent { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } // Not required

    }
}
