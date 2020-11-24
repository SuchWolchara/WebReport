using DAL.Entities;
using System;
using System.Collections.Generic;

namespace Web.Models
{
    public class ReportViewModel
    {
        private static ReportViewModel _instance;

        private ReportViewModel() 
        {
            Orders = new List<OrderEntity>();
        }

        public static ReportViewModel GetInstance()
        {
            if (_instance == null)
                _instance = new ReportViewModel();

            return _instance;
        }

        public List<OrderEntity> Orders { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }
    }
}
