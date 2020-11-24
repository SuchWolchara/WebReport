using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Web.Models
{
    public class OrderViewModel
    {
        private static OrderViewModel _instance;
        private OrderViewModel() { }

        public static OrderViewModel GetInstance()
        {
            if (_instance == null)
                _instance = new OrderViewModel();

            return _instance;
        }

        public IEnumerable<OrderEntity> Orders { get; set; } = Enumerable.Empty<OrderEntity>();

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }
    }
}
