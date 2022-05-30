using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Medication
    {
        public string idpatient { get; set; }
        public int idmedication { get; set; }
        public string name { get; set; }
        public string dose { get; set; }

    }
}
