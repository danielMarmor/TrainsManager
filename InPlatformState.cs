using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainsManager
{
    public class InPlatformState : ITrainState
    {
        private Train _Train;
        public InPlatformState(Train train)
        {
            _Train = train;
        }
        public void AddCabin()
        {
            _Train.CabinsCounter++;

            _Train.CabinList.Add(new Cabin(_Train.CabinsCounter));

            Console.WriteLine($"Cabin Number { _Train.CabinsCounter} Added!");
        }

        public void RemoveCabin()
        {
            var isEmpty =  _Train.CabinList.Count == 0;
            if (isEmpty)
            {
                throw new Exception($"Train is Empty - No Cabins!");
            }
            var lastCabin = _Train.CabinList.Last();

            _Train.CabinList.Remove(lastCabin);

            _Train.CabinsCounter--;

            Console.WriteLine($"Cabin Number {lastCabin.Id} Removed!");
        }

        public TrainStatus StartMovement()
        {
            Console.WriteLine("Train In Movement!");

            var closeDoorsTasks = new List<Task>();

            foreach (var cabin in _Train.CabinList)
            {
                closeDoorsTasks.Add(Task.Run(() =>
                {
                    cabin.CloseDoors();
                }));
            }
            Task.WaitAll(closeDoorsTasks.ToArray());

            return TrainStatus.InMotion;
        }

        public TrainStatus StopTrain()
        {
            throw new Exception("Train Is In Platform - Cannot Stop!");
        }
    }
}
