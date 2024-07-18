using System;
using Volo.Abp.Application.Dtos;

namespace Acme.QLDN.Staffs
{
    public class StaffDto : AuditedEntityDto<Guid>
    {
        public string StaffName { get; set; }

        public int Age { get; set; }

        public string Address { get; set; }

        public int StatusId { get; set; }
    }
}
