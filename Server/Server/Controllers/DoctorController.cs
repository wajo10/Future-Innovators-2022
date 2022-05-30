using Microsoft.AspNetCore.Mvc;
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
    public class DoctorController : Controller
    {
        private string serverKey = Startup.getKey();
        [HttpGet]
        [Route("LogInDoctor")]

        public Doctor LogIn([FromQuery] string idDoctor, string password)
        {
            var doctor = new Doctor();
            NpgsqlConnection conn = new NpgsqlConnection(serverKey);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("logindoctor", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("iddoctor_r", NpgsqlTypes.NpgsqlDbType.Text, idDoctor);
            cmd.Parameters.AddWithValue("password_r", NpgsqlTypes.NpgsqlDbType.Text, password);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            conn.Close();

            while (dr.Read())
            {
                doctor.iddoctor = dr[0].ToString();
                doctor.name = dr[1].ToString();
                doctor.birthdate = (DateTime)dr[2];
                doctor.phonenumber = dr[3].ToString();
                doctor.location = dr[4].ToString();
                doctor.email = dr[5].ToString();
                doctor.specialty = dr[6].ToString();
                doctor.nameofarea = dr[7].ToString();
                doctor.password = dr[8].ToString();

            }
            return doctor;
        }

        public string CreateDoctor([FromBody] Doctor doctor)
        {
            var doctor = new Doctor();
            NpgsqlConnection conn = new NpgsqlConnection(serverKey);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("addDoctor", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("iddoctor_r", NpgsqlTypes.NpgsqlDbType.Varchar, doctor.iddoctor);
            cmd.Parameters.AddWithValue("name_r", NpgsqlTypes.NpgsqlDbType.Varchar, doctor.name);
            cmd.Parameters.AddWithValue("birthdate_r", NpgsqlTypes.NpgsqlDbType.Date, doctor.birthdate);
            cmd.Parameters.AddWithValue("phonenumber_r", NpgsqlTypes.NpgsqlDbType.Varchar, doctor.phonenumber);
            cmd.Parameters.AddWithValue("clinic_r", NpgsqlTypes.NpgsqlDbType.Varchar, doctor.clinic);
            cmd.Parameters.AddWithValue("location_r", NpgsqlTypes.NpgsqlDbType.Varchar, doctor.location);
            cmd.Parameters.AddWithValue("email_r", NpgsqlTypes.NpgsqlDbType.Varchar, doctor.email);
            cmd.Parameters.AddWithValue("specialty_r", NpgsqlTypes.NpgsqlDbType.Varchar, doctor.specialty);
            cmd.Parameters.AddWithValue("nameofarea_r", NpgsqlTypes.NpgsqlDbType.Varchar, doctor.nameofarea);
            cmd.Parameters.AddWithValue("password_r", NpgsqlTypes.NpgsqlDbType.Varchar, doctor.password);
            int var = cmd.ExecuteNonQuery();
            conn.Close();
            String json = JsonConvert.SerializeObject(var);
            return json;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
