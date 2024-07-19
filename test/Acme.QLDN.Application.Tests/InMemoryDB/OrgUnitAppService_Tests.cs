using Acme.QLDN.Managers;
using Acme.QLDN.OrgUnits;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Xunit;

namespace Acme.QLDN.InMemoryDB
{
    //Test không có dữ liệu sẽ sử dụng kỹ thuật mock của Substitute
    //tạo ra class test orgService sử dụng class base QLDNApplicationTestBase<TStartmodul> đc abp cung cấp
    public class OrgUnitAppService_Tests<TStartupModule> : QLDNApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
    {
        private readonly IOrgUnitAppService _orgUnitAppService;
        private readonly IManagerAppService _managerAppService;

        //Arrange
        public OrgUnitAppService_Tests()
        {
            _orgUnitAppService = GetRequiredService<IOrgUnitAppService>();
            _managerAppService = GetRequiredService<IManagerAppService>();
        }

        public async Task<OrgUnitDto> CreateOrgUnitForTest()
        {
            //Arrange
            OrgUnitDto orgUnitCreated = new OrgUnitDto();
            ManagerDto managerCreated = new ManagerDto();
            CreateUpdateManagerDto managerDto = new CreateUpdateManagerDto()
            {
                ManagerName = "Quan ly 1",
                Age = 20,
                Address = "Ha Noi",
            };

            managerCreated = await _managerAppService.CreateAsync(managerDto);

            CreateUpdateOrgUnitDto orgDto = new CreateUpdateOrgUnitDto()
            {
                OrgUnitName = "DN 1",
                MaxQty = 100,
                StatusId = 1,
                ManagerId = managerCreated.Id
            };
            //act
            orgUnitCreated = await _orgUnitAppService.CreateAsync(orgDto);

            return orgUnitCreated;
        }

        //test case lấy ra danh sách orgunit
        [Fact]
        public async Task Test_OrgUnitAppService_GetList()
        {
            //gọi hàm create
            await CreateOrgUnitForTest();
            //Act
            List<OrgUnitDto> result = await _orgUnitAppService.GetListAsync();

            //Assert
            result.ShouldNotBeNull(); //check null
            result.ShouldBeOfType<List<OrgUnitDto>>(); //check type
            result.Count.ShouldBe(1); //check count = 2
            result.ShouldContain(x => x.OrgUnitName.IndexOf("DN") >= 0); //check tồn tại
            result.ShouldBeUnique(); //check duy nhất
        }

        //test case lấy ra một orgunit
        [Fact]
        public async Task Test_OrgUnitAppService_GetOne()
        {
            //Arrange
            //gọi hàm create
            var orgUnitCreated = await CreateOrgUnitForTest();

            //Act
            OrgUnitDto result = await _orgUnitAppService.GetOneAsync(orgUnitCreated.Id);

            //Assert
            result.ShouldNotBeNull(); //check null
            result.ShouldBeOfType<OrgUnitDto>(); //check type
            result.Id.ShouldNotBe(Guid.Empty);
            result.OrgUnitName.ShouldBe("DN 1");
            result.MaxQty.ShouldBeGreaterThan(0);
        }

        //test case tạo ra một orgunit
        [Fact]
        public async Task Test_OrgUnitAppService_CreateOne()
        {
            var orgUnitCreated = await CreateOrgUnitForTest();

            //assert
            orgUnitCreated.ShouldNotBeNull();
            orgUnitCreated.MaxQty.ShouldBeGreaterThan(0);
            orgUnitCreated.Id.ShouldNotBe(Guid.Empty);
        }

        //test case cap nhat org
        [Fact]
        public async Task Test_OrgUnitAppService_UpdateOne()
        {
            //Arrange
            var orgUnitCreated = await CreateOrgUnitForTest();
            CreateUpdateOrgUnitDto orgDto = new CreateUpdateOrgUnitDto()
            {
                Id = orgUnitCreated.Id,
                OrgUnitName = "DN 2",
                MaxQty = 200,
            };

            var result = await _orgUnitAppService.UpdateAsync(orgDto);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<OrgUnitDto>();
            result.OrgUnitName.ShouldBe("DN 2");
            result.MaxQty.ShouldBe(200);
        }

        //test case xoa org
        [Fact]
        public async Task Test_OrgUnitAppService_DeleteOne()
        {
            var orgUnitCreated = await CreateOrgUnitForTest();

            CreateUpdateOrgUnitDto orgDto = new CreateUpdateOrgUnitDto()
            {
                Id = orgUnitCreated.Id,
                OrgUnitName = orgUnitCreated.OrgUnitName,
                MaxQty = orgUnitCreated.MaxQty,
                StatusId = orgUnitCreated.StatusId,
                ManagerId = orgUnitCreated.ManagerId
            };
            await _orgUnitAppService.DeleteAsync(orgDto);

            var result = _orgUnitAppService.GetOneAsync(orgUnitCreated.Id);
            result.Result.ShouldBeNull();
        }
    }
}
