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
        public string email { get; set; }
        public DateTime birthdate { get; set; }
        public string phonenumber { get; set; }
        public string location { get; set; }
        public Double height { get; set; }
        public Double weight { get; set; }
        public string password { get; set; }

    }
}
