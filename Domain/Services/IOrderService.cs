using DAL.Entities;
using Domain.Filters;
using System.Collections.Generic;

namespace Domain.Services
{
    public interface IOrderService
    {
        List<OrderEntity> Get();
        List<OrderEntity> GetByFilter(IFilter<OrderEntity> filter);
        void Set(EntityStates state, OrderEntity order);
        void CreateTestData();
    }
}
