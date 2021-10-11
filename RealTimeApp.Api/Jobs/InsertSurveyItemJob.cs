using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Hangfire;
using RealTimeApp.Api.Models;
using RealTimeApp.Api.Services;

namespace RealTimeApp.Api.Jobs
{
    public class InsertSurveyItemJob
    {
        private readonly ISurveyService _surveyService;
        private static List<BackendFramework> _backendFrameworks;

        public InsertSurveyItemJob(ISurveyService surveyService)
        {
            _surveyService = surveyService;
            _backendFrameworks = _surveyService.GetBackendFrameworks().Result;
        }

        public void Insert()
        {
            RecurringJob.AddOrUpdate("InsertData",()=>InsertRandomSurveyItem(),Cron.Minutely);
        }

        public void InsertRandomSurveyItem()
        {
            
            Random random = new();
            Enumerable.Range(0, 60).ToList().ForEach(x => {
                var surveyItem = _backendFrameworks[random.Next(_backendFrameworks.Count)];
                _surveyService.AddSurveyItem(new SurveyItem { BackendFrameworkId = surveyItem.Id }).Wait();
                Thread.Sleep(1000);
            });
        }
    }
}