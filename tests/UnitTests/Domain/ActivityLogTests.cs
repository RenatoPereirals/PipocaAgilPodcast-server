using PipocaAgilPodcast.Domain;
using PipocaAgilPodcast.Domain.Enum;
using Xunit;

namespace tests.UnitTests.Domain;

    public class ActivityLogTests
    {
        [Fact]
         public void ActivityLog_Constructor_InitializesCollections()
        {
            // Arrange
            ActivityLog activityLog = new ActivityLog();

            // Assert
            Assert.NotNull (activityLog.UsersActivitiesLogs);
        }
        [Fact]
        public void ActivityLog_DefaultValues_AreSet()
        {
            // Arrange
            ActivityLog activityLog = new ActivityLog();

            // Assert
            Assert.Equal(ActivityType.Like, activityLog.ActivityType);
            Assert.Equal(string.Empty, activityLog.ActivityDetails);
            Assert.Equal(DateTime.MinValue, activityLog.ActivityDate);
            Assert.Equal(string.Empty, activityLog.IPAddress);
        }

        [Fact]
        public void User_Properties_CanBeSetAndGet()
        {
            // Arrange
            ActivityLog activityLog = new ActivityLog();

            // Act
            activityLog.ActivityType = ActivityType.Like;
            activityLog.ActivityDetails = "Teste de like";
            activityLog.ActivityDate = new DateTime(1990, 1, 1);
            activityLog.IPAddress = "192.168.1.10";

            // Assert
            Assert.Equal(ActivityType.Like, activityLog.ActivityType);
            Assert.Equal("Teste de like", activityLog.ActivityDetails);
            Assert.Equal(new DateTime(1990, 1, 1), activityLog.ActivityDate);
            Assert.Equal("192.168.1.10", activityLog.IPAddress);
        }
    }
