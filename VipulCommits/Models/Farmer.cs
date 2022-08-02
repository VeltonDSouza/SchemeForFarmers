using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchemeForFarmers_BackEnd_WebAPI.Models
{
    public class Farmer
    {
        public int userId { get; set; }

        public String email { get; set; }

        public String password { get; set; }

        public String name { get; set; }

        public String contact { get; set; }

        public String address { get; set; }

        public String city { get; set; }

        public String State { get; set; }

        public String pincode { get; set; }

        public int landArea { get; set; }
        public String landAddress { get; set; }

        public String landPincode { get; set; }

        public String accNo { get; set; }

        public String iifc { get; set; }

        public String adhaar { get; set; }

        public String pan { get; set; }

        public String certi { get; set; }
    }
}
