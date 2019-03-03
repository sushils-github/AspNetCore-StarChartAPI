using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StarChart.Data;

namespace StarChart.Controllers
{
    [Route("")]
    [ApiController]
    public class CelestialObjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CelestialObjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}", Name ="GetById")]
        public IActionResult GetById(int id)
        {
            var celedtialObject = _context.CelestialObjects.Find(id);
            if (celedtialObject == null)
                return NotFound();

            celedtialObject.Satellites = _context.CelestialObjects.Where(e => e.OrbitedObjectId == id).ToList();
            return Ok(celedtialObject);
        }

        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            var celedtialObjects = _context.CelestialObjects.Where(e => e.Name == name).ToList();
            if (!celedtialObjects.Any())
                return NotFound();

            foreach(var celedtialObject in celedtialObjects)
            {
                celedtialObject.Satellites = _context.CelestialObjects.Where(e => e.OrbitedObjectId == celedtialObject.Id).ToList();
            }

            return Ok(celedtialObjects);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var celedtialObjects = _context.CelestialObjects.ToList();
            if (!celedtialObjects.Any())
                return NotFound();

            foreach (var celedtialObject in celedtialObjects)
            {
                celedtialObject.Satellites = _context.CelestialObjects.Where(e => e.OrbitedObjectId == celedtialObject.Id).ToList();
            }

            return Ok(celedtialObjects);

        }
    }
}
