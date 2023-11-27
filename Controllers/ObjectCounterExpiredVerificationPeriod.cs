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
    public class ObjectCounterExpiredVerificationPeriod : ControllerBase
    {
        private readonly TestAppContext _context;

        public ObjectCounterExpiredVerificationPeriod(TestAppContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetObjectCounterExpiredVerificationPeriod(int id)
        {
          if (_context.ObjConsumptions == null)
          {
              return NotFound();
          }
          if (!_context.ObjConsumptions.Any(e => e.ObjConsumptionId == id))
                return NotFound();

            var checkPoints = _context.CheckPoints.Where(e => e.ObjConsumptionId == id).ToList();
            List<int> listElectricityMeters = new();

            foreach (var checkPoint in checkPoints)
            {
                var electricityMeters = _context.ElectricityMeters.Where(e => e.CheckPointId == checkPoint.CheckPointId
                                                                            && e.CheckDate < DateOnly.FromDateTime(DateTime.Now)).ToList();
                foreach (var electricityMeter in electricityMeters)
                    listElectricityMeters.Add(electricityMeter.Number);
            }

          return Ok(listElectricityMeters);
        }
    }
}
