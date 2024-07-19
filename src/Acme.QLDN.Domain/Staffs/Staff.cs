using Acme.QLDN.OrgStaffs;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.QLDN.Staffs
{
    public class Staff : AuditedAggregateRoot<Guid>
    {
        public string? StaffName { get; private set; }

        public int Age { get; private set; }

        public string? Address { get; private set; }

        public int StatusId { get; set; }

        public ICollection<OrgStaff>? OrgStaffs { get; set; }

        public Staff ChangeName(string name)
        {
            StaffName = name;
            return this;
        }

        public Staff ChangeAddress(string address)
        {
            Address = address;
            return this;
        }

        public Staff ChangeAge(int age)
        {
            Age = age;
            return this;
        }
    }
}
