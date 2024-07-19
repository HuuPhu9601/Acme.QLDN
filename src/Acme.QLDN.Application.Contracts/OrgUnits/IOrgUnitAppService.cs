using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Acme.QLDN.OrgUnits
{
    public interface IOrgUnitAppService : IApplicationService
    {
        Task<List<OrgUnitDto>> GetListAsync();

        Task<OrgUnitDto> GetOneAsync(Guid id);

        Task<OrgUnitDto> CreateAsync(CreateUpdateOrgUnitDto dto);

        Task<OrgUnitDto> UpdateAsync(CreateUpdateOrgUnitDto dto);

        Task DeleteAsync(CreateUpdateOrgUnitDto dto);
    }
}
