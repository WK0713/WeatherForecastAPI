using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using WeatherForecastAPI.Model;

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

        [Route("DailyForecast")]
        [HttpGet]
        public async Task<JsonResult> GetDailyForecast(string lat, string lon)
        {
            var oneCallApiResponse = new OneCallApiResponse();
            using (var httpClient = new HttpClient())
            {
                string apiLink = _configuration["OpenWeatherApi:BaseAddress"].ToString() + $"&lat={lat}&lon={lon}";
                using (var response = await httpClient.GetAsync(apiLink))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    oneCallApiResponse = JsonConvert.DeserializeObject< OneCallApiResponse>(apiResponse);
                }
            }
            if (oneCallApiResponse != null)
            {
                oneCallApiResponse.daily.RemoveRange(4, 4);
                return new JsonResult(oneCallApiResponse.daily);
            }
            return new JsonResult(new DailyForecast());
        }
    }
}
