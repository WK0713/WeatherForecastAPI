using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;

namespace WeatherForecastAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        SqlConnection sqlConnection;

        public WeatherForecastController(IConfiguration configuration)
        {
            _configuration = configuration;
            sqlConnection = new SqlConnection(_configuration.GetConnectionString("WeatherForecast"));
        }

        [Route("ListOfCities")]
        [HttpGet]
        public JsonResult GetCitiesList()
        {
            string query = "SELECT City, State, Country, Latitude, Longitude FROM CityDetails";
            DataTable table = new DataTable();
            SqlDataReader sqlReader;
            using (sqlConnection)
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    sqlReader = sqlCommand.ExecuteReader();
                    table.Load(sqlReader);
                    sqlReader.Close();
                    sqlConnection.Close();
                }
            }
            return new JsonResult(table);
        }
    }
}
