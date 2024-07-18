using Acme.QLDN.OrgUnits;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.QLDN.Managers
{
    public class Manager : AuditedAggregateRoot<Guid>
    {
        public string ManagerName { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public int StatusId { get; set; }

        public ICollection<OrgUnit> OrgUnits { get; set; }
    }
}
