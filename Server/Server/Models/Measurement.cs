using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Measurement
    {
        public int idmeasurement { get; set; }
        public string idpatient { get; set; }
        public Double oxygen { get; set; }
        public Double temperature { get; set; }
        public Double bloodpressure { get; set; }
        public Double pulse { get; set; }
        public DateTime timestamp { get; set; }


    }
}
