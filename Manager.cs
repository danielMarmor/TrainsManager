using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainsManager
{
    public class Manager
    {
        Train _Train;
        public Manager(Train train)
        {
            _Train = train;
        }

        public void AddCabin()
        {
            _Train.AddCabin();
        }

        public void RemoveCabin()
        {
            _Train.RemoveCabin();
        }


        public void StartMovement()
        {
            _Train.Head.Start();
        }

        public void StopTrain()
        {
            _Train.Head.Stop();
        }

        public void PostMessage(string message)
        {
            _Train.Head.PostMessage(message);
        }


    }
}
