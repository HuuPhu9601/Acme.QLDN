using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.QLDN.Managers
{
    public class ManagerAppService : ApplicationService, IManagerAppService
    {
        private readonly IRepository<Manager> _managerRepo;

        public ManagerAppService(IRepository<Manager> managerRepo)
        {
            _managerRepo = managerRepo;
        }

        public async Task<List<ManagerDto>> GetListAsync()
        {
            var lstManager = await _managerRepo.GetListAsync();
            return lstManager.Select(x => new ManagerDto() { Id = x.Id, ManagerName = x.ManagerName, Age = x.Age, StatusId = x.StatusId, Address = x.Address }).ToList();
        }

        public async Task<ManagerDto> GetOneAsync(Guid id)
        {
            IQueryable<Manager> queryable = await _managerRepo.GetQueryableAsync();

            var manager = queryable.SingleOrDefault(x => x.Id == id);
            if (manager == null) return null;
            return new ManagerDto() { Id = manager.Id, ManagerName = manager.ManagerName, Age = manager.Age, StatusId = manager.StatusId, Address = manager.Address };
        }

        public async Task<ManagerDto> CreateAsync(CreateUpdateManagerDto dto)
        {
            if (dto == null) throw new Exception();
            Manager Manager = new Manager();
            Manager.ChangeName(dto.ManagerName).ChangeAge(dto.Age).ChangeAddress(dto.Address);
            var manager = await _managerRepo.InsertAsync(Manager);
            return new ManagerDto() { Id = Manager.Id, ManagerName = Manager.ManagerName, Age = Manager.Age, StatusId = Manager.StatusId, Address = Manager.Address };
        }

        public async Task<ManagerDto> UpdateAsync(CreateUpdateManagerDto dto)
        {
            if (dto == null) throw new Exception();

            IQueryable<Manager> queryable = await _managerRepo.GetQueryableAsync();
            var manager = queryable.SingleOrDefault(x => x.Id == dto.Id);

            manager.ChangeAddress(dto.Address).ChangeName(dto.ManagerName).ChangeAge(dto.Age);

            var managerUpdated = await _managerRepo.UpdateAsync(manager);
            return new ManagerDto() { Id = managerUpdated.Id, ManagerName = managerUpdated.ManagerName, Age = managerUpdated.Age, StatusId = managerUpdated.StatusId, Address = managerUpdated.Address };
        }

        public async Task DeleteAsync(CreateUpdateManagerDto dto)
        {
            if (dto == null) throw new Exception();
            IQueryable<Manager> queryable = await _managerRepo.GetQueryableAsync();
            var manager = queryable.SingleOrDefault(x => x.Id == dto.Id);
            await _managerRepo.DeleteAsync(manager);
        }
    }
}
