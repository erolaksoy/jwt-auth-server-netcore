using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkJwtExampleServer.Core.Entities;
using WorkJwtExampleServer.Core.Repositories;
using WorkJwtExampleServer.Core.UnitOfWork;
using WorkJwtExampleServer.Data.AppContext;
using WorkJwtExampleServer.Data.Repositories;

namespace WorkJwtExampleServer.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        //private  GenericRepository<FlashCard> _flashCardRepository;
        //private  GenericRepository<UserRefreshToken> _userRefreshTokenRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        //public IGenericRepository<FlashCard> FlashCardRepository =>
        //    _flashCardRepository ?? new GenericRepository<FlashCard>(_context);

        //public IGenericRepository<UserRefreshToken> UserRefreshTokenRepository =>
        //    _userRefreshTokenRepository ?? new GenericRepository<UserRefreshToken>(_context);
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}
