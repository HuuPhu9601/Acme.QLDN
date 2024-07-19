using Acme.QLDN.Managers;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Xunit;

namespace Acme.QLDN.InMemoryDB
{
    public class ManagerAppService_Tests<TStartupModule> : QLDNApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
    {
        private readonly IManagerAppService _managerAppService;

        //Arrange
        public ManagerAppService_Tests()
        {
            _managerAppService = GetRequiredService<IManagerAppService>();
        }

        public async Task<ManagerDto> CreateManagerForTest()
        {
            //Arrange
            ManagerDto managerCreated = new ManagerDto();
            CreateUpdateManagerDto managerDto = new CreateUpdateManagerDto()
            {
                ManagerName = "Quan ly 1",
                Age = 20,
                Address = "Ha Noi",
            };

            managerCreated = await _managerAppService.CreateAsync(managerDto);

            return managerCreated;
        }

        //test case lấy ra danh sách orgunit
        [Fact]
        public async Task Test_managerAppService_GetList()
        {
            //gọi hàm create
            await CreateManagerForTest();
            //Act
            List<ManagerDto> result = await _managerAppService.GetListAsync();

            //Assert
            result.ShouldNotBeNull(); //check null
            result.ShouldBeOfType<List<ManagerDto>>(); //check type
            result.Count.ShouldBe(1); //check count = 2
            result.ShouldContain(x => x.ManagerName.IndexOf("Quan") >= 0); //check tồn tại
            result.ShouldBeUnique(); //check duy nhất
        }

        //test case lấy ra một orgunit
        [Fact]
        public async Task Test_managerAppService_GetOne()
        {
            //Arrange
            //gọi hàm create
            var managerCreated = await CreateManagerForTest();

            //Act
            ManagerDto result = await _managerAppService.GetOneAsync(managerCreated.Id);

            //Assert
            result.ShouldNotBeNull(); //check null
            result.ShouldBeOfType<ManagerDto>(); //check type
            result.Id.ShouldNotBe(Guid.Empty);
            result.ManagerName.ShouldBe("Quan ly 1");
            result.Age.ShouldBeGreaterThan(0);
        }

        //test case tạo ra một orgunit
        [Fact]
        public async Task Test_managerAppService_CreateOne()
        {
            var managerCreated = await CreateManagerForTest();

            //assert
            managerCreated.ShouldNotBeNull();
            managerCreated.Age.ShouldBeGreaterThan(0);
            managerCreated.Id.ShouldNotBe(Guid.Empty);
        }

        //test case cap nhat org
        [Fact]
        public async Task Test_managerAppService_UpdateOne()
        {
            //Arrange
            var managerCreated = await CreateManagerForTest();
            CreateUpdateManagerDto orgDto = new CreateUpdateManagerDto()
            {
                Id = managerCreated.Id,
                ManagerName = "Quan ly 2",
                Age = 25,
                Address = "Hai Phong"
            };

            var result = await _managerAppService.UpdateAsync(orgDto);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<ManagerDto>();
            result.ManagerName.ShouldBe("Quan ly 2");
            result.Age.ShouldBe(25);
            result.Address.ShouldBe("Hai Phong");
        }

        //test case xoa org
        [Fact]
        public async Task Test_managerAppService_DeleteOne()
        {
            var managerCreated = await CreateManagerForTest();

            CreateUpdateManagerDto orgDto = new CreateUpdateManagerDto()
            {
                Id = managerCreated.Id,
                ManagerName = managerCreated.ManagerName,
                Age = managerCreated.Age,
                Address = managerCreated.Address,
                StatusId = managerCreated.StatusId,
            };
            await _managerAppService.DeleteAsync(orgDto);

            var result = _managerAppService.GetOneAsync(managerCreated.Id);
            result.Result.ShouldBeNull();
        }
    }
}
