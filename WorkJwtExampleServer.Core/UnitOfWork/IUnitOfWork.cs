using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkJwtExampleServer.Core.Entities;
using WorkJwtExampleServer.Core.Repositories;

namespace WorkJwtExampleServer.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<FlashCard> FlashCardRepository { get; }
        IGenericRepository<UserRefreshToken> UserRefreshTokenRepository { get; }
        Task CommitAsync();
        void Commit();
    }
}
