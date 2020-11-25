using System;

namespace DAL.IEntities
{
    public interface IDateEntity : IEntity
    {
        DateTime Date { get; set; }
    }
}
