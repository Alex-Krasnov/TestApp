using Microsoft.AspNetCore.Mvc;
using TestApp.Data;
using TestApp.Models.DbModels;
using TestApp.Models.InputModels;

namespace TestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckPointsController : ControllerBase
    {
        private readonly TestAppContext _context;

        public CheckPointsController(TestAppContext context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult AddCheckPoint(NewCheckPointPlus newCheckPointPlus)
        {
            if (_context.CheckPoints == null)
                return BadRequest("Entity set 'TestAppContext.CheckPoints'  is null.");

            if (newCheckPointPlus.CheckPoint == null)
                return BadRequest("Отсутствуют данные точки измерения электроэнергии");

            if (_context.CheckPoints.Any(e => e.CheckPointId == newCheckPointPlus.CheckPoint.CheckPointId))
                return BadRequest("Повторяющееся значение ключа нарушает ограничение уникальности PK_CheckPoints");

            CheckPoint checkPoint = new()
            {
                CheckPointId = newCheckPointPlus.CheckPoint.CheckPointId,
                Name = newCheckPointPlus.CheckPoint.Name,
                ObjConsumptionId = newCheckPointPlus.CheckPoint.ObjConsumptionId
            };

            _context.CheckPoints.Add(checkPoint);


            if(newCheckPointPlus.ElectricityMeter != null)
            {
                if (_context.ElectricityMeters.Any(e => e.ElectricityMeterId == newCheckPointPlus.ElectricityMeter.ElectricityMeterId))
                    return BadRequest("Повторяющееся значение ключа нарушает ограничение уникальности PK_ElectricityMeters");

                ElectricityMeter electricityMeter = new() 
                {
                    ElectricityMeterId = newCheckPointPlus.ElectricityMeter.ElectricityMeterId,
                    Number = newCheckPointPlus.ElectricityMeter.Number,
                    CheckDate = newCheckPointPlus.ElectricityMeter.CheckDate,
                    CheckPointId = newCheckPointPlus.ElectricityMeter.CheckPointId
                };

                _context.ElectricityMeters.Add(electricityMeter);
            }

            if(newCheckPointPlus.CurrentTransformer != null)
            {
                if (_context.CurrentTransformers.Any(e => e.CurrentTransformerId == newCheckPointPlus.CurrentTransformer.CurrentTransformerId))
                    return BadRequest("Повторяющееся значение ключа нарушает ограничение уникальности PK_CurrentTransformers");

                CurrentTransformer currentTransformer = new() 
                {
                    CurrentTransformerId = newCheckPointPlus.CurrentTransformer.CurrentTransformerId,
                    Number = newCheckPointPlus.CurrentTransformer.Number,
                    CurrentTransformerType = newCheckPointPlus.CurrentTransformer.CurrentTransformerType,
                    CheckDate = newCheckPointPlus.CurrentTransformer.CheckDate,
                    TransformationCoefficient = newCheckPointPlus.CurrentTransformer.TransformationCoefficient,
                    CheckPointId = newCheckPointPlus.CurrentTransformer.CheckPointId
                };
                _context.CurrentTransformers.Add(currentTransformer);
            }

            if(newCheckPointPlus.VoltageTransformer != null)
            {
                if (_context.VoltageTransformers.Any(e => e.VoltageTransformerId == newCheckPointPlus.VoltageTransformer.VoltageTransformerId))
                    return BadRequest("Повторяющееся значение ключа нарушает ограничение уникальности PK_VoltageTransformers");

                VoltageTransformer voltageTransformer = new() 
                {
                    VoltageTransformerId = newCheckPointPlus.VoltageTransformer.VoltageTransformerId,
                    Number = newCheckPointPlus.VoltageTransformer.Number,
                    VoltageTransformerType = newCheckPointPlus.VoltageTransformer.VoltageTransformerType,
                    CheckDate = newCheckPointPlus.VoltageTransformer.CheckDate,
                    TransformationCoefficient = newCheckPointPlus.VoltageTransformer.TransformationCoefficient,
                    CheckPointId = newCheckPointPlus.VoltageTransformer.CheckPointId,
                };
                _context.VoltageTransformers.Add(voltageTransformer);
            }

            _context.SaveChanges();

            return Ok("Данные успешно добавлены");
        }
    }
}
