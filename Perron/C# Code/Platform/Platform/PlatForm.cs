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
        public string trainInfo { get; private set; }
        private string seatInfo = "";
        public Train train { get; private set; }
        private int[,] UnitInfo;
        private int[] SeatsTaken;
        public int[] freeSeats { get; private set; }
        public int trainUnits { get; private set; }
        private string OldSeatInfo = "";
        public bool  UnitsChanged { get; private set; }
        


        private NetWork netWork;
        
        public PlatForm()
        {
            TrainID = 0;
            trainInfo = string.Empty;
        }

        private void Add(int trainID)
        {
            train = new Train(trainID);
            for(int i = 0; i < trainUnits; i ++)
            {
                train.Add(UnitInfo[i, 0], UnitInfo[i, 1]);
            }
        }


        public void GetTrainInfo()
        {
           UnitsChanged = false;
           trainInfo =  netWork.Getinfo("Initialize"); 
           TrainID = StringSplitter.GetTrainId(trainInfo);
           trainUnits = StringSplitter.GetUnitAmount(trainInfo);
           UnitInfo = StringSplitter.GetUnitInfo(trainInfo);
           Add(TrainID);

        }

        public void GetSeatInfo()
        {
            seatInfo = netWork.Getinfo("SeatInfo");
            if((OldSeatInfo.Length - 3) > seatInfo.Length)
            {
                UnitsChanged = true;
                OldSeatInfo = seatInfo;
                return;
            }
            else if((OldSeatInfo.Length + 3) < seatInfo.Length)
            {
                UnitsChanged = true;
                OldSeatInfo = seatInfo;
            }
            SeatsTaken = StringSplitter.GetSeatsTaken(seatInfo);
            OldSeatInfo = seatInfo;
            FreeSeats();
        }

        private void FreeSeats()
        {
            freeSeats = new int[trainUnits];
            for(int i = 0; i < trainUnits; i++)
            {
                freeSeats[i] = train.trainUnits[i].GetFreeSeats(SeatsTaken[i]);
            }
        }

        public void Connect(string NetworkIpAdress, int NetWorkPort)
        {
            if(!string.IsNullOrEmpty(NetworkIpAdress) && NetWorkPort > 0)
            {
                netWork = new NetWork(NetworkIpAdress, NetWorkPort);
                netWork.Connect();
            }
        }

        public string send()
        {
            string DisplaysString = "";
            for(int i = 0; i < freeSeats.Length; i++)
            {
                string seat = freeSeats[i].ToString();
                while (seat.Length < 4)
                {
                    seat = "0" + seat;
                }
                DisplaysString += seat;
            }
            
            return DisplaysString.ToString();
        }
    }
}
