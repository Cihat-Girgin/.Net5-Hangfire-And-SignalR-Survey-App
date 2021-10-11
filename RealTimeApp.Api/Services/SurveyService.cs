using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using RealTimeApp.Api.Hubs;
using RealTimeApp.Api.Models;

namespace RealTimeApp.Api.Services
{
    public class SurveyService:ISurveyService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IHubContext<MainHub> _hubContext;

        public SurveyService(DatabaseContext databaseContext, IHubContext<MainHub> hubContext)
        {
            _databaseContext = databaseContext;
            _hubContext = hubContext;
        }

        public async Task AddSurveyItem(SurveyItem surveyItem)
        {
            if (SurveyItemCount() > 200)
            {
                 _databaseContext.Database.ExecuteSqlRaw("delete from SurveyItems");
                _databaseContext.Database.CloseConnection();
            }
           await _databaseContext.AddAsync(surveyItem);
           await _databaseContext.SaveChangesAsync();
           await _hubContext.Clients.All.SendAsync("SurveyDataset", GetBackendFrameworksWithCounts());
        }
        public async Task<List<SurveyItem>> GetAllSurveyItems()
        {
          return  await _databaseContext.SurveyItems.ToListAsync();
        }
        public async Task<List<BackendFramework>> GetBackendFrameworks()
        {
            return  await _databaseContext.BackendFrameworks.ToListAsync();
        }

        public List<SurveyItemDto> GetBackendFrameworksWithCounts()
        {
            List<SurveyItemDto> surveyItemDtos = _databaseContext.SurveyItems
                .Join(_databaseContext.BackendFrameworks, surveyItem => surveyItem.BackendFrameworkId, framework => framework.Id,
                    ((surveyItem, framework) => new SurveyItemDto {Name = framework.Name, Count = 1})).ToList();
            surveyItemDtos = surveyItemDtos.GroupBy(i => i.Name).Select(x => new SurveyItemDto {Name = x.Key, Count = x.Count()}).ToList();
            return surveyItemDtos;
        }

        private int SurveyItemCount()
        {
            return _databaseContext.SurveyItems.Count();
        }
    }
}