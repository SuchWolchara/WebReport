using DAL.Entities;
using Domain.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Web.Models
{
    public class ReportViewModel
    {
        private static ReportViewModel _instance;

        private ReportViewModel() 
        {
            Orders = new List<OrderEntity>();
            DateFilter = new DateFilter<OrderEntity>();
        }

        public static ReportViewModel GetInstance()
        {
            if (_instance == null)
                _instance = new ReportViewModel();

            return _instance;
        }

        public OrderEntity GetOrCreateOrder(Guid id = default)
        {
            return Orders.FirstOrDefault(x => x.Id == id);
        }

        public List<OrderEntity> Orders { get; set; }

        public DateFilter<OrderEntity> DateFilter { get; set; }
    }
}
