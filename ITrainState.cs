﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainsManager
{
    public interface ITrainState
    {
        void AddCabin();
        void RemoveCabin();
        TrainStatus StartMovement();
        TrainStatus StopTrain();
    }
}
