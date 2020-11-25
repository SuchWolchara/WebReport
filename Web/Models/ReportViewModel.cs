using DAL.Entities;
using Domain.Filters;
using System.Collections.Generic;

namespace Web.Models
{
    public class ReportViewModel
    {
        private static ReportViewModel _instance;

        private ReportViewModel() 
        {
            Orders = new List<OrderEntity>();
            Filter = new DateFilter();
        }

        public static ReportViewModel GetInstance()
        {
            if (_instance == null)
                _instance = new ReportViewModel();

            return _instance;
        }

        public List<OrderEntity> Orders { get; set; }

        public DateFilter Filter { get; set; }
    }
}
