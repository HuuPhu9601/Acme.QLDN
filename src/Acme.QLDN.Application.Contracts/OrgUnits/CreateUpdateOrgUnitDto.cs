using System;
using System.ComponentModel.DataAnnotations;

namespace Acme.QLDN.OrgUnits
{
    public class CreateUpdateOrgUnitDto
    {
        public Guid Id { get; set; }

        [Required]
        public string OrgUnitName { get; set; } = string.Empty;

        [Required]
        public int MaxQty { get; set; } = int.MaxValue;

        public int StatusId { get; set; } = 1;

        public int OrgUnitParentId { get; set; }

        [Required]
        public Guid ManagerId { get; set; }
    }
}
