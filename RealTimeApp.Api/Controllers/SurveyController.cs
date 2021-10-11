using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
using RealTimeApp.Api.Jobs;
using RealTimeApp.Api.Services;

namespace RealTimeApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService _surveyService;

        public SurveyController(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        [HttpGet]
        public async Task<IActionResult> StartJob()
        {
            try
            {
                InsertSurveyItemJob insertSurveyItemJob = new(_surveyService);
            
                insertSurveyItemJob.Insert();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Problem(e.Message);
            }
            
            return Ok("Service was started.");
        }
    }
}
