using PipocaAgilPodcast.Domain;
using PipocaAgilPodcast.Domain.Enum;
using PipocaAgilPodcast.Interfaces.ContractsPersistence;

namespace PipocaAgilPodcast.Persistence.DataImplementations;

public class ActivityLogPersistence : IActivityLogPersistence
{
    public void Add<T>(T entity) where T : class
    {
        throw new NotImplementedException();
    }

    public void Delete<T>(T entity) where T : class
    {
        throw new NotImplementedException();
    }

    public void DeleteRange<T>(T[] entity) where T : class
    {
        throw new NotImplementedException();
    }

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

    public Task<bool> SaveChangesAsync()
    {
        throw new NotImplementedException();
    }

    public void Update<T>(T entity) where T : class
    {
        throw new NotImplementedException();
    }
}
