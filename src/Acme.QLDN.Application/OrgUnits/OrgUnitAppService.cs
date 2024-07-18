using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.QLDN.OrgUnits
{
    public class OrgUnitAppService : CrudAppService<OrgUnit, OrgUnitDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateOrgUnitDto>, IOrgUnitAppService
    {
        public OrgUnitAppService(IRepository<OrgUnit, Guid> repository) : base(repository)
        {
        }
    }
}
