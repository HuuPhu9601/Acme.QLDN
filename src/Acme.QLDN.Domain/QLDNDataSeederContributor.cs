﻿using Acme.QLDN.Managers;
using Acme.QLDN.OrgUnits;
using Acme.QLDN.Staffs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Acme.QLDN
{
    public class QLDNDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<OrgUnit, Guid> _orgUnitRepo;
        private readonly IRepository<Manager, Guid> _managerRepo;
        private readonly IRepository<Staff, Guid> _staffRepo;

        public QLDNDataSeederContributor(IRepository<OrgUnit, Guid> orgUnitRepo, IRepository<Manager, Guid> managerRepo, IRepository<Staff, Guid> staffRepo)
        {
            _orgUnitRepo = orgUnitRepo;
            _managerRepo = managerRepo;
            _staffRepo = staffRepo;
        }
        public async Task SeedAsync(DataSeedContext context)
        {
            Guid managerId1 = Guid.NewGuid();
            Guid managerId2 = Guid.NewGuid();
            Guid managerId3 = Guid.NewGuid();

            if (await _staffRepo.GetCountAsync() == 0)
            {
                await _staffRepo.InsertManyAsync(new List<Staff>()
                {
                    new Staff(){StaffName = "Nhan vien 1", Age = 25,Address = "Ha Noi", StatusId = 1},
                    new Staff(){StaffName = "Nhan vien 2", Age = 25,Address = "Ha Noi", StatusId = 1},
                    new Staff(){StaffName = "Nhan vien 3", Age = 25,Address = "Ha Noi", StatusId = 1},
                });
            }
        }
    }
}
