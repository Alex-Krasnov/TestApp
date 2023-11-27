using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApp.Data;
using TestApp.Models.DbModels;

namespace TestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationDevicesController : ControllerBase
    {
        private readonly TestAppContext _context;

        public CalculationDevicesController(TestAppContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult GetCalculationDevices()
        {
          if (_context.CalculationDevices == null)
          {
              return NotFound();
          }

            return Ok(_context.CalculationDevices.Where(e => e.Date >= new DateOnly(2018, 1, 1) && e.Date <= new DateOnly(2018, 12, 31)).ToList());
        }
    }
}
