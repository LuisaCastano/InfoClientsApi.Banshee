using InfoClients.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoClients.Core.Dtos
{
    public class Client : EntityBase<Guid>
    {
        public string Nit { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public Guid CityId { get; set; }
        public virtual City City { get; set; }
        public Guid StateId { get; set; }
        public virtual State State { get; set; }
        public Guid CountryId { get; set; }
        public virtual Country Country { get; set; }
        public int CreditLimit { get; set; }
        public double VisitsPercentage { get; set; }
        public int AvailableCredit { get; set; }
        public virtual IList<ClientVisit> ClientVisit { get; set; }
    }
}
