using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainsManager
{
    public class Train
    {
        public int CabinsCounter { get; set; }
        public TrainStatus Status { get; set; }
        public Locomtive Head { get; set; }
        public List<Cabin> CabinList { get; set; }

        public Train()
        {
            Status = TrainStatus.InPlatform;

            Head = new Locomtive(this);

            CabinList = new List<Cabin>();

            CabinsCounter = 0;
        }

        public ITrainState GetTrainState (TrainStatus status)
        {
            switch (status)
            {
                case TrainStatus.InPlatform:
                    return new InPlatformState(this);
                case TrainStatus.InMotion:
                    return new InMovementState(this);

                default: throw new Exception("State not Identified");
            }
        }

        public void AddCabin()
        {
            var trainState = GetTrainState(Status);

            trainState.AddCabin();

        }

        public void RemoveCabin()
        {
            var trainState = GetTrainState(Status);

            trainState.RemoveCabin();
        }

        public void StartMovement()
        {
            var trainState = GetTrainState(Status);

            Status = trainState.StartMovement();
        }

        public void StopTrain()
        {
            var trainState = GetTrainState(Status);

            Status = trainState.StopTrain();
        }

    }
}
