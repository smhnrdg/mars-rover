using MarsRover.Common.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.Interfaces
{
    public interface IRover
    {
        int LocationX { get; set; }
        int LocationY { get; set; }
        RoverDirections Direction { get; set; }
        string Commands { get; set; }

        void TurnLeft();
        void TurnRight();
        void StepForward();
        void SetPosition(string roverPosition);
    }
}
