﻿using MarsRovers.Data.Constants;
using MarsRovers.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Repository.Command
{
    public class MoveRight : Provider.Command
    {
        /// <summary>
        /// execute rotation
        /// </summary>
        /// <returns></returns>
        public Coordinates Execute(Coordinates coordinates)
        {
            switch (coordinates.Dir)
            {
                case Directions.N:
                    coordinates.Dir = Directions.E;
                    break;

                case Directions.E:
                    coordinates.Dir = Directions.S;
                    break;

                case Directions.S:
                    coordinates.Dir = Directions.W;
                    break;

                case Directions.W:
                    coordinates.Dir = Directions.N;
                    break;
            }
            return coordinates;
        }
    }
}
