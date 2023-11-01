using PipocaAgilPodcast.Persistence.Models;

namespace PipocaAgilPodcast.Persistence.Implementations;

    public class UserRepository : RepositoryPesistence
    {
        public readonly PipocaAgilPodcastDbContext _userContext;
        public UserRepository(PipocaAgilPodcastDbContext context) : base(context)
        {
            _userContext = context;
        }
    }
