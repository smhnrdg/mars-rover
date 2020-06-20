using MarsRover.Business.Services;
using MarsRover.Common.Enum;
using MarsRover.Common.Exceptions;
using MarsRover.Core.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Test
{
    public class RoverCommanderTest
    {
        private IRoverCommander roverCommander;

        [SetUp]
        public void Setup()
        {
            roverCommander = new RoverCommander()
            {
                Plateau = new Plateau()
                {
                    SizeX = 5,
                    SizeY = 5,
                }
            };

            roverCommander.Plateau.Rovers.Add(new Rover() { LocationX = 1, LocationY = 2, Direction = RoverDirections.N, Commands = "LMLMLMLMM" });
            }

        [Test]
        public void RoverCommander_Move()
        {
            var rover = roverCommander.Plateau.Rovers[0];

            roverCommander.Move(rover);

            Assert.AreEqual(1, rover.LocationX);
            Assert.AreEqual(3, rover.LocationY);
            Assert.AreEqual(RoverDirections.N, rover.Direction);
        }

        [Test]
        public void RoverCommander_Move_CommandException()
        {
            var rover = roverCommander.Plateau.Rovers[0];
            rover.Commands = "LMLML?MLMM";

            Assert.Throws(typeof(CommandException), () => roverCommander.Move(rover));
        }

        [Test]
        public void RoverCommander_Move_PlateauSizeOverException()
        {
            var rover = roverCommander.Plateau.Rovers[0];
            rover.Commands = "LMLMLMMMMMMLMM";

            Assert.Throws(typeof(PlateauSizeOverException), () => roverCommander.Move(rover));
        }
    }
}
