using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WorkJwtExampleServer.Core.Entities;
using WorkJwtExampleServer.Core.Repositories;
using WorkJwtExampleServer.Core.Services;
using WorkJwtExampleServer.Core.UnitOfWork;
using WorkJwtExampleServer.Service.Mapping;
using WorkJwtExampleServer.SharedLibrary.DTOs;

namespace WorkJwtExampleServer.Service.Services
{
    public class GenericService<TEntity, TDto> : IGenericService<TEntity,TDto> where TEntity : class where TDto : class
    {
        private readonly IUnitOfWork _uow;
        private readonly IGenericRepository<TEntity> _repository;
        public GenericService(IUnitOfWork unitOfWork, IGenericRepository<TEntity> repository)
        {
            _repository = repository;
            _uow = unitOfWork;
        }

        public async Task<Response<TDto>> GetByIdAsync(int id)
        {
            
            var returnObj = ObjectMapper.Mapper().Map<TDto>(await _repository.GetByIdAsync(id));
            return Response<TDto>.Success(returnObj,200);
        }

        public async Task<Response<IEnumerable<TDto>>> GetAllAsync()
        {
            var returnObj = ObjectMapper.Mapper().Map<IEnumerable<TDto>>(await _repository.GetAllAsync());
            return Response<IEnumerable<TDto>>.Success(returnObj, 200);
        }

        public async Task<Response<TDto>> AddAsync(TDto entity)
        {
            var newEntity = ObjectMapper.Mapper().Map<TEntity>(entity);
            await _repository.AddAsync(newEntity);
            await _uow.CommitAsync();
            var returnObj = ObjectMapper.Mapper().Map<TDto>(newEntity);
            return Response<TDto>.Success(returnObj,201);
        }

        public async Task<Response<NoDataDto>> Remove(int id)
        {
            var isExistEntity = await _repository.GetByIdAsync(id);
            if (isExistEntity==null)
            {
                return Response<NoDataDto>.Fail("The entity you want to delete was not found",404,true);
            }
            _repository.Remove(isExistEntity);
            await _uow.CommitAsync();
            return Response<NoDataDto>.Success(204);
        }

        public async Task<Response<TDto>> Update(TDto entity, int id)
        {
            var isExistEntitiy = await _repository.GetByIdAsync(id);
            if (isExistEntitiy == null)
                return Response<TDto>.Fail("The entity you want to update was not found", 404, true);
            _repository.Update(isExistEntitiy);
            await _uow.CommitAsync();
            var updatedEntity = ObjectMapper.Mapper().Map<TDto>(isExistEntitiy);
            return Response<TDto>.Success(updatedEntity, 204);
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
