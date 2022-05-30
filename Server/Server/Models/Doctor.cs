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
        public DateTime birthdate;
        public string phonenumber;
        public string clinic;
        public string location;
        public string email;
        public string specialty;
        public string nameofarea;
        public string password { get; set; }

    }
}
