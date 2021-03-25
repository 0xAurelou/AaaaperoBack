using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Customers
    {
        [Key]
        public int customer_id { get; set; }
        public string customer_name { get; set; }

    }
}