using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment2_WebAPI.Models
{
    public class Customer_User
    {
        [Key]
        public string Cust_Username { get; set; }
        [Required]
        public string Cust_Password { get; set; }
        public string Cust_Fname { get; set; }
        public string Cust_Lname { get; set; }
        public string Cust_Phone { get; set; }
        public string Cust_Address { get; set; }
        public string Cust_Country { get; set; }
        
    }
}
