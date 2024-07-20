using Acme.QLDN.Managers;
using Acme.QLDN.OrgStaffs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.QLDN.OrgUnits
{
    public class OrgUnit : AuditedAggregateRoot<Guid>
    {
        public string OrgUnitName { get; private set; } = "";

        public int MaxQty { get; private set; } = 1;

        public int StatusId { get; set; } = 1;

        public int OrgUnitParentId { get; set; }

        [ForeignKey("Managers")]
        public Guid ManagerId { get; set; }

        public Manager Manager { get; set; }

        public ICollection<OrgStaff> OrgStaffs { get; set; }

        public OrgUnit ChangeOrgUnitName(string name)
        {
            string specialChars = "[^a-zA-Z0-9 ]";
            bool isSpecialChar = Regex.IsMatch(name, specialChars);
            if (isSpecialChar) throw new Exception("Invalid");
            OrgUnitName = name;
            return this;
        }

        public OrgUnit ChangeMaxQty(int qty)
        {
            if (qty <= 0) throw new Exception("Invalid");
            MaxQty = qty;
            return this;
        }
    }
}
