using PipocaAgilPodcast.Domain;
using PipocaAgilPodcast.Domain.Enum;

namespace PipocaAgilPodcast.Interfaces.ContractsPersistence;

    public interface IActivityLogPersistence : IRepositoryPesistence
    {
        Task<ActivityStatistics> GetActivityStatisticsAsync();
        Task<ActivityLog> GetActivityLogByIdAsync(int activityLogId);
        Task<IEnumerable<ActivityLog>> GetActivityLogsAsync();
        Task<IEnumerable<ActivityLog>> GetActivityLogsForUserAsync(int userId);
        Task<IEnumerable<ActivityLog>> GetRecentActivityAsync(int count);
        Task<IEnumerable<ActivityLog>> ExportActivityLogAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<ActivityLog>> GetActivityByTypeAsync(ActivityType activityType);
        Task<IEnumerable<ActivityLog>> GetUserActivityHistoryAsync(int userId);
    }
