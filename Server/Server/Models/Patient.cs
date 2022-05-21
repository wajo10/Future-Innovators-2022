using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Patient
    {
        public string idpatient { get; set; }
        public string name { get; set; }
        public string email;
        public string birthdate;
        public string phonenumber;
        public string location;
        public float height;
        public float weight;
        public string password { get; set; }

    }
}
