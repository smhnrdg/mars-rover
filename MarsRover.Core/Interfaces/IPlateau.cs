using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Core.Interfaces
{
    public interface IPlateau
    {
        List<IRover> Rovers { get; set; }
        int SizeX { get; set; }
        int SizeY { get; set; }

        void SetSize(string plataeuSize);

        void AddRover(IRover rover);

    }
}
