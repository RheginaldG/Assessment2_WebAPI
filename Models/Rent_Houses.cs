using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment2_WebAPI.Models
{
    public class Rent_Houses
    {
        public int Id { get; set; }
        public string House_Title { get; set; }
        public string House_Address { get; set; }

        public double House_WeeklyRent { get; set; }

        public int House_Bedroom { get; set; }
        public int House_Bathroom { get; set; }

    }
}
