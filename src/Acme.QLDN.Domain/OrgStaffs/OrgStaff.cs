using Acme.QLDN.OrgUnits;
using Acme.QLDN.Staffs;
using System;
using Volo.Abp.Domain.Entities;

namespace Acme.QLDN.OrgStaffs
{
    public class OrgStaff : Entity<Guid>
    {
        public Guid OrgUnitId { get; set; }
        public Guid StaffId { get; set; }

        public OrgUnit OrgUnit { get; set; }
        public Staff Staff { get; set; }
    }
}
