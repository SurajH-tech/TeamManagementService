using AutoMapper;
using TMS.Application.Responses;
using TMS.Core.Responses;
using TMS.Utilities;

namespace TMS.Application.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {
            CreateMap<AddBusinessUnitCoreResponse, AddBusinessUnitResponse>().ReverseMap();
            CreateMap<UpdateBusinessUnitCoreResponse, UpdateBusinessUnitResponse>().ReverseMap();
            CreateMap<DeleteBusinessUnitMemberCoreResponse, DeleteBusinessUnitMemberResponse>().ReverseMap();
            CreateMap<AddBusinessUnitMemberCoreResponse, AddBusinessUnitMemberResponse>().ReverseMap();

            // Add Mapping for Search Employee Response Object Mappings.

            CreateMap(typeof(QueryResult<>), typeof(QueryResultDto<>)).ReverseMap();
            CreateMap(typeof(CommandResult<>), typeof(CommandResultDto<>)).ReverseMap();
        }
    }
}
