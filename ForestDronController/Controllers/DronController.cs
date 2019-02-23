using ForestDronController.Entities;

namespace ForestDronController.Controllers
{
    public class DronController: DeviceController
    {
        public DronController(Area area): 
            base(new Location() { X = 0, Y = 0, Direction = Direction.North }, area)
        {
        }

        public Location ManageInstructions(Instruction instruction)
        {
            base.UpdateStartPosition(instruction.StartPosition);
            base.ProcessMovements(instruction.Movements);

            return base.CurrentPosition;
        }
    }
}
