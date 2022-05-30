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
    public class PatientController : Controller
    {
        private string serverKey = Startup.getKey();
        [HttpGet]
        [Route("LogInPatient")]

        public Patient LogIn([FromQuery] string idPatient, string password)
        {
            var patient = new Patient();
            NpgsqlConnection conn = new NpgsqlConnection(serverKey);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("loginPatient", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idpatient_r", NpgsqlTypes.NpgsqlDbType.Text, idPatient);
            cmd.Parameters.AddWithValue("@password_r", NpgsqlTypes.NpgsqlDbType.Text, password);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            conn.Close();

            while (dr.Read())
            {
                patient.idpatient = dr[0].ToString();
                patient.name = dr[1].ToString();
                patient.email = dr[2].ToString();
                patient.birthdate = (DateTime)dr[3];
                patient.phonenumber = dr[4].ToString();
                patient.location = dr[5].ToString();
                patient.height = (float)dr[6];
                patient.weight = (float)dr[7];
                patient.password = dr[8].ToString();

            }
            return patient;
        }  
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("Patient"]
        public string CreatePatient([FromBody] Patient patient)
        {
            var patient = new Patient();
            NpgsqlConnection conn = new NpgsqlConnection(serverKey);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("addPatient", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idpatient_r", NpgsqlTypes.NpgsqlDbType.Varchar, patient.idpatient);
            cmd.Parameters.AddWithValue("name_r", NpgsqlTypes.NpgsqlDbType.Varchar, patient.name);
            cmd.Parameters.AddWithValue("email_r", NpgsqlTypes.NpgsqlDbType.Varchar, patient.email);
            cmd.Parameters.AddWithValue("birthdate_r", NpgsqlTypes.NpgsqlDbType.Date, patient.birthdate);
            cmd.Parameters.AddWithValue("phonenumber_r", NpgsqlTypes.NpgsqlDbType.Varchar, patient.phonenumber);
            cmd.Parameters.AddWithValue("location_r", NpgsqlTypes.NpgsqlDbType.Varchar, patient.location);
            cmd.Parameters.AddWithValue("height_r", NpgsqlTypes.NpgsqlDbType., patient.height);
            cmd.Parameters.AddWithValue("weight_r", NpgsqlTypes.NpgsqlDbType., patient.weight);
            cmd.Parameters.AddWithValue("password_r", NpgsqlTypes.NpgsqlDbType., patient.password);
            int var = cmd.ExecuteNonQuery();
            conn.Close();
            String json = JsonConvert.SerializeObject(var);
            return json;
        }
    }
}