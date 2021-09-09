using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment2_WebAPI.Models
{
    public class Rent_Details
    {
        public int Id { get; set; }
        
        public Rent_Agent Rent_Agent { get; set; }
        
        public Rent_Houses Rent_Houses { get; set; }


    }
}
