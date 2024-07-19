using Acme.QLDN.OrgUnits;
using System;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.QLDN.Managers
{
    public class Manager : AuditedAggregateRoot<Guid>
    {
        public string ManagerName { get; private set; }

        public int Age { get; private set; }

        public string Address { get; private set; }

        public int StatusId { get; set; }

        public ICollection<OrgUnit> OrgUnits { get; set; }

        public Manager ChangeName(string name)
        {
            ManagerName = name;
            return this;
        }

        public Manager ChangeAddress(string address)
        {
            Address = address;
            return this;
        }

        public Manager ChangeAge(int age)
        {
            Age = age;
            return this;
        }
    }
}
