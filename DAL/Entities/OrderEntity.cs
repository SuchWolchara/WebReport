using System;

namespace DAL.Entities
{
    public class OrderEntity : BaseEntity, IDateEntity
    {
        public int Price { get; set; }

        public DateTime Date { get; set; }
    }
}
