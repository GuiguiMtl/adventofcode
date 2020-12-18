using System;

namespace day4_part1
{
    public class HeightParser
    {
        public static bool TryParse(string value, out Height height)
        {
            if (value.EndsWith("cm"))
            {
                height = new HeightCm(Convert.ToInt32(value.Substring(0, value.Length - 2)));
                return true;
            }
            else if(value.EndsWith("in"))
            {
                height = new HeightIn(Convert.ToInt32(value.Substring(0, value.Length - 2)));
                return true;
            }

            height = default;
            return false;
        }
    }
}