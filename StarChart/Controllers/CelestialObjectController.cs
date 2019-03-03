using System;
using Microsoft.AspNetCore.Mvc;
using StarChart.Data;

namespace StarChart
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
    }
}
