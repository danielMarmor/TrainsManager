using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainsManager
{
    public class InMovementState : ITrainState
    {
        private Train _Train;
        public InMovementState(Train train)
        {
            _Train = train;
        }
        public void AddCabin()
        {
            throw new Exception("Train In Movement -- Cannot Add Cabin!");
        }

        public void RemoveCabin()
        {
            throw new Exception("Train In Movement -- Cannot Remove Cabin!");
        }

        public TrainStatus StartMovement()
        {
            throw new Exception("Train In Movement -- Cannot Start Movement!");
        }

        public TrainStatus StopTrain()
        {
            Console.WriteLine("Train Stopped!");

            var openDoorsTasks = new List<Task>();

            foreach (var cabin in _Train.CabinList)
            {
                openDoorsTasks.Add(Task.Run(() =>
                {
                    cabin.OpenDoors();
                }));
            }
            Task.WaitAll(openDoorsTasks.ToArray());

            return TrainStatus.InPlatform;
        }
    }
}

