using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WorkJwtExampleServer.SharedLibrary.DTOs;

namespace WorkJwtExampleServer.Core.Services
{
    public interface IGenericService<TEntity, TDto> where TEntity : class where TDto : class
    {
        Task<Response<TDto>> GetByIdAsync(int id);
        Task<Response<IEnumerable<TDto>>> GetAllAsync();
        Task<Response<TDto>> AddAsync(TDto entity);
        Task<Response<NoDataDto>> Remove(int id);
        Task<Response<TDto>> Update(TDto entity, int id);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
    }
}
