using Acme.QLDN.Managers;
using Acme.QLDN.OrgUnits;
using Acme.QLDN.Staffs;
using AutoMapper;

namespace Acme.QLDN;

public class QLDNApplicationAutoMapperProfile : Profile
{
    public QLDNApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<OrgUnit, OrgUnitDto>();
        CreateMap<CreateUpdateOrgUnitDto, OrgUnit>();

        CreateMap<Manager, ManagerDto>();
        CreateMap<CreateUpdateManagerDto, Manager>();

        CreateMap<Staff, StaffDto>();
        CreateMap<CreateUpdateStaffDto, Staff>();
    }
}
