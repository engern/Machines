using AutoMapper;
using System;

namespace Machines.BL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Db.Machine, Models.VM.MachineGet>();
            CreateMap<Models.VM.MachinePost, Models.Db.Machine>();
            CreateMap<Models.VM.MachinePut, Models.Db.Machine>();
        }
    }
}
