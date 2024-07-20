using Acme.QLDN.Staffs;
using NSubstitute;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Acme.QLDN.NonDB
{
    public class StaffNonDBAppService_Tests
    {
        [Fact]
        public async Task Test_StaffAppService_GetList()
        {
            //Arrange
            IRepository<Staff> _StaffRepo = Substitute.For<IRepository<Staff>>();
            StaffAppService _StaffAppService = new StaffAppService(_StaffRepo);
            //act
            _StaffRepo.GetListAsync().Returns(x => new List<Staff>() { new Staff(), new Staff() });
            var result = await _StaffAppService.GetListAsync();
            await _StaffRepo.Received().GetListAsync();

            //assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<List<StaffDto>>();
            result.Count.ShouldBe(2);
        }

        [Fact]
        public void Test_StaffAppService_CreateOne_Fail()
        {
            //Arrange
            IRepository<Staff> _StaffRepo = Substitute.For<IRepository<Staff>>();
            StaffAppService _StaffAppService = new StaffAppService(_StaffRepo);

            //act
            var result = async () => { await _StaffAppService.CreateAsync(null); };

            //assert
            result.ShouldThrow<Exception>();
        }

        [Fact]
        public async Task Test_StaffAppService_CreateOne_Success()
        {
            //Arrange
            IRepository<Staff> _StaffRepo = Substitute.For<IRepository<Staff>>();
            StaffAppService _StaffAppService = new StaffAppService(_StaffRepo);

            //act
            _StaffRepo.InsertAsync(Arg.Any<Staff>()).Returns(new Staff());
            var result = await _StaffAppService.CreateAsync(new CreateUpdateStaffDto());
            await _StaffRepo.Received().InsertAsync(Arg.Any<Staff>());

            //assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<StaffDto>();
            result.Age.ShouldBeGreaterThanOrEqualTo(0);
            result.StaffName.ShouldBeNull();
        }

        [Fact]
        public void Test_StaffAppService_UpdateOne_Fail()
        {
            //Arrange
            IRepository<Staff> _StaffRepo = Substitute.For<IRepository<Staff>>();
            StaffAppService _StaffAppService = new StaffAppService(_StaffRepo);

            //act
            var result = async () => { await _StaffAppService.UpdateAsync(null); };

            //assert
            result.ShouldThrow<Exception>();
        }

        [Fact]
        public async Task Test_StaffAppService_UpdateOne_Success()
        {
            //Arrange
            IRepository<Staff> _StaffRepo = Substitute.For<IRepository<Staff>>();
            IReadOnlyRepository<Staff, Guid> _StaffReadRepo = Substitute.For<IRepository<Staff, Guid>>();
            StaffAppService _StaffAppService = new StaffAppService(_StaffRepo, _StaffReadRepo);

            //act
            _StaffReadRepo.FindAsync(Arg.Any<Guid>()).Returns(new Staff());

            _StaffRepo.UpdateAsync(Arg.Any<Staff>()).Returns(new Staff());
            var result = await _StaffAppService.UpdateAsync(new CreateUpdateStaffDto());

            await _StaffRepo.Received().UpdateAsync(Arg.Any<Staff>());

            //assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<StaffDto>();
            result.Age.ShouldBeGreaterThanOrEqualTo(0);
            result.StaffName.ShouldBeNull();
        }

        [Fact]
        public void Test_StaffAppService_Delete_Fail()
        {
            //Arrange
            IRepository<Staff> _StaffRepo = Substitute.For<IRepository<Staff>>();
            StaffAppService _StaffAppService = new StaffAppService(_StaffRepo);

            //act
            var result = async () => { await _StaffAppService.DeleteAsync(null); };

            //assert
            result.ShouldThrow<Exception>();
        }
    }
}
