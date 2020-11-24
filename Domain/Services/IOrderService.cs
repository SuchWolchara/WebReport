using DAL.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Services
{
    public interface IOrderService
    {
        List<OrderEntity> Get(DateTime dateFrom, DateTime dateTo);
        void Set(EntityStates state, Guid id = default, int price = default, DateTime date = default);
    }
}
