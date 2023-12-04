using PipocaAgilPodcast.Domain;
using PipocaAgilPodcast.Domain.Enum;
using PipocaAgilPodcast.Interfaces.ContractsServices;

namespace PipocaAgilPodcast.Persistence.DataImplementations;

public class ActivityLogPersistence : IActivityLogService
{
    public Task<IEnumerable<ActivityLog>> ExportActivityLogAsync(DateTime startDate, DateTime endDate)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ActivityLog>> GetActivityByTypeAsync(ActivityType activityType)
    {
        throw new NotImplementedException();
    }

    public Task<ActivityLog> GetActivityLogByIdAsync(int activityLogId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ActivityLog>> GetActivityLogsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ActivityLog>> GetActivityLogsForUserAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<ActivityStatistics> GetActivityStatisticsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ActivityLog>> GetRecentActivityAsync(int count)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<ActivityLog>> GetUserActivityHistoryAsync(int userId)
    {
        throw new NotImplementedException();
    }
}
