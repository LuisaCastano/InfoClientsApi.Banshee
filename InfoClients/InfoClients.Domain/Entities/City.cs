using System;
using System.Collections.Generic;
using System.Text;

namespace InfoClients.Domain.Entities
{
    public class City : EntityBase<Guid>
    {
        public Guid CountryId { get; set; }
        public Guid StateId { get; set; }
        public string NameCity { get; set; }
    }
}
