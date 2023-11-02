using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PipocaAgilPodcast.Persistence.Models;
using PipocaAgilPodcast.Domain;
using System.IO;
using Xunit;

namespace PipocaAgilPodcast.Tests
{
    public class DbContextTests
    {
        [Fact]
        public void CanAddUserToDatabase()
        {
            // Configurar o contexto usando um banco de dados em memória
            var options = new DbContextOptionsBuilder<PipocaAgilPodcastDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new PipocaAgilPodcastDbContext(options))
            {
                // Realize operações no contexto
                var user = new User { FullName = "John Doe", UserName = "johndoe" };
                context.Users.Add(user);
                context.SaveChanges();
            }

            // Verifique se os dados foram salvos corretamente
            using (var context = new PipocaAgilPodcastDbContext(options))
            {
                var savedUser = context.Users.Find(1); // Supondo que o ID 1 foi atribuído ao usuário inserido
                Assert.NotNull(savedUser);
                Assert.Equal("John Doe", savedUser.FullName);
            }
        }
    }
}
