using FootballManagerBL.Interfaces;
using FootballManagerBL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballManagerBL.DAL
{
    public class UnitOfWork : IUnitOfWork/*, IDisposable*/
    {
        private readonly EFContext _context;

        //public UnitOfWork(IRepository<Player, Guid> players, IRepository<Team, Guid> teams)
        //{
        //    Players = players;
        //    Teams = teams;
        //}

        public UnitOfWork()
        {
            _context = new EFContext();

            //Players = new EFRepository<Player, Guid>(_context);
            //Teams = new EFRepository<Team, Guid>(_context);
        }
        public IRepository<Player, Guid> _players { get; private set; }
        public IRepository<Team, Guid> _teams { get; private set; }


        public void Save()
        {
            _context.SaveChanges();
        }

        public IRepository<Player, Guid> Players
        {
            get
            {
                return _players ?? (_players = new EFRepository<Player, Guid>(_context));
            }
        }

        public IRepository<Team, Guid> Teams
        {
            get
            {
                {
                    return _teams ?? (_teams = new EFRepository<Team, Guid>(_context));
                }
            }

            //public string gets { get {
            //    } set; }

            //private bool disposed = false;

            //public virtual void Dispose(bool disposing)
            //{
            //    if (!this.disposed)
            //    {
            //        if (disposing)
            //        {
            //            context.Dispose();
            //        }
            //        this.disposed = true;
            //    }
            //}

            //public void Dispose()
            //{
            //    Dispose(true);
            //    GC.SuppressFinalize(this);
            //}
        }
    }
}