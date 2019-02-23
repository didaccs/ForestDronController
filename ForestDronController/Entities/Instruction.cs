using System.Collections.Generic;

namespace ForestDronController.Entities
{
    public class Instruction
    {
        public Location StartPosition { get; set; }
        public List<Movement> Movements { get; set; }
    }
}
