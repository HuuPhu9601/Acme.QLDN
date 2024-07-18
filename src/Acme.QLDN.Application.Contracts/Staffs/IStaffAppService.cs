using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.QLDN.Staffs
{
    public interface IStaffAppService : ICrudAppService<StaffDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateStaffDto>
    {
    }
}
