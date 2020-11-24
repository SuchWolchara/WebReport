using System;

namespace DAL.Entities
{
    public class BaseEntity : IEntity
    {
        public Guid Id { get; set; }

        public bool Hide { get; set; }
    }
}
