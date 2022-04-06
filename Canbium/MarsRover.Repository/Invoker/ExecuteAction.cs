using MarsRovers.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Repository.Invoker
{
    public class ExecuteAction : Provider.Invoker
    {
        /// <summary>
        /// start movement of rover
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public Coordinates StartMoving(Provider.Command command, Coordinates coordinates)
        {
            return command.Execute(coordinates);
        }
    }
}
