using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UnitCardGeneratorDotNetApi.Entities;
using UnitCardGeneratorDotNetApi.Models;

namespace UnitCardGeneratorDotNetApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RulesController : ControllerBase
    {

        private readonly ILogger<RulesController> _logger;
        private readonly CardGeneratorContext _db;

        public RulesController(ILogger<RulesController> logger, CardGeneratorContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<RulesDto>> Get()
        {
            var list = _db.Rules.Select(x => new RulesDto
            {
                Id = x.RuleId,
                Description = x.Description,
                DisplayFront = x.DisplayFront,
                Name = x.Name
            }).ToList();
            return list;
        }
    }
}
