using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using TestApp.Data;
using TestApp.Models.DbModels;

namespace TestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectVoltTransExpiredVerificationPeriod : ControllerBase
    {
        private readonly TestAppContext _context;

        public ObjectVoltTransExpiredVerificationPeriod(TestAppContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetObjectVoltTransExpiredVerificationPeriod(int id)
        {
          if (_context.ObjConsumptions == null)
          {
              return NotFound();
          }
          if (!_context.ObjConsumptions.Any(e => e.ObjConsumptionId == id))
                return NotFound();

            var checkPoints = _context.CheckPoints.Where(e => e.ObjConsumptionId == id).ToList();
            List<int> listVoltageTransformers = new();

            foreach (var checkPoint in checkPoints)
            {
                var voltageTransformers = _context.VoltageTransformers.Where(e => e.CheckPointId == checkPoint.CheckPointId 
                                                                            && e.CheckDate < DateOnly.FromDateTime(DateTime.Now)).ToList();
                foreach (var voltageTransformer in voltageTransformers)
                    listVoltageTransformers.Add(voltageTransformer.Number);
            }

          return Ok(listVoltageTransformers);
        }
    }
}
