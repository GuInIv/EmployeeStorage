using System.Collections.Generic;
using EmployeeStorage.Api.Models;
using EmployeeStorage.DataAccess.Entities;
using EmployeeStorage.Service.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeStorage.Api.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class PositionsController : Controller
    {
        readonly IPositionService service;
        public PositionsController(IPositionService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<Position> GetPositions()
        {
            return service.GetAll();
        }

        [HttpGet("{id}")]
        public Position GetPosition(int id)
        {
            return service.GetById(id);
        }

        [HttpPost]
        public IActionResult CreatePosition([FromBody] PositionData positionData)
        {
            if (ModelState.IsValid)
            {
                Position position = positionData.Position;
                service.Create(position);
                return Ok(position.Id);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePosition(int id, [FromBody] PositionData positionData)
        {
            if (ModelState.IsValid)
            {
                Position position = positionData.Position;
                position.Id = id;
                service.Update(position);
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete("{id}")]
        public void DeletePosition(int id)
        {
            service.Delete(id);
        }

        protected override void Dispose(bool disposing)
        {
            service.Dispose();
            base.Dispose(disposing);
        }
    }
}
