using DAL.Entities;
using Domain.Filters;
using System;
using System.Collections.Generic;

namespace Domain.Services
{
    public interface IOrderService
    {
        List<OrderEntity> Get(DateFilter filter = default);
        void Set(EntityStates state, Guid id = default, int price = default, DateTime date = default);
        void CreateTestData();
    }
}
