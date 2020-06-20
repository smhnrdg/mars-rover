using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Common.Enum
{
    public static class Enumarations
    {
        public static string GetNameByValue(Type type, int value)
        {
            return System.Enum.GetName(type, value);
        }

        public static int GetValueByName(Type type, string value)
        {
            return (int)System.Enum.Parse(type, value);
        }
    }
}
