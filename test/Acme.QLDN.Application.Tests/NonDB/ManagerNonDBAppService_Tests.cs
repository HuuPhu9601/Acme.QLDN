using Acme.QLDN.Managers;
using NSubstitute;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Acme.QLDN.NonDB
{
    public class ManagerNonDBAppService_Tests
    {
        [Fact]
        public async Task Test_managerAppService_GetList()
        {
            //Arrange
            IRepository<Manager> _managerRepo = Substitute.For<IRepository<Manager>>();
            ManagerAppService _managerAppService = new ManagerAppService(_managerRepo);
            //act
            _managerRepo.GetListAsync().Returns(x => new List<Manager>() { new Manager(), new Manager() });
            var result = await _managerAppService.GetListAsync();
            await _managerRepo.Received().GetListAsync();

            //assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<List<ManagerDto>>();
            result.Count.ShouldBe(2);
        }

        [Fact]
        public void Test_managerAppService_CreateOne_Fail()
        {
            //Arrange
            IRepository<Manager> _managerRepo = Substitute.For<IRepository<Manager>>();
            ManagerAppService _managerAppService = new ManagerAppService(_managerRepo);

            //act
            var result = async () => { await _managerAppService.CreateAsync(null); };

            //assert
            result.ShouldThrow<Exception>();
        }

        [Fact]
        public async Task Test_managerAppService_CreateOne_Success()
        {
            //Arrange
            IRepository<Manager> _managerRepo = Substitute.For<IRepository<Manager>>();
            ManagerAppService _managerAppService = new ManagerAppService(_managerRepo);

            //act
            _managerRepo.InsertAsync(Arg.Any<Manager>()).Returns(new Manager());
            var result = await _managerAppService.CreateAsync(new CreateUpdateManagerDto());
            await _managerRepo.Received().InsertAsync(Arg.Any<Manager>());

            //assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<ManagerDto>();
            result.Age.ShouldBeGreaterThanOrEqualTo(0);
            result.ManagerName.ShouldBeNull();
        }

        [Fact]
        public void Test_managerAppService_UpdateOne_Fail()
        {
            //Arrange
            IRepository<Manager> _managerRepo = Substitute.For<IRepository<Manager>>();
            ManagerAppService _managerAppService = new ManagerAppService(_managerRepo);

            //act
            var result = async () => { await _managerAppService.UpdateAsync(null); };

            //assert
            result.ShouldThrow<Exception>();
        }

        [Fact]
        public async Task Test_managerAppService_UpdateOne_Success()
        {
            //Arrange
            IRepository<Manager> _managerRepo = Substitute.For<IRepository<Manager>>();
            IReadOnlyRepository<Manager, Guid> _managerReadRepo = Substitute.For<IRepository<Manager, Guid>>();
            ManagerAppService _managerAppService = new ManagerAppService(_managerRepo, _managerReadRepo);

            //act
            _managerReadRepo.FindAsync(Arg.Any<Guid>()).Returns(new Manager());

            _managerRepo.UpdateAsync(Arg.Any<Manager>()).Returns(new Manager());
            var result = await _managerAppService.UpdateAsync(new CreateUpdateManagerDto());

            await _managerRepo.Received().UpdateAsync(Arg.Any<Manager>());

            //assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<ManagerDto>();
            result.Age.ShouldBeGreaterThanOrEqualTo(0);
            result.ManagerName.ShouldBeNull();
        }

        [Fact]
        public void Test_managerAppService_Delete_Fail()
        {
            //Arrange
            IRepository<Manager> _managerRepo = Substitute.For<IRepository<Manager>>();
            ManagerAppService _managerAppService = new ManagerAppService(_managerRepo);

            //act
            var result = async () => { await _managerAppService.DeleteAsync(null); };

            //assert
            result.ShouldThrow<Exception>();
        }
    }
}
