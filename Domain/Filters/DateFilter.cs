using DAL.Entities;
using System;
using System.Linq.Expressions;

namespace Domain.Filters
{
    public class DateFilter<T> : IFilter<T> where T: class, IDateEntity
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

        public Expression<Func<T, bool>> GetSelector()
        {
            return x => x.Date.Date >= DateFrom && x.Date.Date <= DateTo;
        }
    }
}
