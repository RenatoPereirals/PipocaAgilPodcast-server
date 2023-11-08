using Xunit;
using Microsoft.EntityFrameworkCore;
using PipocaAgilPodcast.Persistence.Models;
using PipocaAgilPodcast.Domain;
using System.Linq;

namespace PipocaAgilPodcast.Tests.Persistence;

    public class DbContextTests
    {
        [Fact]
        public void CreateUser_InsertsUserIntoDatabase()
        {
            // Arrange            
            var options = new DbContextOptionsBuilder<PipocaAgilPodcastDbContext>()
                .UseInMemoryDatabase(databaseName: "CreateUserDatabase")
                .Options;

            // Act
            using (var context = new PipocaAgilPodcastDbContext(options))
            {
                var user = new User
                {
                    FullName = "John Doe",
                    UserName = "johndoe",
                    ImageURL = "avatar.jpg",
                    DateOfBirth = new DateTime(1990, 1, 1)
                };
                context.Users.Add(user);
                context.SaveChanges();
            }

            // Assert
            using (var context = new PipocaAgilPodcastDbContext(options))
            {
                var savedUser = context.Users.FirstOrDefault(u => u.UserName == "johndoe");

                Assert.NotNull(savedUser);
                Assert.Equal("John Doe", savedUser.FullName);
                Assert.Equal("johndoe", savedUser.UserName);
                Assert.Equal("avatar.jpg", savedUser.ImageURL);
                Assert.Equal(new DateTime(1990, 1, 1), savedUser.DateOfBirth);
            }
        }


        [Fact]
        public void GetUserByUserName_ReturnsCorrectUser()
        {
            // Arrange            
            var options = new DbContextOptionsBuilder<PipocaAgilPodcastDbContext>()
                .UseInMemoryDatabase(databaseName: "GetUserDatabase")
                .Options;

            // Act
            using (var context = new PipocaAgilPodcastDbContext(options))
            {
                var user = new User
                {
                    FullName = "John Doe",
                    UserName = "johndoe",
                    ImageURL = "avatar.jpg",
                    DateOfBirth = new DateTime(1990, 1, 1)
                };
                context.Users.Add(user);
                context.SaveChanges();
            }

            // Assert
            using (var context = new PipocaAgilPodcastDbContext(options))
            {
                var user = context.Users.FirstOrDefault(u => u.UserName == "johndoe");
                Assert.NotNull(user);
                Assert.Equal("John Doe", user.FullName);
            }
        }
        
        [Fact]
        public void UpdateUser_UpdatesUserInDatabase()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<PipocaAgilPodcastDbContext>()
                .UseInMemoryDatabase(databaseName: "UpdateUserDatabase")
                .Options;

            // Act
            using (var context = new PipocaAgilPodcastDbContext(options))
            {
                var user = new User
                {
                    FullName = "John Doe",
                    UserName = "johndoe",
                    ImageURL = "avatar.jpg",
                    DateOfBirth = new DateTime(1990, 1, 1)
                };
                context.Users.Add(user);
                context.SaveChanges();
            }

            // Act
            using (var context = new PipocaAgilPodcastDbContext(options))
            {
                var userToUpdate = context.Users.FirstOrDefault(u => u.UserName == "johndoe");

                Assert.NotNull(userToUpdate);
                userToUpdate.FullName = "Updated Name";
                context.SaveChanges();
            }

            // Assert
            using (var context = new PipocaAgilPodcastDbContext(options))
            {
                var updatedUser = context.Users.FirstOrDefault(u => u.UserName == "johndoe");
                Assert.NotNull(updatedUser);
                Assert.Equal("Updated Name", updatedUser.FullName);
            }
        }

        [Fact]
        public void DeleteUser_RemovesUserFromDatabase()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<PipocaAgilPodcastDbContext>()
                .UseInMemoryDatabase(databaseName: "DeleteUserDatabase")
                .Options;

            // Act
            using (var context = new PipocaAgilPodcastDbContext(options))
            {
                var user = new User
                {
                    FullName = "John Doe",
                    UserName = "johndoe",
                    ImageURL = "avatar.jpg",
                    DateOfBirth = new DateTime(1990, 1, 1)
                };
                context.Users.Add(user);
                context.SaveChanges();
            }

           // Act
            using (var context = new PipocaAgilPodcastDbContext(options))
            {
                var userToDelete = context.Users.FirstOrDefault(u => u.UserName == "johndoe");
                context.Users.Remove(userToDelete);
                context.SaveChanges();
            }

            // Assert
            using (var context = new PipocaAgilPodcastDbContext(options))
            {
                var deletedUser = context.Users.FirstOrDefault(u => u.UserName == "johndoe");
                Assert.Null(deletedUser);
            }
        }

        
    }

