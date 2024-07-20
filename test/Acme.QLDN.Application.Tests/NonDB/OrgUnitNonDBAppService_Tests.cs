using Acme.QLDN.OrgUnits;
using NSubstitute;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Acme.QLDN.NonDB
{
    public class OrgUnitNonDBAppService_Tests
    {
        [Fact]
        public async Task Test_OrgUnitAppService_GetList()
        {
            //Arrange
            IRepository<OrgUnit> _orgUnitRepo = Substitute.For<IRepository<OrgUnit>>();
            OrgUnitAppService _orgUnitAppService = new OrgUnitAppService(_orgUnitRepo);
            //act
            _orgUnitRepo.GetListAsync().Returns(x => new List<OrgUnit>() { new OrgUnit(), new OrgUnit() });
            var result = await _orgUnitAppService.GetListAsync();
            await _orgUnitRepo.Received().GetListAsync();

            //assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<List<OrgUnitDto>>();
            result.Count.ShouldBe(2);
        }

        [Fact]
        public void Test_OrgUnitAppService_CreateOne_Fail()
        {
            //Arrange
            IRepository<OrgUnit> _orgUnitRepo = Substitute.For<IRepository<OrgUnit>>();
            OrgUnitAppService _orgUnitAppService = new OrgUnitAppService(_orgUnitRepo);

            //act
            var result = async () => { await _orgUnitAppService.CreateAsync(null); };

            //assert
            result.ShouldThrow<Exception>();
        }

        [Fact]
        public async Task Test_OrgUnitAppService_CreateOne_Success()
        {
            //Arrange
            IRepository<OrgUnit> _orgUnitRepo = Substitute.For<IRepository<OrgUnit>>();
            OrgUnitAppService _orgUnitAppService = new OrgUnitAppService(_orgUnitRepo);

            //act
            _orgUnitRepo.InsertAsync(Arg.Any<OrgUnit>()).Returns(new OrgUnit());
            var result = await _orgUnitAppService.CreateAsync(new CreateUpdateOrgUnitDto());
            await _orgUnitRepo.Received().InsertAsync(Arg.Any<OrgUnit>());

            //assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<OrgUnitDto>();
            result.MaxQty.ShouldBeGreaterThan(0);
            result.OrgUnitName.ShouldNotBeNull();
        }

        [Fact]
        public void Test_OrgUnitAppService_UpdateOne_Fail()
        {
            //Arrange
            IRepository<OrgUnit> _orgUnitRepo = Substitute.For<IRepository<OrgUnit>>();
            OrgUnitAppService _orgUnitAppService = new OrgUnitAppService(_orgUnitRepo);

            //act
            var result = async () => { await _orgUnitAppService.UpdateAsync(null); };

            //assert
            result.ShouldThrow<Exception>();
        }

        [Fact]
        public async Task Test_OrgUnitAppService_UpdateOne_Success()
        {
            //Arrange
            IRepository<OrgUnit> _orgUnitRepo = Substitute.For<IRepository<OrgUnit>>();
            IReadOnlyRepository<OrgUnit, Guid> _orgUnitReadRepo = Substitute.For<IRepository<OrgUnit, Guid>>();
            OrgUnitAppService _orgUnitAppService = new OrgUnitAppService(_orgUnitRepo, _orgUnitReadRepo);

            //act
            _orgUnitReadRepo.FindAsync(Arg.Any<Guid>()).Returns(new OrgUnit());

            _orgUnitRepo.UpdateAsync(Arg.Any<OrgUnit>()).Returns(new OrgUnit());
            var result = await _orgUnitAppService.UpdateAsync(new CreateUpdateOrgUnitDto());

            await _orgUnitRepo.Received().UpdateAsync(Arg.Any<OrgUnit>());

            //assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<OrgUnitDto>();
            result.MaxQty.ShouldBeGreaterThan(0);
            result.OrgUnitName.ShouldNotBeNull();
        }

        [Fact]
        public void Test_OrgUnitAppService_Delete_Fail()
        {
            //Arrange
            IRepository<OrgUnit> _orgUnitRepo = Substitute.For<IRepository<OrgUnit>>();
            OrgUnitAppService _orgUnitAppService = new OrgUnitAppService(_orgUnitRepo);

            //act
            var result = async () => { await _orgUnitAppService.DeleteAsync(null); };

            //assert
            result.ShouldThrow<Exception>();
        }

    }
}
