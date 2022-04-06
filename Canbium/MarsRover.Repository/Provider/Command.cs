using MarsRovers.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Repository.Provider
{
    public interface Command
    {
        /// <summary>
        /// execute rover rotation/movement
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        public Coordinates Execute(Coordinates coordinates);
    }
}
