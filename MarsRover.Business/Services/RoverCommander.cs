using MarsRover.Common.Enum;
using MarsRover.Common.Exceptions;
using MarsRover.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Business.Services
{
    public class RoverCommander : IRoverCommander
    {
        public IPlateau Plateau { get ; set ; }

        public void Move(IRover rover)
        {
            char[] command = rover.Commands.ToCharArray();

            foreach (var singleCommand in command)
            {
                switch (singleCommand)
                {
                    case 'L':
                        rover.TurnLeft();
                        break;
                    case 'R':
                        rover.TurnRight();
                        break;
                    case 'M':
                        StepForwardRover(rover);
                        break;
                    default:
                        throw new CommandException();
                }
            }
        }

        private void StepForwardRover(IRover rover)
        {
            if (rover.Direction == RoverDirections.N && (rover.LocationY == Plateau.SizeY))
                throw new PlateauSizeOverException(rover.Direction.ToString());

            if (rover.Direction == RoverDirections.S && (rover.LocationY == 0))
                throw new PlateauSizeOverException(rover.Direction.ToString());

            if (rover.Direction == RoverDirections.E && (rover.LocationX == Plateau.SizeX))
                throw new PlateauSizeOverException(rover.Direction.ToString());

            if (rover.Direction == RoverDirections.W && (rover.LocationX == 0))
                throw new PlateauSizeOverException(rover.Direction.ToString());

            rover.StepForward();
        }
    }
}
