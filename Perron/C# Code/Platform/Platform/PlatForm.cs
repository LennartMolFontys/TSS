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


        public void GetTrainInfo() // Add this for test (string test)
        {

           trainInfo =  netWork.Getinfo("Initialize"); //"ID:5UnitAmount:2 Length: 4TotalSeats: 5Length: 3TotalSeats: 9";  // Add this to test trainInfo =  test;
            TrainID = StringSplitter.GetTrainId(trainInfo);
           trainUnits = StringSplitter.GetUnitAmount(trainInfo);
           UnitInfo = StringSplitter.GetUnitInfo(trainInfo);
           Add(TrainID);

        }

        public void GetSeatInfo()
        {
            seatInfo = netWork.Getinfo("SeatInfo"); //"SeatsTaken:3SeatsTaken:3";
            SeatsTaken = StringSplitter.GetSeatsTaken(seatInfo);
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
            netWork = new NetWork(NetworkIpAdress,NetWorkPort);
            netWork.Connect(); 
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
