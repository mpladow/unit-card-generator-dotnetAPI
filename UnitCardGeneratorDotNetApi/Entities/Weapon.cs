using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitCardGeneratorDotNetApi.Entities
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Range { get; set; }
        public string MovingRof { get; set; }
        public string HaltedRof { get; set; }
        public string AT { get; set; }
        public string FP { get; set; }
        public bool Artillery { get; set; }
        public bool Salvo { get; set; }
        public bool Main { get; set; }
    }
}
