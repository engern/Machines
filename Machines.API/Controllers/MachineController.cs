using Machines.Models.VM;
using Machines.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace Machines.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MachineController : ControllerBase
    {       
        private readonly ILogger<MachineController> _logger;
        private readonly IMachineService _machineService;

        public MachineController(ILogger<MachineController> logger, IMachineService machineService)
        {
            _logger = logger;
            _machineService = machineService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MachineGet>> Get()
        {
            try
            {
                return StatusCode((int)HttpStatusCode.OK, _machineService.GetAll());
            }
            catch (Exception ex)
            {
                LogError(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<MachineGet> Get(Guid id)
        {
            try
            {
                return StatusCode((int)HttpStatusCode.OK, _machineService.Get(id));
            }
            catch (Exception ex)
            {
                LogError(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<MachineGet> Post(MachinePost machine)
        {
            try
            {
                return StatusCode((int)HttpStatusCode.OK, _machineService.Add(machine));
            }
            catch (Exception ex)
            {
                LogError(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<MachineGet> Put(MachinePut machine)
        {
            try
            {                
                return StatusCode((int)HttpStatusCode.OK, _machineService.Update(machine));
            }
            catch (Exception ex)
            {
                LogError(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(Guid id)
        {
            try
            {
                return StatusCode((int)HttpStatusCode.OK, _machineService.Delete(id));
            }
            catch (Exception ex)
            {
                LogError(ex);
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        private void LogError(Exception ex)
        {
            _logger.LogError(ex, MethodBase.GetCurrentMethod().Name + " failed");
        }
    }
}
