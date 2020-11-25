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
            DateFilter = new DateFilter<OrderEntity>();
        }

        public static ReportViewModel Instance
        {
            get
            {
                _instance ??= new ReportViewModel();
                return _instance;
            }
        }

        public List<OrderEntity> Orders { get; set; }

        public DateFilter<OrderEntity> DateFilter { get; set; }
    }
}
