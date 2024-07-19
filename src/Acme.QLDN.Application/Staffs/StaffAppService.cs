using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.QLDN.Staffs
{
    public class StaffAppService : ApplicationService, IStaffAppService
    {
        private readonly IRepository<Staff> _staffRepo;

        public StaffAppService(IRepository<Staff> staffRepo)
        {
            _staffRepo = staffRepo;
        }

        public async Task<List<StaffDto>> GetListAsync()
        {
            var lstStaff = await _staffRepo.GetListAsync();
            return lstStaff.Select(x => new StaffDto() { Id = x.Id, StaffName = x.StaffName, Age = x.Age, StatusId = x.StatusId, Address = x.Address }).ToList();
        }

        public async Task<StaffDto> GetOneAsync(Guid id)
        {
            IQueryable<Staff> queryable = await _staffRepo.GetQueryableAsync();

            var staff = queryable.SingleOrDefault(x => x.Id == id);
            if (staff == null) return null;
            return new StaffDto() { Id = staff.Id, StaffName = staff.StaffName, Age = staff.Age, StatusId = staff.StatusId, Address = staff.Address };
        }

        public async Task<StaffDto> CreateAsync(CreateUpdateStaffDto dto)
        {
            if (dto == null) throw new Exception();
            Staff staff = new Staff();
            staff.ChangeName(dto.StaffName).ChangeAge(dto.Age).ChangeAddress(dto.Address);
            var staffCreated = await _staffRepo.InsertAsync(staff);
            return new StaffDto() { Id = staffCreated.Id, StaffName = staffCreated.StaffName, Age = staffCreated.Age, StatusId = staffCreated.StatusId, Address = staffCreated.Address };
        }

        public async Task<StaffDto> UpdateAsync(CreateUpdateStaffDto dto)
        {
            if (dto == null) throw new Exception();

            IQueryable<Staff> queryable = await _staffRepo.GetQueryableAsync();
            var staff = queryable.SingleOrDefault(x => x.Id == dto.Id);

            staff.ChangeAddress(dto.Address).ChangeName(dto.StaffName).ChangeAge(dto.Age);

            var staffUpdated = await _staffRepo.UpdateAsync(staff);
            return new StaffDto() { Id = staffUpdated.Id, StaffName = staffUpdated.StaffName, Age = staffUpdated.Age, StatusId = staffUpdated.StatusId, Address = staffUpdated.Address };
        }

        public async Task DeleteAsync(CreateUpdateStaffDto dto)
        {
            if (dto == null) throw new Exception();
            IQueryable<Staff> queryable = await _staffRepo.GetQueryableAsync();
            var staff = queryable.SingleOrDefault(x => x.Id == dto.Id);
            await _staffRepo.DeleteAsync(staff);
        }
    }
}
