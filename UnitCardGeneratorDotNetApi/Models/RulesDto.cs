using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitCardGeneratorDotNetApi.Models
{
    public class RulesDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool DisplayFront { get; set; }
    }
}
