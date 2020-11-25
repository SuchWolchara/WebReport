using System;

namespace DAL.IEntities
{
    public interface IEntity
    {
        Guid Id { get; set; }
        bool Hide { get; set; }
    }
}
