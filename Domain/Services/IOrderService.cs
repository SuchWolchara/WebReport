using DAL.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Services
{
    public interface IOrderService
    {
        IEnumerable<OrderEntity> Get(DateTime dateFrom, DateTime dateTo);
        void Set(OrderEntity order, EntityStates state);
    }
}
