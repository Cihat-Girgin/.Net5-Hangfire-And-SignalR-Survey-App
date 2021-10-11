using System.Collections.Generic;
using System.Threading.Tasks;
using RealTimeApp.Api.Models;

namespace RealTimeApp.Api.Services
{
    public interface ISurveyService
    {
        Task AddSurveyItem(SurveyItem surveyItem);
        Task<List<SurveyItem>> GetAllSurveyItems();
        Task<List<BackendFramework>> GetBackendFrameworks();
        List<SurveyItemDto> GetBackendFrameworksWithCounts();

    }
}