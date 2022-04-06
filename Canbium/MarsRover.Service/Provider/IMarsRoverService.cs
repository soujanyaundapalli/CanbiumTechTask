using MarsRover.Repository.Provider;
using MarsRovers.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Service.Provider
{
    public interface IMarsRoverService
    {

        /// <summary>
        /// rover movement
        /// </summary>
        /// <param name="maxPoints"></param>
        /// <param name="currentLocation"></param>
        /// <param name="movement"></param>
        /// <returns></returns>
        Coordinates MoveRoverSync(string[] maxPoints, string[] currentLocation, string movement, Invoker _invoker);
    }
}
