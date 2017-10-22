using System;
using System.Collections.Generic;
using System.Text;

namespace FootballManagerBL.Interfaces
{
    public interface IRepository<TEntity, PK> //: IDisposable
        where TEntity : class
        where PK : struct
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(PK id);
        void Create(TEntity item);
        void Update(TEntity item);
        void Delete(PK id);
    }
}
