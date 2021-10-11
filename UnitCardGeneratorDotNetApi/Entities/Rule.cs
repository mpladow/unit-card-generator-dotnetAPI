using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UnitCardGeneratorDotNetApi.Entities
{
    [Table("Rules", Schema="ucg")]
    public class Rule
    {
        public int RuleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool DisplayFront { get; set; }
    }
}
