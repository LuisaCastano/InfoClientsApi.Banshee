using System;
using System.Collections.Generic;
using System.Text;

namespace InfoClients.Core.Dtos
{
    public class City
    {
        public Guid Id { get; set; }
        public Guid CountryId { get; set; }
        public Guid StateId { get; set; }
        public string NameCity { get; set; }
    }
}
