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
        private List<List<int>> SeatsTaken;
        public int[] freeSeats { get; private set; }
        public int trainUnits { get; private set; }
        private string OldSeatInfo = "";
        public bool  UnitsChanged { get; private set; }

        private NetWork netWork;
        
        public PlatForm()
        {
            TrainID = 0;
            trainUnits = 0;
            trainInfo = string.Empty;
        }

        private void Add(int trainID)
        {
            if (TrainID > 0)
            {
                train = new Train(trainID);
                for (int i = 0; i < trainUnits; i++)
                {
                    train.Add(UnitInfo[i, 0], UnitInfo[i, 1]);
                }
            }
        }


        public void GetTrainInfo(string Info)
        {
            if (!string.IsNullOrEmpty(Info))
            {
                UnitsChanged = false;
                trainInfo = Info;
                TrainID = StringFormatter.GetTrainId(trainInfo);
                trainUnits = StringFormatter.GetUnitAmount(trainInfo);
                UnitInfo = StringFormatter.GetUnitInfo(trainInfo);
                Add(TrainID);
            }
        }

        public void GetSeatInfo(string info)
        {
            if (!string.IsNullOrEmpty(info))
            {
                seatInfo = info;
                if ((OldSeatInfo.Length - 3) > seatInfo.Length)
                {
                    UnitsChanged = true;
                    OldSeatInfo = seatInfo;
                    return;
                }
                else if ((OldSeatInfo.Length + 3) < seatInfo.Length)
                {
                    UnitsChanged = true;
                    OldSeatInfo = seatInfo;
                }
                SeatsTaken = StringFormatter.GetSeatsTaken(seatInfo);
                if(SeatsTaken.Count > 0)
                {
                    OldSeatInfo = seatInfo;
                    FreeSeats();
                }
                
            }
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

        public string read(string Information)
        {
            if(!string.IsNullOrEmpty(Information))
            {
                return netWork.Getinfo(Information);
            }

            return "";
        }
    }
}
