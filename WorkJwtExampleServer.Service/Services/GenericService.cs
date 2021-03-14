using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkJwtExampleServer.Core.Repositories;
using WorkJwtExampleServer.Core.Services;
using WorkJwtExampleServer.Core.UnitOfWork;

namespace WorkJwtExampleServer.Service.Services
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        private readonly IUnitOfWork _uow;
        private readonly IGenericRepository<TEntity> _repository;
        public GenericService(IUnitOfWork unitOfWork, IGenericRepository<TEntity> repository)
        {
            _repository = repository;
            _uow = unitOfWork;
        }
        public async Task AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
            await _uow.CommitAsync();
                
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public void Remove(TEntity entity)
        {
            _repository.Remove(entity);
            _uow.Commit();
        }

        public TEntity Update(TEntity entity)
        {
            _repository.Update(entity);
            _uow.Commit();
            return entity;
        }

        public IQueryable<TEntity> Where(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Where(predicate);
        }
    }
}
