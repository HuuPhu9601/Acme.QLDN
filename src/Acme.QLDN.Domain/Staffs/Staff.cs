using Acme.QLDN.OrgStaffs;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.QLDN.Staffs
{
    public class Staff : AuditedAggregateRoot<Guid>
    {
        public string StaffName { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public int StatusId { get; set; }

        public ICollection<OrgStaff> OrgStaffs { get; set; }
    }
}
