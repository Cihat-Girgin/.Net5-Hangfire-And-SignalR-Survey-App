using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using RealTimeApp.Api.Services;

namespace RealTimeApp.Api.Hubs
{
    public class MainHub:Hub
    {
        private readonly ISurveyService _surveyService;

        public MainHub(ISurveyService surveyService)
        {
            _surveyService = surveyService;
        }

        public async Task GetSurveyDataset()
        {
            await Clients.All.SendAsync("SurveyDataset", _surveyService.GetBackendFrameworksWithCounts());
        }
    }
}
