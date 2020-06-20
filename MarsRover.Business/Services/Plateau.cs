using MarsRover.Common.Exceptions;
using MarsRover.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Business.Services
{
    public class Plateau : IPlateau
    {
        public List<IRover> Rovers { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }

        public Plateau()
        {
            Rovers = new List<IRover>();
        }

        public void SetSize(string plateauSize)
        {
            SizeX = Convert.ToInt32(plateauSize.Split(' ')[0]);
            SizeY = Convert.ToInt32(plateauSize.Split(' ')[1]);
        }

        public void AddRover(IRover rover)
        {
            if(rover.LocationX > SizeX || rover.LocationY > SizeY)
                throw new PlateauSizeOverException();

            Rovers.Add(rover);
        }
    }
}
