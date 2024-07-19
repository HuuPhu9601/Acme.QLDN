using Acme.QLDN.Staffs;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Xunit;

namespace Acme.QLDN.InMemoryDB
{
    public class StaffAppService_Tests<TStartupModule> : QLDNApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
    {
        private readonly IStaffAppService _staffAppService;

        //Arrange
        public StaffAppService_Tests()
        {
            _staffAppService = GetRequiredService<IStaffAppService>();
        }

        public async Task<StaffDto> CreateManagerForTest()
        {
            //Arrange
            StaffDto staffCreated = new StaffDto();
            CreateUpdateStaffDto staffDto = new CreateUpdateStaffDto()
            {
                StaffName = "Nhan vien 1",
                Age = 20,
                Address = "Ha Noi",
            };

            staffCreated = await _staffAppService.CreateAsync(staffDto);

            return staffCreated;
        }

        //test case lấy ra danh sách orgunit
        [Fact]
        public async Task Test_staffAppService_GetList()
        {
            //gọi hàm create
            await CreateManagerForTest();
            //Act
            List<StaffDto> result = await _staffAppService.GetListAsync();

            //Assert
            result.ShouldNotBeNull(); //check null
            result.ShouldBeOfType<List<StaffDto>>(); //check type
            result.Count.ShouldBe(4); //check count = 4
            result.ShouldContain(x => x.StaffName.IndexOf("Nhan") >= 0); //check tồn tại
            result.ShouldBeUnique(); //check duy nhất
        }

        //test case lấy ra một orgunit
        [Fact]
        public async Task Test_staffAppService_GetOne()
        {
            //Arrange
            //gọi hàm create
            var staffCreated = await CreateManagerForTest();

            //Act
            StaffDto result = await _staffAppService.GetOneAsync(staffCreated.Id);

            //Assert
            result.ShouldNotBeNull(); //check null
            result.ShouldBeOfType<StaffDto>(); //check type
            result.Id.ShouldNotBe(Guid.Empty);
            result.StaffName.ShouldBe("Nhan vien 1");
            result.Age.ShouldBeGreaterThan(0);
        }

        //test case tạo ra một orgunit
        [Fact]
        public async Task Test_staffAppService_CreateOne()
        {
            var staffCreated = await CreateManagerForTest();

            //assert
            staffCreated.ShouldNotBeNull();
            staffCreated.Age.ShouldBeGreaterThan(0);
            staffCreated.Id.ShouldNotBe(Guid.Empty);
        }

        //test case cap nhat org
        [Fact]
        public async Task Test_staffAppService_UpdateOne()
        {
            //Arrange
            var staffCreated = await CreateManagerForTest();
            CreateUpdateStaffDto orgDto = new CreateUpdateStaffDto()
            {
                Id = staffCreated.Id,
                StaffName = "Nhan vien 2",
                Age = 25,
                Address = "Hai Phong"
            };

            var result = await _staffAppService.UpdateAsync(orgDto);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<StaffDto>();
            result.StaffName.ShouldBe("Nhan vien 2");
            result.Age.ShouldBe(25);
            result.Address.ShouldBe("Hai Phong");
        }

        //test case xoa org
        [Fact]
        public async Task Test_staffAppService_DeleteOne()
        {
            var staffCreated = await CreateManagerForTest();

            CreateUpdateStaffDto staffDto = new CreateUpdateStaffDto()
            {
                Id = staffCreated.Id,
                StaffName = staffCreated.StaffName,
                Age = staffCreated.Age,
                Address = staffCreated.Address,
                StatusId = staffCreated.StatusId,
            };
            await _staffAppService.DeleteAsync(staffDto);

            var result = _staffAppService.GetOneAsync(staffCreated.Id);
            result.Result.ShouldBeNull();
        }
    }
}
