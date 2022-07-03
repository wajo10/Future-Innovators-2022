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

        // log in function
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
            

            while (dr.Read())
            {
                patient.idpatient = dr[0].ToString();
                patient.name = dr[1].ToString();
                patient.email = dr[2].ToString();
                patient.birthdate = (DateTime)dr[3];
                patient.phonenumber = dr[4].ToString();
                patient.location = dr[5].ToString();
                patient.height = (Double)dr[6];
                patient.weight = (Double)dr[7];
                patient.password = dr[8].ToString();

            }
            conn.Close();
            return patient;
        }  
        
        public IActionResult Index()
        {
            return View();
        }


        // create patient function
        [HttpPost]
        [Route("Patient")]
        public string CreatePatient([FromBody] Patient patient)
        {
            NpgsqlConnection conn = new NpgsqlConnection(serverKey);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("registerUser", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idpatient_r", NpgsqlTypes.NpgsqlDbType.Varchar, patient.idpatient);
            cmd.Parameters.AddWithValue("name_r", NpgsqlTypes.NpgsqlDbType.Varchar, patient.name);
            cmd.Parameters.AddWithValue("email_r", NpgsqlTypes.NpgsqlDbType.Varchar, patient.email);
            cmd.Parameters.AddWithValue("birthdate_r", NpgsqlTypes.NpgsqlDbType.Date, patient.birthdate);
            cmd.Parameters.AddWithValue("phonenumber_r", NpgsqlTypes.NpgsqlDbType.Varchar, patient.phonenumber);
            cmd.Parameters.AddWithValue("location_r", NpgsqlTypes.NpgsqlDbType.Varchar, patient.location);
            cmd.Parameters.AddWithValue("height_r", NpgsqlTypes.NpgsqlDbType.Double, patient.height);
            cmd.Parameters.AddWithValue("weight_r", NpgsqlTypes.NpgsqlDbType.Double, patient.weight);
            cmd.Parameters.AddWithValue("password_r", NpgsqlTypes.NpgsqlDbType.Varchar, patient.password);
            int var = cmd.ExecuteNonQuery();
            conn.Close();
            String json = JsonConvert.SerializeObject(var);
            return json;
        }

        // modify patient function
        [HttpPut]
        [Route("Patient")]
        public string ModifyPatient([FromBody] Patient patient)
        {
            NpgsqlConnection conn = new NpgsqlConnection(serverKey);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("modifyPatient", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idpatient_r", NpgsqlTypes.NpgsqlDbType.Varchar, patient.idpatient);
            cmd.Parameters.AddWithValue("name_r", NpgsqlTypes.NpgsqlDbType.Varchar, patient.name);
            cmd.Parameters.AddWithValue("email_r", NpgsqlTypes.NpgsqlDbType.Varchar, patient.email);
            cmd.Parameters.AddWithValue("birthdate_r", NpgsqlTypes.NpgsqlDbType.Date, patient.birthdate);
            cmd.Parameters.AddWithValue("phonenumber_r", NpgsqlTypes.NpgsqlDbType.Varchar, patient.phonenumber);
            cmd.Parameters.AddWithValue("location_r", NpgsqlTypes.NpgsqlDbType.Varchar, patient.location);
            cmd.Parameters.AddWithValue("height_r", NpgsqlTypes.NpgsqlDbType.Double, patient.height);
            cmd.Parameters.AddWithValue("weight_r", NpgsqlTypes.NpgsqlDbType.Double, patient.weight);
            cmd.Parameters.AddWithValue("password_r", NpgsqlTypes.NpgsqlDbType.Varchar, patient.password);
            int var = cmd.ExecuteNonQuery();
            conn.Close();
            String json = JsonConvert.SerializeObject(var);
            return json;
        }

        // add illness function
        [HttpPost]
        [Route ("Illness")]
        public string AddIllness([FromBody] Illness illness)
        {
            NpgsqlConnection conn = new NpgsqlConnection(serverKey);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("addIllness", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("name_r", NpgsqlTypes.NpgsqlDbType.Varchar, illness.name);
            cmd.Parameters.AddWithValue("idpatient_r", NpgsqlTypes.NpgsqlDbType.Varchar, illness.idpatient);
            int var = cmd.ExecuteNonQuery();
            conn.Close();
            String json = JsonConvert.SerializeObject(var);
            return json;
        }

        // add allergy function
        [HttpPost]
        [Route("Allergy")]
        public string AddAllergy([FromBody] Allergy allergy)
        {
            NpgsqlConnection conn = new NpgsqlConnection(serverKey);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("addAllergy", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("name_r", NpgsqlTypes.NpgsqlDbType.Varchar, allergy.name);
            cmd.Parameters.AddWithValue("idpatient_r", NpgsqlTypes.NpgsqlDbType.Varchar, allergy.idpatient);
            int var = cmd.ExecuteNonQuery();
            conn.Close();
            String json = JsonConvert.SerializeObject(var);
            return json;
        }

        // add medication function
        [HttpPost]
        [Route("Medication")]
        public string AddMedication([FromBody] Medication medication)
        {
            NpgsqlConnection conn = new NpgsqlConnection(serverKey);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("addMedication", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("name_r", NpgsqlTypes.NpgsqlDbType.Varchar, medication.name);
            cmd.Parameters.AddWithValue("dose_r", NpgsqlTypes.NpgsqlDbType.Varchar, medication.dose);
            cmd.Parameters.AddWithValue("idpatient_r", NpgsqlTypes.NpgsqlDbType.Varchar, medication.idpatient);
            int var = cmd.ExecuteNonQuery();
            conn.Close();
            String json = JsonConvert.SerializeObject(var);
            return json;
        }


        // get illnesses function
        [HttpGet]
        [Route("Illness")]
        public List<Illness> GetIllness([FromQuery] int idillness)
        {
            List<Illness> illnesses = new List<Illness>();
            NpgsqlConnection conn = new NpgsqlConnection(serverKey);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("getIllness", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idillness_r", NpgsqlTypes.NpgsqlDbType.Integer, idillness);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            

            while (dr.Read())
            {
                var illness = new Illness();
                illness.idillness = (int)dr[0];
                illnesses.Add(illness);
            }

            conn.Close();
            return illnesses;

        }

        // get allergies function
        [HttpGet]
        [Route("Allergy")]
        public List<Allergy> GetAllergy([FromQuery] string idpatient)
        {
            List<Allergy> allergies = new List<Allergy>();
            NpgsqlConnection conn = new NpgsqlConnection(serverKey);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("getAllergy", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idpatient_r", NpgsqlTypes.NpgsqlDbType.Varchar, idpatient);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            

            while (dr.Read())
            {
                var allergy = new Allergy();
                allergy.idpatient = dr[0].ToString();
                allergy.name = dr[1].ToString();
                allergies.Add(allergy);
            }

            conn.Close();
            return allergies;
        }

        // get medications function
        [HttpGet]
        [Route("Medication")]
        public List<Medication> GetMedication([FromQuery] int idmedication)
        {
            List<Medication> medications = new List<Medication>();
            NpgsqlConnection conn = new NpgsqlConnection(serverKey);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("getMedication", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idmedication_r", NpgsqlTypes.NpgsqlDbType.Integer, idmedication);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            

            while (dr.Read())
            {
                var medication = new Medication();
                medication.idmedication = (int)dr[0];
                medications.Add(medication);
            }

            conn.Close();
            return medications;
        }

        // get patient --> doctor assignment
        [HttpGet]
        [Route("Assignment")]
        public List<Assignment> GetPatientDoctorAssignment([FromQuery] string iddoctor)
        {
            List<Assignment> assignments = new List<Assignment>();
            NpgsqlConnection conn = new NpgsqlConnection(serverKey);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("getPatientDoctor", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("iddoctor_r", NpgsqlTypes.NpgsqlDbType.Varchar, iddoctor);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            

            while (dr.Read())
            {
                var assignment = new Assignment();
                assignment.iddoctor = dr[0].ToString();
                assignments.Add(assignment);
            }

            conn.Close();
            return assignments;
        }
    }
}