using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.QLDN.OrgUnits
{
    public interface IOrgUnitAppService : ICrudAppService<OrgUnitDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateOrgUnitDto>
    {
    }
}
