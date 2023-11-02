using PipocaAgilPodcast.Domain;
using Xunit;

namespace tests.UnitTests.Domain;

    public class UserActivityLogTests
    {
        [Fact]
        public void UserActivityLog_Constructor_InitializesCollections()
        {
            // Arrange
            UserActivityLog userActivityLog = new UserActivityLog();

            // Assert
            Assert.NotNull(UserActivityLog.User);
            Assert.NotNull(UserActivityLog.ActivityLog);
        }
    }
