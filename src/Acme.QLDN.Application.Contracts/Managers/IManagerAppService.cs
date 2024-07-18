using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.QLDN.Managers
{
    public interface IManagerAppService : ICrudAppService<ManagerDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateManagerDto>
    {
    }
}
