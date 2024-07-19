using Acme.QLDN.Managers;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Xunit;

namespace Acme.QLDN.SqlServerDB
{
    public class ManagerSQLAppService_Tests<TStartupModule> : QLDNApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
    {
        private readonly IManagerAppService _managerAppService;

        //Arrange
        public ManagerSQLAppService_Tests()
        {
            _managerAppService = GetRequiredService<IManagerAppService>();
        }

        //test case lấy ra danh sách orgunit
        [Fact]
        public async Task Test_managerAppService_GetList()
        {
            //Act
            List<ManagerDto> result = await _managerAppService.GetListAsync();

            //Assert
            result.ShouldNotBeNull(); //check null
            result.ShouldBeOfType<List<ManagerDto>>(); //check type
            result.Count.ShouldBeGreaterThan(0); //check count = 2
            result.ShouldContain(x => x.ManagerName.IndexOf("Quan") >= 0); //check tồn tại
            result.ShouldBeUnique(); //check duy nhất
        }

        //test case lấy ra một orgunit
        [Theory]
        [InlineData("fc8b7747-3ba6-4dce-1589-3a13dd6857bd")]
        public async Task Test_managerAppService_GetOne(Guid id)
        {
            //Act
            ManagerDto result = await _managerAppService.GetOneAsync(id);

            //Assert
            result.ShouldNotBeNull(); //check null
            result.ShouldBeOfType<ManagerDto>(); //check type
            result.Id.ShouldNotBe(Guid.Empty);
            result.ManagerName.ShouldBe("Quan ly 2");
            result.Age.ShouldBeGreaterThan(0);
        }

        //test case tạo ra một orgunit
        public static IEnumerable<object[]> createMember = new[]
        {
            new object[]
            {
                new CreateUpdateManagerDto{ManagerName = "Quan ly 1", Age = 45, Address = "Ha Noi"}
            }

        };
        [Theory]
        [MemberData(nameof(createMember))]
        public async Task Test_managerAppService_CreateOne(CreateUpdateManagerDto dto)
        {
            var managerCreated = await _managerAppService.CreateAsync(dto);

            //assert
            managerCreated.ShouldNotBeNull();
            managerCreated.Age.ShouldBeGreaterThan(0);
            managerCreated.Id.ShouldNotBe(Guid.Empty);
        }

        //test case cap nhat org
        public static IEnumerable<object[]> updateMember = new[]
        {
            new object[]
            {
                new CreateUpdateManagerDto{Id = Guid.Parse("b2164408-6e39-b831-9927-3a13dd6e4986"),
                    ManagerName = "Quan ly 1.1",
                    Age = 30,
                    Address = "Hai Phong"
                }
            }

        };
        [Theory]
        [MemberData(nameof(updateMember))]
        public async Task Test_managerAppService_UpdateOne(CreateUpdateManagerDto dto)
        {
            var result = await _managerAppService.UpdateAsync(dto);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<ManagerDto>();
            result.ManagerName.ShouldBe("Quan ly 1.1");
            result.Age.ShouldBe(30);
            result.Address.ShouldBe("Hai Phong");
        }

        //test case xoa org
        public static IEnumerable<object[]> deleteMember = new[]
        {
            new object[]
            {
                new CreateUpdateManagerDto{Id = Guid.Parse("12eadcc8-4113-b0be-12e8-3a13d73bf25e"),
                    ManagerName = "Quan ly 1.1",
                    Age = 30,
                    Address = "Hai Phong"
                }
            }

        };
        [Theory]
        [MemberData(nameof(deleteMember))]
        public async Task Test_managerAppService_DeleteOne(CreateUpdateManagerDto dto)
        {
            await _managerAppService.DeleteAsync(dto);

            var result = _managerAppService.GetOneAsync(dto.Id);
            result.Result.ShouldBeNull();
        }
    }
}
