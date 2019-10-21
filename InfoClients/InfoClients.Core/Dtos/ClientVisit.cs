using System;
using System.Collections.Generic;
using System.Text;

namespace InfoClients.Core.Dtos
{
    public class ClientVisit
    {
        public int Id { get; set; }
        public Guid ClientId { get; set; }
        public virtual Client Client { get; set; }
        public DateTime VisitDate { get; set; }
        public int SaleRepresentativeId { get; set; }
        public SalesRepresentative SaleRepresentative { get; set; }
        public int Net { get; set; }
        public int VisitTotal { get; set; }
        public string Description { get; set; }
    }
}
