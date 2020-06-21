using MarsRover.Business.Services;
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
    public class PlateauTest
    {
        private IPlateau plateau;
        private IRover rover;

        [SetUp]
        public void Setup()
        {
            var services = ServiceContainerBuilder.ConfigureServices();
            var serviceProvider = services.BuildServiceProvider();

            plateau = serviceProvider.GetService<IPlateau>();
            rover = serviceProvider.GetService<IRover>();
        }


        [Test]
        public void Plateau_SetSize()
        {
            plateau.SetSize("5 4");
            Assert.AreEqual(5, plateau.SizeX);
            Assert.AreEqual(4, plateau.SizeY);
        }

        [Test]
        public void Plateau_AddRover()
        {
            plateau.SetSize("5 5");

            rover.SetPosition("1 2 N");

            plateau.AddRover(rover);

            Assert.AreEqual(1, plateau.Rovers.Count);
        }

        [Test]
        public void Plateau_AddRover_PlateauSizeOverException()
        {
            plateau.SetSize("5 5");

            rover.SetPosition("1 6 N");

            Assert.Throws(typeof(PlateauSizeOverException), () => plateau.AddRover(rover));
        }
    }
}
