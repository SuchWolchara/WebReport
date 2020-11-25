﻿using DAL.Entities;
using DAL.Repositories;
using Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Services
{
    public class OrderService : IEntityService<OrderEntity>
    {
        private readonly IDbRepository _dbRepository;

        public OrderService(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public List<OrderEntity> GetAll()
        {
            return _dbRepository.Get<OrderEntity>().OrderBy(x => x.Date).ToList();
        }

        public List<OrderEntity> GetByFilter(IFilter<OrderEntity> filter)
        {
            return _dbRepository.Get(filter.GetSelector()).OrderBy(x => x.Date).ToList();
        }

        public void Set(EntityStates state, OrderEntity entity)
        {
            switch (state)
            {
                case EntityStates.Insert:
                    _dbRepository.Add(entity);
                    break;
                case EntityStates.Update:
                    _dbRepository.Update(entity);
                    break;
                case EntityStates.Delete:
                    _dbRepository.Delete(entity);
                    break;
                default:
                    break;
            }

            _dbRepository.SaveChanges();
        }

        public void CreateTestData()
        {
            var oldData = _dbRepository.GetAll<OrderEntity>();
            var newData = new List<OrderEntity>();
            for (int i = 0; i < 100; i++)
            {
                newData.Add(new OrderEntity()
                {
                    Price = (i + 1) * 1000,
                    Date = DateTime.Today.AddDays(-(i * 2))
                });
            }
            _dbRepository.RemoveRange(oldData);
            _dbRepository.AddRange(newData);
            _dbRepository.SaveChanges();
        }
    }
}
