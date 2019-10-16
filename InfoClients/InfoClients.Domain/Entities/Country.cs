using System;
using System.Collections.Generic;
using System.Text;

namespace InfoClients.Domain.Entities
{
    public class Country : EntityBase<Guid>
    {
        public string NameCountry { get; set; }
    }
}
