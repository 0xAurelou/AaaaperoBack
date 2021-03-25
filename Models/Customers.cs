using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Customers
    {
        [Key]
        public int Id { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }

    }
}