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
    public class AssignmentController : Controller
    {
        private string serverKey = Startup.getKey();


        // doctor - patient assignment function
        [HttpPost]
        [Route ("Assignment")]
        public string AddAssignment([FromBody] Assignment assignment)
        {
            NpgsqlConnection conn = new NpgsqlConnection(serverKey);
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand("addAssignment", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("idpatient_r", NpgsqlTypes.NpgsqlDbType.Varchar, assignment.idpatient);
            cmd.Parameters.AddWithValue("iddoctor_r", NpgsqlTypes.NpgsqlDbType.Varchar, assignment.iddoctor);
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
