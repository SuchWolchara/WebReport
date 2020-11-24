using System;

namespace DAL.Entities
{
    public interface IEntity
    {
        Guid Id { get; set; }
        bool Hide { get; set; }
    }
}
