using Machines.Models.VM;
using System;
using System.Collections.Generic;

namespace Machines.Services
{
    public interface IMachineService
    {
        MachineGet Get(Guid id);
        IEnumerable<MachineGet> GetAll();
        MachineGet Add(MachinePost machine);
        MachineGet Update(MachinePut machine);
        bool Delete (Guid id);
    }
}
