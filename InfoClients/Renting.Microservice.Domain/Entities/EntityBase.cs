using System;
using System.Collections.Generic;
using System.Text;

namespace Renting.Microservice.Domain.Entities
{
    public class EntityBase<TId> where TId : struct
    {
        public TId Id { get; set; }
    }
}
