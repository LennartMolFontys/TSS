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
        
        public PlatForm()
        {
            TrainID = 0;
            trainInfo = string.Empty;
        }

        public void Add(int trainID)
        {
            train = new Train(trainID);
        }

        public string GetTrainInfo()
        {
            if(netWork.Conneted)
            {
               trainInfo = netWork.Getinfo("Initialize");
            }
            return trainInfo;
        }

        public string GetSeatInfo()
        {
            if (netWork.Conneted)
            {
                 seatInfo = netWork.Getinfo("SeatInfo");
            }
            return seatInfo;
        }

        public void Connect(string NetworkIpAdress, int NetWorkPort)
        {
            netWork = new NetWork(NetworkIpAdress,NetWorkPort);
            netWork.Connect(); 
        }
    }
}
