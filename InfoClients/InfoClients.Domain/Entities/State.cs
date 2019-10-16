using System;
using System.Collections.Generic;
using System.Text;

namespace InfoClients.Domain.Entities
{
    public class State : EntityBase<Guid>
    {
        public Guid CountryId { get; set; }
        public string NameState { get; set; }
    }
}
