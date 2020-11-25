using System;

namespace DAL.Entities
{
    public interface IDateEntity : IEntity
    {
        DateTime Date { get; set; }
    }
}
