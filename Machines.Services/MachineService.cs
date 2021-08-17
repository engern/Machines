using AutoMapper;
using Machines.DAL;
using Machines.Models.Db;
using Machines.Models.VM;
using System;
using System.Collections.Generic;

namespace Machines.Services
{
    public class MachineService : IMachineService
    {
        public MachinesContext _db { get; }
        public IMapper _mapper { get; set; }

        public MachineService(MachinesContext dbContext, IMapper mapper)
        {
            _db = dbContext;
            _mapper = mapper;
        }

        public MachineGet Add(MachinePost machine)
        {
            var entity = _mapper.Map<Machine>(machine);
            entity.Id = Guid.NewGuid();
            _db.Add(entity);
            _db.SaveChanges();

            return Get(entity.Id);
        }

        public MachineGet Get(Guid id)
        {
            var machineEntity = _db.Machine.Find(id);
            if (machineEntity == null)
                throw new KeyNotFoundException();
            return _mapper.Map<MachineGet>(machineEntity);
        }

        public IEnumerable<MachineGet> GetAll()
        {
            return _mapper.Map<IEnumerable<MachineGet>>(_db.Machine);
        }

        public MachineGet Update(MachinePut machine)
        {
            var updatedEntity = _mapper.Map<Machine>(machine);

            var existingEntity = _db.Machine.Find(machine.Id);
            if (existingEntity == null)
                throw new KeyNotFoundException();

            _db.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);

            _db.SaveChanges();

            return Get(machine.Id);
        }

        public bool Delete(Guid id)
        {
            var entity = _db.Machine.Find(id);
            if (entity == null)
                return false;

            _db.Machine.Remove(entity);
            return _db.SaveChanges() > 0;
        }
    }
}
