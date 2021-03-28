using System.Collections.Generic;
using Models;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class CustomerDTO
    {
        public int Customer_id { get; set; }

        public string First_name {get; set;}
        public string Last_name { get; set; }
        
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}