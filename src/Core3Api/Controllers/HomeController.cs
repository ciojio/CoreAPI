using Core3Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;

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
			string OC_Evariable = Environment.GetEnvironmentVariable("OC_HC_URL");
            return Ok("hello world " + emailSvr+" "+connectionString+" "+OC_Evariable);
        }
    }
}