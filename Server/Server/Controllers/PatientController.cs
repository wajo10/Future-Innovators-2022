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
                try
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
                catch
                {
                    conn.Close();
                    return patient;
                }

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
            NpgsqlCommand cmd = new NpgsqlCommand("modifyUser", conn);
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

        // get patient data function 
        [HttpGet]
        [Route("Patient")]
        public List<Patient> GetPatientData([FromQuery] string idpatient)
        {
            List<Patient> data = new List<Patient>();
            NpgsqlConnection conn = new NpgsqlConnection(serverKey);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("getPatient", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idpatient_r", NpgsqlTypes.NpgsqlDbType.Varchar, idpatient);
            NpgsqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                var patient = new Patient();
                patient.idpatient = dr[0].ToString();
                patient.name = dr[1].ToString();
                patient.email = dr[2].ToString();
                patient.birthdate = (DateTime)dr[3];
                patient.phonenumber = dr[4].ToString();
                patient.location = dr[5].ToString();
                patient.height = (Double)dr[6];
                patient.weight = (Double)dr[7];
                patient.password = dr[8].ToString();
                data.Add(patient);
            }

            conn.Close();
            return data;
        }


        // add illness function
        [HttpPost]
        [Route("Illness")]
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
        public List<Illness> GetIllness([FromQuery] string idpatient)
        {
            List<Illness> illnesses = new List<Illness>();
            NpgsqlConnection conn = new NpgsqlConnection(serverKey);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("getIllness", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idpatient_r", NpgsqlTypes.NpgsqlDbType.Varchar, idpatient);
            NpgsqlDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                var illness = new Illness();
                illness.idpatient = dr[0].ToString();
                illness.name = dr[2].ToString();
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
                allergy.name = dr[2].ToString();
                allergies.Add(allergy);
            }

            conn.Close();
            return allergies;
        }

        // get medications function
        [HttpGet]
        [Route("Medication")]
        public List<Medication> GetMedication([FromQuery] string idpatient)
        {
            List<Medication> medications = new List<Medication>();
            NpgsqlConnection conn = new NpgsqlConnection(serverKey);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("getMedication", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idpatient_r", NpgsqlTypes.NpgsqlDbType.Varchar, idpatient);
            NpgsqlDataReader dr = cmd.ExecuteReader();


            while (dr.Read())
            {
                var medication = new Medication();
                medication.idpatient = dr[0].ToString();
                medication.name = dr[2].ToString();
                medication.dose = dr[3].ToString();
                medications.Add(medication);
            }

            conn.Close();
            return medications;
        }

        // get patient --> doctor assignment
        [HttpGet]
        [Route("Assignment")]
        public List<Assignment> GetPatientDoctorAssignment([FromQuery] string idpatient)
        {
            List<Assignment> assignments = new List<Assignment>();
            NpgsqlConnection conn = new NpgsqlConnection(serverKey);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("getPatientDoctor", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idpatient_r", NpgsqlTypes.NpgsqlDbType.Varchar, idpatient);
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