using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.QLDN.OrgUnits
{
    public class OrgUnitAppService : ApplicationService, IOrgUnitAppService
    {
        private readonly IRepository<OrgUnit> _orgUnitRepo;

        public OrgUnitAppService(IRepository<OrgUnit> orgUnitRepo)
        {
            _orgUnitRepo = orgUnitRepo;
        }

        public async Task<List<OrgUnitDto>> GetListAsync()
        {
            var lstOrgUnit = await _orgUnitRepo.GetListAsync();
            return lstOrgUnit.Select(x => new OrgUnitDto() { Id = x.Id, OrgUnitName = x.OrgUnitName, MaxQty = x.MaxQty, StatusId = x.StatusId, ManagerId = x.ManagerId, OrgUnitParentId = x.OrgUnitParentId }).ToList();
        }

        public async Task<OrgUnitDto> GetOneAsync(Guid id)
        {
            IQueryable<OrgUnit> queryable = await _orgUnitRepo.GetQueryableAsync();

            var orgUnit = queryable.SingleOrDefault(x => x.Id == id);
            if (orgUnit == null) return null;

            return new OrgUnitDto() { Id = orgUnit.Id, OrgUnitName = orgUnit.OrgUnitName, MaxQty = orgUnit.MaxQty, StatusId = orgUnit.StatusId, ManagerId = orgUnit.ManagerId, OrgUnitParentId = orgUnit.OrgUnitParentId };
        }

        public async Task<OrgUnitDto> CreateAsync(CreateUpdateOrgUnitDto dto)
        {
            if (dto == null) throw new Exception();
            OrgUnit OrgUnit = new OrgUnit() { ManagerId = dto.ManagerId };
            OrgUnit.ChangeOrgUnitName(dto.OrgUnitName).ChangeMaxQty(dto.MaxQty);
            var orgUnit = await _orgUnitRepo.InsertAsync(OrgUnit);
            return new OrgUnitDto() { Id = orgUnit.Id, OrgUnitName = orgUnit.OrgUnitName, MaxQty = orgUnit.MaxQty, StatusId = orgUnit.StatusId, ManagerId = orgUnit.ManagerId, OrgUnitParentId = orgUnit.OrgUnitParentId };
        }

        public async Task<OrgUnitDto> UpdateAsync(CreateUpdateOrgUnitDto dto)
        {
            if (dto == null) throw new Exception();

            IQueryable<OrgUnit> queryable = await _orgUnitRepo.GetQueryableAsync();
            var orgUnit = queryable.SingleOrDefault(x => x.Id == dto.Id);

            orgUnit.ChangeOrgUnitName(dto.OrgUnitName).ChangeMaxQty(dto.MaxQty);

            var orgUnitUpdated = await _orgUnitRepo.UpdateAsync(orgUnit);
            return new OrgUnitDto() { Id = orgUnitUpdated.Id, OrgUnitName = orgUnitUpdated.OrgUnitName, MaxQty = orgUnitUpdated.MaxQty, StatusId = orgUnitUpdated.StatusId, ManagerId = orgUnitUpdated.ManagerId, OrgUnitParentId = orgUnitUpdated.OrgUnitParentId };
        }

        public async Task DeleteAsync(CreateUpdateOrgUnitDto dto)
        {
            if (dto == null) throw new Exception();

            IQueryable<OrgUnit> queryable = await _orgUnitRepo.GetQueryableAsync();
            var orgUnit = queryable.SingleOrDefault(x => x.Id == dto.Id);
            await _orgUnitRepo.DeleteAsync(orgUnit);
        }
    }
}
