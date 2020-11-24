using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services
{
    public class OrderService : IOrderService
    {
        private readonly IDbRepository _dbRepository;

        public OrderService(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public IEnumerable<OrderEntity> Get(DateTime dateFrom, DateTime dateTo)
        {
            dateTo = dateTo == DateTime.MinValue ? DateTime.MaxValue : dateTo;
            return _dbRepository.Get<OrderEntity>(x => x.Date >= dateFrom && x.Date <= dateTo).ToList();
        }

        public void Set(OrderEntity order, EntityStates state)
        {
            switch (state)
            {
                case EntityStates.Insert:
                    _dbRepository.Add(order);
                    break;
                case EntityStates.Update:
                    _dbRepository.Update(order);
                    break;
                case EntityStates.Delete:
                    _dbRepository.Delete(order);
                    break;
                default:
                    break;
            }

            _dbRepository.SaveChanges();
        }
    }
}
