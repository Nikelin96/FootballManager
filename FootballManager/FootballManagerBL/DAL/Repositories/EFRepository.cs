using FootballManagerBL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballManagerBL.DAL
{
    public class EFRepository<TEntity, PK> : IRepository<TEntity, PK>
        where TEntity : class
        where PK : struct
    {
        private DbContext _context { get; set; }
        private DbSet<TEntity> _dataSet { get; set; }

        public EFRepository(DbContext context)
        {
            _context = context;
            _dataSet = _context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dataSet;
        }

        public TEntity Get(PK id)
        {
            return _dataSet.Find(id);
        }

        public void Create(TEntity item)
        {
            _dataSet.Add(item);
        }

        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(PK id)
        {
            //var entity = _dataSet.First(x => x.Id == id);
            var entity = _dataSet.Find(id);
            if (entity != null)
                _dataSet.Remove(entity);
        }
    }
}
