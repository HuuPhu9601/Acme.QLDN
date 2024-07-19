using System;
using Volo.Abp.Application.Dtos;

namespace Acme.QLDN.OrgUnits
{
    public class OrgUnitDto : AuditedEntityDto<Guid>
    {
        public string OrgUnitName { get; set; }

        public int MaxQty { get; set; }

        public int StatusId { get; set; }

        public int OrgUnitParentId { get; set; }

        public Guid ManagerId { get; set; }



    }
}
