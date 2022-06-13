using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Npgsql;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers

{
    [Route("API/[controller]")]
    [ApiController]
    public class MeasurementsController : Controller
    {
        private string serverKey = Startup.getKey();


        // add measurements function
        [HttpPost]
        [Route ("Measurement")]
        public string AddMeasurement([FromBody] Measurement measurement)
        {
            NpgsqlConnection conn = new NpgsqlConnection(serverKey);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("addMeasurement", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idpatient_r", NpgsqlTypes.NpgsqlDbType.Varchar, measurement.idpatient);
            cmd.Parameters.AddWithValue("oxygen_r", NpgsqlTypes.NpgsqlDbType.Double, measurement.oxygen);
            cmd.Parameters.AddWithValue("temperature_r", NpgsqlTypes.NpgsqlDbType.Double, measurement.temperature);
            cmd.Parameters.AddWithValue("bloodpressure_r", NpgsqlTypes.NpgsqlDbType.Double, measurement.bloodpressure);
            cmd.Parameters.AddWithValue("pulse_r", NpgsqlTypes.NpgsqlDbType.Double, measurement.pulse);
            cmd.Parameters.AddWithValue("timestamp_r", NpgsqlTypes.NpgsqlDbType.Date, measurement.timestamp);
            int var = cmd.ExecuteNonQuery();
            conn.Close();
            String json = JsonConvert.SerializeObject(var);
            return json;
        }

        // get measurements function
        [HttpGet]
        [Route ("Measurement")]
        public List<Measurement> GetMeasurement([FromQuery] string idpatient)
        {
            List<Measurement> measurements = new List<Measurement>();
            NpgsqlConnection conn = new NpgsqlConnection(serverKey);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("getMeasurement", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idpatient_r", NpgsqlTypes.NpgsqlDbType.Varchar, idpatient);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                var measurement = new Measurement();
                measurement.idpatient = dr[0].ToString();
                measurements.Add(measurement);

            }

            conn.Close();
            return measurements;

        }

        public IActionResult Index()
                {
                    return View();
                }
    }
}
