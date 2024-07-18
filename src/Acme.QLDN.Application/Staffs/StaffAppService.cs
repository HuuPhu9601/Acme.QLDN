using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.QLDN.Staffs
{
    public class StaffAppService : CrudAppService<Staff, StaffDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateStaffDto>, IStaffAppService
    {
        public StaffAppService(IRepository<Staff, Guid> repository) : base(repository)
        {
        }
    }
}
