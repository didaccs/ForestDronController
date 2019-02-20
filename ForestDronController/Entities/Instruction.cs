using System;
using System.Collections.Generic;
using System.Text;

namespace ForestDronController.Entities
{
    public class Instruction
    {
        public Location StartPosition { get; set; }
        public Movement[] Movements { get; set; }
    }
}
