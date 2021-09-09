using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment2_WebAPI.Models
{
    public class Rent_Agent
    {
        public int Id { get; set; }
        public string Agent_Name { get; set; }
        public string Agent_Email { get; set; }

        public string Agent_Phone { get; set; }
        public string Agent_Office { get; set; }
    }
}
