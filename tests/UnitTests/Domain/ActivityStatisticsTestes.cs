using PipocaAgilPodcast.Domain;
using Xunit;

namespace tests.UnitTests.Domain
{
    public class ActivityStatisticsTests
    {
        [Fact]
        public void ActivityStatistics_Constructor_InitializesCollections()
        {
            // Arrange
            ActivityStatistics activityStatistics = new ActivityStatistics();

            // Assert
            Assert.NotNull(activityStatistics.User);
            Assert.NotNull(activityStatistics.UsersActivitiesLogs);
        }

        [Fact]
        public void ActivityStatistics_DefaultValues_AreSet()
        {
            // Arrange
            ActivityStatistics activityStatistics = new ActivityStatistics();

            // Assert
            Assert.Equal(0, activityStatistics.TotalActivities);
            Assert.Equal(0, activityStatistics.TotalLikes);
            Assert.Equal(0, activityStatistics.TotalComments);
            Assert.Equal(0, activityStatistics.TotalShares);
        }

        [Fact]
        public void ActivityStatistics_Properties_CanBeSetAndGet()
        {
            // Arrange
            ActivityStatistics activityStatistics = new ActivityStatistics();

            // Act
            activityStatistics.TotalActivities = 10;
            activityStatistics.TotalLikes = 5;
            activityStatistics.TotalComments = 3;
            activityStatistics.TotalShares = 2;

            // Assert
            Assert.Equal(10, activityStatistics.TotalActivities);
            Assert.Equal(5, activityStatistics.TotalLikes);
            Assert.Equal(3, activityStatistics.TotalComments);
            Assert.Equal(2, activityStatistics.TotalShares);
        }
    }
}
