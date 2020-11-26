using DAL.IEntities;
using Domain.Filters;
using System.Collections.Generic;

namespace Domain.Services
{
    public interface IEntityService<T> where T: class, IEntity
    {
        List<T> Get();
        List<T> GetByFilter(IFilter<T> filter);
        void Set(EntityStates state, T entity);
    }
}
