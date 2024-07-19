using Acme.QLDN.Managers;
using Acme.QLDN.OrgStaffs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.QLDN.OrgUnits
{
    public class OrgUnit : AuditedAggregateRoot<Guid>
    {
        public string OrgUnitName { get; private set; }

        public int MaxQty { get; private set; }

        public int StatusId { get; set; }

        public int OrgUnitParentId { get; set; }

        [ForeignKey("Managers")]
        public Guid ManagerId { get; set; }

        public Manager Manager { get; set; }

        public ICollection<OrgStaff> OrgStaffs { get; set; }

        public OrgUnit ChangeOrgUnitName(string name)
        {
            OrgUnitName = name;
            return this;
        }

        public OrgUnit ChangeMaxQty(int qty)
        {
            MaxQty = qty;
            return this;
        }
    }
}
