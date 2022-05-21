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
        public float oxygen { get; set; }
        public float temperature { get; set; }
        public float bloodpressure { get; set; }
        public float pulse { get; set; }
        public DateTime timestamp { get; set; }


    }
}
