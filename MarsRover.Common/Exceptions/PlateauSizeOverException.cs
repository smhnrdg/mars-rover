using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Common.Exceptions
{
    public class PlateauSizeOverException : Exception
    {
        public PlateauSizeOverException() : base("Plateau Size Exceeded")
        {

        }

        public PlateauSizeOverException(string message) : base($"Plateau {message} Direction is Over")
        {

        }
    }
}
