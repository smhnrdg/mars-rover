using MarsRover.Common.Enum;
using MarsRover.Common.Exceptions;
using MarsRover.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Business.Services
{
    public class Rover : IRover
    {
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public RoverDirections Direction { get; set ; }
        public string Commands { get; set; }

        public void TurnLeft()
        {
            Direction = Direction switch
            {
                RoverDirections.N => RoverDirections.W,
                RoverDirections.S => RoverDirections.E,
                RoverDirections.E => RoverDirections.N,
                RoverDirections.W => RoverDirections.S,
                _ => throw new DirectionException(),
            };
        }

        public void TurnRight()
        {
            Direction = Direction switch
            {
                RoverDirections.N => RoverDirections.E,
                RoverDirections.S => RoverDirections.W,
                RoverDirections.E => RoverDirections.S,
                RoverDirections.W => RoverDirections.N,
                _ => throw new DirectionException(),
            };
        }

        public void StepForward()
        {
            switch (Direction)
            {
                case RoverDirections.N:
                    LocationY++;
                    break;
                case RoverDirections.S:
                    LocationY--;
                    break;
                case RoverDirections.E:
                    LocationX++;
                    break;
                case RoverDirections.W:
                    LocationX--;
                    break;
                default:
                    throw new DirectionException();
            }
        }

        public void SetPosition(string roverPosition)
        {
            LocationX = Convert.ToInt32(roverPosition.Split(' ')[0]);
            LocationY = Convert.ToInt32(roverPosition.Split(' ')[1]);
            Direction = (RoverDirections)Enumarations.GetValueByName(typeof(RoverDirections), roverPosition.Split(' ')[2]);
        }
    }
}
