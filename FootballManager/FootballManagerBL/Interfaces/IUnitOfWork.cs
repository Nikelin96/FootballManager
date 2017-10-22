using FootballManagerBL.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballManagerBL.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Player, Guid> Players { get; }

        IRepository<Team, Guid> Teams { get; }

        void Save();
    }
}
