using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Platform
{
    public partial class Form1 : Form
    {
        private PlatForm platForm = new PlatForm();
        private Display display = new Display(12);
        private List<Label> labels = new List<Label>();
        bool initialize = false;

        public Form1()
        {
            InitializeComponent();
            AddLAbels();
            setUpConnection();
            timer1.Start();
        }

        private void setUpConnection()
        {
            try
            {
                platForm.Connect("145.93.40.230", 8888);
                display.Connect();
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Failed to Connect to Host");
                Environment.Exit(1);
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show("The COM-Port is already in use");
                Environment.Exit(1);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("The Baundrate or the Port name are Incorrect");
                Environment.Exit(1);
            }
            catch (IOException)
            {
                MessageBox.Show("The Comport is Incorrect");
                Environment.Exit(1);
            }
        }

        private void LabelFiller()
        {
            for (int i = 0; i < platForm.trainUnits; i++)
            {
                labels[i].Text = platForm.freeSeats[i].ToString();
            }
        }


        private void AddLAbels()
        {
            labels.Add(Unit1LB);
            labels.Add(Unit2LB);
            labels.Add(Unit3Lb);
            labels.Add(Unit4Lb);
            labels.Add(Unit5Lb);
            labels.Add(Unit6Lb);
            labels.Add(Unit7Lb);
            labels.Add(Unit8Lb);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (initialize == false)
                {
                    string info = platForm.read("Initialize");
                    platForm.GetTrainInfo(info);
                    idLabel.Text = platForm.TrainID.ToString();
                    initialize = true;
                }
                else
                {
                    string info = platForm.read("SeatInfo");
                    platForm.GetSeatInfo(info);
                    if (platForm.UnitsChanged == true)
                    {
                        initialize = false;
                        ResetLabels();
                        return;
                    }
                    LabelFiller();
                    display.Send(platForm.send());
                }
            }
            catch (IOException exception)
            {
                setUpConnection();
            }

        }
        private void ResetLabels()
        {
            for (int i = 0; i < 7; i++)
            {
                labels[i].Text = "0";
            }
        }
    }
}
