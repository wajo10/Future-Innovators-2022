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
            NpgsqlCommand cmd = new NpgsqlCommand("modifydoctor", conn);
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
S
        // get area assignment function
        [HttpGet]
        [Route("AssignedArea")]
        public List<Area> GetAreaAssignment([FromQuery] string iddoctor)
        {
            List<AssignedArea> assignedAreas = new List<AssignedArea>();
            List<Area> areas = new List<Area>();
            NpgsqlConnection conn = new NpgsqlConnection(serverKey);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("getAssignedArea", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("iddoctor_r", NpgsqlTypes.NpgsqlDbType.Varchar, iddoctor);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            

            while (dr.Read())
            {
                var assignedArea = new AssignedArea();
                assignedArea.idassignment = (int)dr[0];
                assignedArea.idarea = (int)dr[1];
                assignedArea.iddoctor = dr[2].ToString();
                assignedAreas.Add(assignedArea);
            }

            foreach(AssignedArea assignedArea in assignedAreas)
            {
                conn.Open();
                cmd = new NpgsqlCommand("getArea", conn);
                cmd.Parameters.AddWithValue("idarea_r", NpgsqlTypes.NpgsqlDbType.Integer, assignedArea.idarea);
                NpgsqlDataReader drArea = cmd.ExecuteReader();
                while (drArea.Read())
                {
                    var area = new Area();
                    area.idarea = (int)dr[0];
                    area.name = dr[2].ToString();
                    areas.Add(area);
                }
                conn.Close();
            }

            conn.Close();
            return areas;
        }

        // get doctor --> patient 
        [HttpGet]
        [Route("Assignment")]
        public List<Assignment> GetDoctorPatientAssignment([FromQuery] string idpatient)
        {
            List<Assignment> assignments = new List<Assignment>();
            NpgsqlConnection conn = new NpgsqlConnection(serverKey);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("getDoctorPatient", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idpatient_r", NpgsqlTypes.NpgsqlDbType.Varchar, idpatient);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                var assignment = new Assignment();
                assignment.idpatient = dr[0].ToString();
                assignments.Add(assignment);
            }

            conn.Close();
            return assignments;
        }
    }
}
