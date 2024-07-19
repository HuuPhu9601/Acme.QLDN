using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Acme.QLDN.Staffs
{
    public interface IStaffAppService : IApplicationService
    {
        Task<List<StaffDto>> GetListAsync();

        Task<StaffDto> GetOneAsync(Guid id);

        Task<StaffDto> CreateAsync(CreateUpdateStaffDto dto);

        Task<StaffDto> UpdateAsync(CreateUpdateStaffDto dto);

        Task DeleteAsync(CreateUpdateStaffDto dto);
    }
}
