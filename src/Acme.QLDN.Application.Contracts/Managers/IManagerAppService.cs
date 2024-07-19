using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Acme.QLDN.Managers
{
    public interface IManagerAppService : IApplicationService
    {
        Task<List<ManagerDto>> GetListAsync();

        Task<ManagerDto> GetOneAsync(Guid id);

        Task<ManagerDto> CreateAsync(CreateUpdateManagerDto dto);

        Task<ManagerDto> UpdateAsync(CreateUpdateManagerDto dto);

        Task DeleteAsync(CreateUpdateManagerDto dto);
    }
}
