using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainsManager
{
    public class Locomtive
    {
        Train _Train;
        public Locomtive(Train train) 
        {
            _Train = train;
        }

        public void Start()
        {
            _Train.StartMovement();
        }

        public void Stop()
        {
           _Train.StopTrain();
        }

        public void PostMessage(string messsage)
        {
            if (_Train.CabinList.Count == 0)
            {
                throw new Exception("No Cabins on Train!");
            }
            var postMessagesTasks = new List<Task>();

            foreach (var cabin in _Train.CabinList)
            {
                postMessagesTasks.Add(Task.Run(() =>
                {
                    cabin.PostMessage(messsage);
                }));
            }
            Task.WaitAll(postMessagesTasks.ToArray());
        }
    }
}
