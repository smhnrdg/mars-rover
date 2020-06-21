using MarsRover.Business.Services;
using MarsRover.Common.Enum;
using MarsRover.Common.Exceptions;
using MarsRover.Core.Interfaces;
using MarsRover.IoC;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Test
{
    public class RoverCommanderTest
    {
        private IRoverCommander roverCommander;
        private IPlateau plateau;
        private IRover rover;

        [SetUp]
        public void Setup()
        {
            var services = ServiceContainerBuilder.ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            var plateau = serviceProvider.GetService<IPlateau>();
            plateau.SetSize("5 5");

            roverCommander = serviceProvider.GetService<IRoverCommander>();
            roverCommander.Plateau = plateau;

            rover = serviceProvider.GetService<IRover>();
            rover.SetPosition("1 2 N");
            rover.Commands = "LMLMLMLMM";

            roverCommander.Plateau.AddRover(rover);
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
