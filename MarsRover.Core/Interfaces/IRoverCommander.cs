using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.Interfaces
{
    public interface IRoverCommander
    {
        IPlateau Plateau { get; set; }

        void Move(IRover rover);
    }
}
