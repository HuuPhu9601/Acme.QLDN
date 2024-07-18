using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.QLDN.Managers
{
    public class ManagerAppService : CrudAppService<Manager, ManagerDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateManagerDto, CreateUpdateManagerDto>, IManagerAppService
    {
        public ManagerAppService(IRepository<Manager, Guid> repository) : base(repository)
        {
        }
    }
}
