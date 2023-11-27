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
    public class ObjectCurTransExpiredVerificationPeriod : ControllerBase
    {
        private readonly TestAppContext _context;

        public ObjectCurTransExpiredVerificationPeriod(TestAppContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetObjectCurTransExpiredVerificationPeriod(int id)
        {
          if (_context.ObjConsumptions == null)
          {
              return NotFound();
          }
          if (!_context.ObjConsumptions.Any(e => e.ObjConsumptionId == id))
                return NotFound();

            var checkPoints = _context.CheckPoints.Where(e => e.ObjConsumptionId == id).ToList();
            List<int> listCurrentTransformers = new();

            foreach (var checkPoint in checkPoints)
            {
                var currentTransformers = _context.CurrentTransformers.Where(e => e.CheckPointId == checkPoint.CheckPointId 
                                                                            && e.CheckDate < DateOnly.FromDateTime(DateTime.Now)).ToList();
                foreach (var currentTransformer in currentTransformers)
                    listCurrentTransformers.Add(currentTransformer.Number);
            }

          return Ok(listCurrentTransformers);
        }
    }
}
