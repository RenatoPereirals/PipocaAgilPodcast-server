using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PipocaAgilPodcast.Interfaces.ContractsPersistence;
using PipocaAgilPodcast.Persistence.Models;

namespace PipocaAgilPodcast.Persistence.Implementations
{
    public class RepositoryPesistence : IRepositoryPesistence
    {
        public PipocaAgilPodcastDbContext _context;
        public RepositoryPesistence(PipocaAgilPodcastDbContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
           return (await _context.SaveChangesAsync()) > 0;
        }

    }
}