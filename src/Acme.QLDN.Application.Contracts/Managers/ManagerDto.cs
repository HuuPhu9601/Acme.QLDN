using System;
using Volo.Abp.Application.Dtos;

namespace Acme.QLDN.Managers
{
    public class ManagerDto : AuditedEntityDto<Guid>
    {
        public string ManagerName { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public int StatusId { get; set; }

    }
}
