using MarsRover.Business.Services;
using MarsRover.Common.Enum;
using MarsRover.Common.Exceptions;
using MarsRover.Core.Interfaces;
using MarsRover.IoC;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace MarsRover.Test
{
    public class RoverTest
    {
        private IRover rover;

        [SetUp]
        public void Setup()
        {
            var services = ServiceContainerBuilder.ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            rover = serviceProvider.GetService<IRover>();

            rover.SetPosition("1 2 N");
        }

        [Test]
        public void Rover_TurnLeft()
        {
            rover.TurnLeft();

            Assert.AreEqual(RoverDirections.W, rover.Direction);
        }

        [Test]
        public void Rover_TurnRight()
        {
            rover.TurnRight();

            Assert.AreEqual(RoverDirections.E, rover.Direction);
        }

        [Test]
        public void Rover_StepForward()
        {
            rover.StepForward();

            Assert.AreEqual(3, rover.LocationY);
            Assert.AreEqual(RoverDirections.N, rover.Direction);
        }

        [Test]
        public void Rover_SetPosition()
        {
            rover.SetPosition("3 4 E");

            Assert.AreEqual(3, rover.LocationX);
            Assert.AreEqual(4, rover.LocationY);
            Assert.AreEqual(RoverDirections.E, rover.Direction);
        }
    }
}