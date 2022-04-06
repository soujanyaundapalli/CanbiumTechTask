using MarsRovers.Data.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRovers.Data.Entities
{
    public class Coordinates
    {
        /// <summary>
        /// x coordinate
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// y coordinate
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// rover facing direction
        /// </summary>
        public Directions Dir { get; set; }
    }
}
