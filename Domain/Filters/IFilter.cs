using DAL.IEntities;
using System;
using System.Linq.Expressions;

namespace Domain.Filters
{
    public interface IFilter<T> where T: class, IEntity
    {
        Expression<Func<T, bool>> GetSelector();
    }
}
