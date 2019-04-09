using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform
{
    public class PlatForm
    {
        public int TrainID { get; private set; }
        private string trainInfo = "";
        private string seatInfo = "";
        public Train train { get; private set; }

        private int trainUnits = 0;


        private NetWork netWork;
        
        public PlatForm(string NetworkIpAdress , int  NetWorkPort)
        {
            TrainID = 0;
            trainInfo = string.Empty;
            netWork = new NetWork(NetworkIpAdress, NetWorkPort);
        }

        public void Add(int trainID)
        {
            train = new Train(trainID);
        }

        public void GetTrainInfo()
        {
            if(netWork.Conneted)
            {
               trainInfo = netWork.Getinfo("Initialize");
            }
        }

        public void GetSeatInfo()
        {
            if (netWork.Conneted)
            {
                 seatInfo = netWork.Getinfo("Send seat info");
            }
        }

 

    }
}
