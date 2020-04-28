using Core3Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using Oracle.ManagedDataAccess.Client;

namespace Core3Api.Controllers
{
    [Route("/")]
    public class HomeController : ControllerBase
    {
        private IMessageService _messageService;

        public HomeController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IActionResult Get()
        {
            string emailSvr = Environment.GetEnvironmentVariable("EmailServer"); 
            string connectionString = Environment.GetEnvironmentVariable("ConnectionString");
            string name = "";
            string error_message = "";
            //connectionString = "User Id = scott; Password = 12345; Data Source = localhost:1521/orcl;";

            try
            {
                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    string queryString = "Select * from emp";
                    OracleCommand command = new OracleCommand(queryString, connection);
                    command.Connection.Open();
                    OracleGlobalization info = command.Connection.GetSessionInfo(); //this.Connection.GetSessionInfo();
                    info.TimeZone = "America/New_York";
                    command.Connection.SetSessionInfo(info);
                    //this.Connection.SetSessionInfo(info);
                    //command.ExecuteNonQuery();
                    OracleDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        name = reader.GetString(1);
                        break;
                    }
                }
            }
            catch(Exception ex)
            {
                error_message = ex.Message.ToString();
            }
            

            return Ok("hello world "+ name +" " + emailSvr+" "+connectionString+ " ### " + error_message);

			//string OC_Evariable = Environment.GetEnvironmentVariable("OC_HC_URL");
            //return Ok("hello world " + emailSvr+" "+connectionString+" "+OC_Evariable);

        }
    }
}