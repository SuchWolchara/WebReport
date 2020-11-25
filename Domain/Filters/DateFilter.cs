using System;

namespace Domain.Filters
{
    public class DateFilter
    {
        private DateTime _dateFrom;
        private DateTime _dateTo;

        public DateFilter()
        {
            _dateFrom = DateTime.MinValue;
            _dateTo = DateTime.MaxValue;
        }

        public DateTime DateFrom 
        {
            get => _dateFrom.Date;
            set => _dateFrom = value;
        }

        public DateTime DateTo 
        {
            get => _dateTo.Date;
            set => _dateTo = value == default ? DateTime.MaxValue : value;
        }
    }
}
