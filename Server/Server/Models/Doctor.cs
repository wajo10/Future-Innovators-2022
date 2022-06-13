using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Doctor
    {
        public string iddoctor { get; set; }
        public string name { get; set; }
        public DateTime birthdate { get; set; }
        public string phonenumber { get; set; }
        public string clinic { get; set; }
        public string location { get; set; }
        public string email { get; set; }
        public string specialty { get; set; }
        public string nameofarea { get; set; }
        public string password { get; set; }

    }
}
