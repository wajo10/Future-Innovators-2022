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
    public class DoctorController : Controller
    {
        private string serverKey = Startup.getKey();
        [HttpGet]
        [Route("LogInDoctor")]

        // log in doctor
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

            while (dr.Read())
            {
                try
                {
                    doctor.iddoctor = dr[0].ToString();
                    doctor.name = dr[1].ToString();
                    doctor.birthdate = (DateTime)dr[2];
                    doctor.phonenumber = dr[3].ToString();
                    doctor.clinic = dr[4].ToString();
                    doctor.location = dr[5].ToString();
                    doctor.email = dr[6].ToString();
                    doctor.specialty = dr[7].ToString();
                    doctor.nameofarea = dr[8].ToString();
                    doctor.password = dr[9].ToString();
                }
                catch
                {
                    conn.Close();
                    return doctor;
                }
                

            }
            return doctor;
        }

        // create doctor function
        [HttpPost]
        [Route("Doctor")]
        public string CreateDoctor([FromBody] Doctor doctor)
        {
            NpgsqlConnection conn = new NpgsqlConnection(serverKey);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("registerDoctor", conn);
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

        // modify doctor function
        [HttpPut]
        [Route("Doctor")]
        public string ModifyDoctor([FromBody] Doctor doctor)
        {
            NpgsqlConnection conn = new NpgsqlConnection(serverKey);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("modifyDoctor", conn);
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

        // get doctor data function 
        [HttpGet]
        [Route ("Doctor")]
        public List<Doctor> GetDoctorData([FromQuery] string iddoctor)
        {
            List<Doctor> data = new List<Doctor>();
            NpgsqlConnection conn = new NpgsqlConnection(serverKey);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("getDoctor", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("iddoctor_r", NpgsqlTypes.NpgsqlDbType.Varchar, iddoctor);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                var doctor = new Doctor();
                doctor.iddoctor = dr[0].ToString();
                doctor.name = dr[1].ToString();
                doctor.birthdate = (DateTime)dr[2];
                doctor.phonenumber = dr[3].ToString();
                doctor.clinic = dr[4].ToString();
                doctor.location = dr[5].ToString();
                doctor.email = dr[6].ToString();
                doctor.specialty = dr[7].ToString();
                doctor.nameofarea = dr[8].ToString();
                doctor.password = dr[9].ToString();
                data.Add(doctor);
            }

            conn.Close();
            return data;
        }

        // add area function
        [HttpPost]
        [Route ("Area")]
        public string AddArea([FromBody] Area area)
        {
            NpgsqlConnection conn = new NpgsqlConnection(serverKey);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("addArea", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("name_r", NpgsqlTypes.NpgsqlDbType.Varchar, area.name);
            int var = cmd.ExecuteNonQuery();
            conn.Close();
            String json = JsonConvert.SerializeObject(var);
            return json;

        }

        // add area doctor
        [HttpPost]
        [Route("AreaDoctor")]
        public String AddAreaDoctor([FromBody] AssignedArea assignedArea)
        {
            NpgsqlConnection conn = new NpgsqlConnection(serverKey);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("addAreaDoctor", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idarea_r", NpgsqlTypes.NpgsqlDbType.Integer, assignedArea.idarea);
            cmd.Parameters.AddWithValue("iddoctor_r", NpgsqlTypes.NpgsqlDbType.Varchar, assignedArea.iddoctor);
            int var = cmd.ExecuteNonQuery();
            conn.Close();
            String json = JsonConvert.SerializeObject(var);
            return json;

        }

        // get assigned area from idarea
        [HttpGet]
        [Route("AreaArea")]
        public List<AssignedArea> GetAreaArea([FromQuery] int idArea)
        {
            List<AssignedArea> data = new List<AssignedArea>();
            NpgsqlConnection conn = new NpgsqlConnection(serverKey);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("getAssignedAreaArea", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idarea_r", NpgsqlTypes.NpgsqlDbType.Integer, idArea);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                var assignedArea = new AssignedArea();
                assignedArea.idassignment = (int) dr[0];
                assignedArea.idarea = (int)dr[1];
                assignedArea.iddoctor = dr[2].ToString();

                data.Add(assignedArea);
            }

            conn.Close();
            return data;
        }

        // get area from doctor
        [HttpGet]
        [Route("AreaDoctor")]
        public List<AssignedArea> GetAreaDoctor([FromQuery] int idDoctor)
        {
            List<AssignedArea> data = new List<AssignedArea>();
            NpgsqlConnection conn = new NpgsqlConnection(serverKey);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("getAssignedAreaDoctor", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idarea_r", NpgsqlTypes.NpgsqlDbType.Integer, idDoctor);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                var assignedArea = new AssignedArea();
                assignedArea.idassignment = (int)dr[0];
                assignedArea.idarea = (int)dr[1];
                assignedArea.iddoctor = dr[2].ToString();

                data.Add(assignedArea);
            }

            conn.Close();
            return data;
        }


        // get all areas
        [HttpGet]
        [Route("Area")]
        public List<Area> GetAllAreas()
        {
            List<Area> areas = new List<Area>();
            NpgsqlConnection conn = new NpgsqlConnection(serverKey);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("getAllAreas", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            NpgsqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                var area = new Area();
                area.idarea = (int)dr[0];
                area.name = dr[1].ToString();
                areas.Add(area);
            }
            conn.Close();
            return areas;
        }

        // get doctor --> patient 
        [HttpGet]
        [Route("Assignment")]
        public List<Assignment> GetDoctorPatientAssignment([FromQuery] string iddoctor)
        {
            List<Assignment> assignments = new List<Assignment>();
            NpgsqlConnection conn = new NpgsqlConnection(serverKey);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("getDoctorPatient", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("iddoctor_r", NpgsqlTypes.NpgsqlDbType.Varchar, iddoctor);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                var assignment = new Assignment();
                assignment.idassignment = (int)dr[0];
                assignment.idpatient = dr[1].ToString();
                assignment.iddoctor = dr[2].ToString();
                assignments.Add(assignment);
            }

            conn.Close();
            return assignments;
        }
    }
}
