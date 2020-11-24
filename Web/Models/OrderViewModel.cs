using DAL.Entities;
using System;
using System.Collections.Generic;

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

        public List<OrderEntity> Orders { get; set; } = new List<OrderEntity>();

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }
    }
}
