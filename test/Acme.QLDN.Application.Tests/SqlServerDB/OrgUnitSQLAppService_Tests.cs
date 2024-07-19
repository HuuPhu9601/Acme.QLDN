using Acme.QLDN.OrgUnits;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Xunit;

namespace Acme.QLDN.SqlServerDB
{
    public class OrgUnitSQLAppService_Tests<TStartupModule> : QLDNApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
    {
        private readonly IOrgUnitAppService _orgUnitAppService;

        //Arrange
        public OrgUnitSQLAppService_Tests()
        {
            _orgUnitAppService = GetRequiredService<IOrgUnitAppService>();
        }

        //test case lấy ra danh sách orgunit
        [Fact]
        public async Task Test_OrgUnitAppService_GetList()
        {
            //Act
            List<OrgUnitDto> result = await _orgUnitAppService.GetListAsync();

            //Assert
            result.ShouldNotBeNull(); //check null
            result.ShouldBeOfType<List<OrgUnitDto>>(); //check type
            result.Count.ShouldBeGreaterThan(0); //check count = 2
            result.ShouldContain(x => x.OrgUnitName.IndexOf("DN") >= 0); //check tồn tại
            result.ShouldBeUnique(); //check duy nhất
        }

        //test case lấy ra một orgunit
        [Theory]
        [InlineData("203847c0-36c1-411f-79ff-3a13dd84d9df")]
        public async Task Test_OrgUnitAppService_GetOne(Guid id)
        {
            //Act
            OrgUnitDto result = await _orgUnitAppService.GetOneAsync(id);

            //Assert
            result.ShouldNotBeNull(); //check null
            result.ShouldBeOfType<OrgUnitDto>(); //check type
            result.Id.ShouldNotBe(Guid.Empty);
            result.OrgUnitName.ShouldBe("DN 2.1");
            result.MaxQty.ShouldBeGreaterThan(0);
        }

        //test case tạo ra một orgunit
        public static IEnumerable<object[]> createMember = new[]
        {
            new object[]
            {
                new CreateUpdateOrgUnitDto{
                    OrgUnitName = "DN 2",
                    MaxQty = 100,
                    ManagerId = Guid.Parse("fc8b7747-3ba6-4dce-1589-3a13dd6857bd")
                }
            }

        };
        [Theory]
        [MemberData(nameof(createMember))]
        public async Task Test_OrgUnitAppService_CreateOne(CreateUpdateOrgUnitDto dto)
        {
            var orgUnitCreated = await _orgUnitAppService.CreateAsync(dto);

            //assert
            orgUnitCreated.ShouldNotBeNull();
            orgUnitCreated.MaxQty.ShouldBeGreaterThan(0);
            orgUnitCreated.Id.ShouldNotBe(Guid.Empty);
        }

        //test case cap nhat org
        public static IEnumerable<object[]> updateMember = new[]
        {
            new object[]
            {
                new CreateUpdateOrgUnitDto{
                    Id = Guid.Parse("203847c0-36c1-411f-79ff-3a13dd84d9df"),
                    OrgUnitName = "DN 2.1",
                    MaxQty = 150,
                    ManagerId = Guid.Parse("b2164408-6e39-b831-9927-3a13dd6e4986")
                }
            }

        };
        [Theory]
        [MemberData(nameof(updateMember))]
        public async Task Test_OrgUnitAppService_UpdateOne(CreateUpdateOrgUnitDto dto)
        {
            var result = await _orgUnitAppService.UpdateAsync(dto);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<OrgUnitDto>();
            result.OrgUnitName.ShouldBe("DN 2.1");
            result.MaxQty.ShouldBe(150);
        }

        //test case xoa org
        public static IEnumerable<object[]> deleteMember = new[]
        {
            new object[]
            {
                new CreateUpdateOrgUnitDto{
                    Id = Guid.Parse("203847c0-36c1-411f-79ff-3a13dd84d9df"),
                    OrgUnitName = "DN 1",
                    MaxQty = 100,
                    ManagerId = Guid.Parse("b2164408-6e39-b831-9927-3a13dd6e4986")
                }
            }

        };
        [Theory]
        [MemberData(nameof(deleteMember))]
        public async Task Test_OrgUnitAppService_DeleteOne(CreateUpdateOrgUnitDto dto)
        {
            await _orgUnitAppService.DeleteAsync(dto);

            var result = _orgUnitAppService.GetOneAsync(dto.Id);
            result.Result.ShouldBeNull();
        }
    }
}
