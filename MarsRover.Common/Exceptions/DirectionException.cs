using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Common.Exceptions
{
    public class DirectionException : Exception
    {
        public DirectionException() : base("Invalid Direction")
        {

        }
    }
}
