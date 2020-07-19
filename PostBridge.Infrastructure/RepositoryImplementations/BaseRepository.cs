using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PostBridge.Domain;
using PostBridge.Infrastructure.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace PostBridge.Infrastructure.RepositoryImplementations
{
    internal abstract class BaseRepository<T> where T : BaseEntityLongId
    {
        private readonly PostBridgeMsSqlServerContext _context;

        public BaseRepository(PostBridgeMsSqlServerContext context)
        {
            _context = context;
        }

        public virtual void Create(T entity)
        {
            Entities.Add(entity);
            if (entity.Id < 0)
                entity.Id = 0;

            SaveChanges();
        }

        public void Create(IEnumerable<T> entities)
        {
            Entities.AddRange(entities);
            SaveChanges();
        }

        public virtual T GetById(long entityId)
        {
            return Entities.Find(entityId);
        }

        public virtual List<T> GetAll()
        {
            return ReadOnlyEntities.ToList();
        }

        public void Update(T entity)
        {
            Entities.Update(entity);
            SaveChanges();
        }

        public void Update(IEnumerable<T> entities)
        {
            Entities.UpdateRange(entities);
            SaveChanges();
        }

        public void Delete(T entity)
        {
            Entities.Remove(entity);
            SaveChanges();
        }

        public void Delete(IEnumerable<long> ids)
        {
            List<T> entities = Entities.Where(e => ids.Contains(e.Id)).ToList();
            Entities.RemoveRange(entities);
            SaveChanges();
        }

        protected DbSet<T> Entities => _context.Set<T>();
        protected IQueryable<T> ReadOnlyEntities => _context.Set<T>(); //.AsNoTracking();

        protected void SaveChanges()
        {
            _context.SaveChanges();
        }

        protected DatabaseFacade DataBase => _context.Database;
    }
}
