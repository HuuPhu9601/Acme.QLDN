using Acme.QLDN.Staffs;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Xunit;

namespace Acme.QLDN.SqlServerDB
{
    public class StaffSQLAppService_Tests<TStartupModule> : QLDNApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
    {
        private readonly IStaffAppService _staffAppService;

        //Arrange
        public StaffSQLAppService_Tests()
        {
            _staffAppService = GetRequiredService<IStaffAppService>();
        }

        //test case lấy ra danh sách orgunit
        [Fact]
        public async Task Test_staffAppService_GetList()
        {
            //Act
            List<StaffDto> result = await _staffAppService.GetListAsync();

            //Assert
            result.ShouldNotBeNull(); //check null
            result.ShouldBeOfType<List<StaffDto>>(); //check type
            result.Count.ShouldBeGreaterThan(0); //check count = 4
            result.ShouldContain(x => x.StaffName.IndexOf("Nhan") >= 0); //check tồn tại
            result.ShouldBeUnique(); //check duy nhất
        }

        //test case lấy ra một orgunit
        [Theory]
        [InlineData("54af621c-0838-2ffd-91b8-3a13d7374cb1")]
        public async Task Test_staffAppService_GetOne(Guid id)
        {
            //Act
            StaffDto result = await _staffAppService.GetOneAsync(id);

            //Assert
            result.ShouldNotBeNull(); //check null
            result.ShouldBeOfType<StaffDto>(); //check type
            result.Id.ShouldNotBe(Guid.Empty);
            result.StaffName.ShouldBe("Nhan vien 2");
            result.Age.ShouldBeGreaterThan(0);
        }

        //test case tạo ra một orgunit
        public static IEnumerable<object[]> createMember = new[]
        {
            new object[]
            {
                new CreateUpdateStaffDto{
                    StaffName = "Nhan vien 5",
                    Age = 20,
                    Address = "Ha Noi"
                }
            }

        };
        [Theory]
        [MemberData(nameof(createMember))]
        public async Task Test_staffAppService_CreateOne(CreateUpdateStaffDto dto)
        {
            var staffCreated = await _staffAppService.CreateAsync(dto);

            //assert
            staffCreated.ShouldNotBeNull();
            staffCreated.Age.ShouldBeGreaterThan(0);
            staffCreated.Id.ShouldNotBe(Guid.Empty);
        }

        //test case cap nhat org
        public static IEnumerable<object[]> updateMember = new[]
        {
            new object[]
            {
                new CreateUpdateStaffDto{
                    Id = Guid.Parse("1291ef70-51b3-180a-bba3-3a13d7374cb1"),
                    StaffName = "Nhan vien 1",
                    Age = 25,
                    Address = "Hung Yen"
                }
            }

        };
        [Theory]
        [MemberData(nameof(updateMember))]
        public async Task Test_staffAppService_UpdateOne(CreateUpdateStaffDto dto)
        {
            var result = await _staffAppService.UpdateAsync(dto);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<StaffDto>();
            result.StaffName.ShouldBe("Nhan vien 1");
            result.Age.ShouldBe(25);
            result.Address.ShouldBe("Hung Yen");
        }

        //test case xoa org
        public static IEnumerable<object[]> deleteMember = new[]
        {
            new object[]
            {
                new CreateUpdateStaffDto{
                    Id = Guid.Parse("1c35b5dd-f9b4-c3be-61af-3a13d7420028"),
                    StaffName = "Nhan vien 5",
                    Age = 20,
                    Address = "Ha Noi"
                }
            }

        };
        [Theory]
        [MemberData(nameof(deleteMember))]
        public async Task Test_staffAppService_DeleteOne(CreateUpdateStaffDto dto)
        {
            await _staffAppService.DeleteAsync(dto);

            var result = _staffAppService.GetOneAsync(dto.Id);
            result.Result.ShouldBeNull();
        }
    }
}
