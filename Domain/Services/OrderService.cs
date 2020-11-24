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

        public List<OrderEntity> Get(DateTime dateFrom, DateTime dateTo)
        {
            dateTo = dateTo == default ? DateTime.MaxValue : dateTo;
            return _dbRepository.Get<OrderEntity>(x => x.Date >= dateFrom && x.Date <= dateTo).OrderBy(x => x.Date).ToList();
        }

        public void Set(EntityStates state, Guid id = default, int price = default, DateTime date = default)
        {
            var order = GetOrCreateOrder(id);

            switch (state)
            {
                case EntityStates.Insert:
                    order.Price = price;
                    order.Date = date;
                    _dbRepository.Add(order);
                    break;
                case EntityStates.Update:
                    order.Price = price;
                    order.Date = date;
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

        private OrderEntity GetOrCreateOrder(Guid id)
        {
            if (id == default)
                return new OrderEntity();

            return _dbRepository.Get<OrderEntity>(x => x.Id == id).FirstOrDefault();
        }
    }
}
