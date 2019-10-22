using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace InfoClients.Core.Dtos
{
    [DataContract(Name = "visitsCountCity")]
    public class VisitsCity
    {
        [DataMember(Name = "nameCity")]
        public String NameCity { get; set; }
        [DataMember(Name = "visitsCount")]
        public int VisitsNum { get; set; }
    }
}
