using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Common.Exceptions
{
    public class CommandException : Exception
    {
        public CommandException() : base("Invalid Command. Command letter should be L,R or M")
        {

        }
    }
}
