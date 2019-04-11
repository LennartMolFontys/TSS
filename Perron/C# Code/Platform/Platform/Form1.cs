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
        private Display display = new Display(7);
        private Label[] labels;

        public Form1()
        {
            InitializeComponent();
           labels = new Label[]{ Unit1LB, Unit2LB, Unit3Lb, Unit4Lb, Unit5Lb, Unit6Lb, Unit7Lb, Unit8Lb };
            try
            {
                platForm.Connect("145.93.40.170", 8888);
                display.Connect();
            }
            catch (InvalidOperationException Exception)
            {
                MessageBox.Show(Exception.Message);
                Environment.Exit(1);
            }
            catch(UnauthorizedAccessException Exception)
            {
                MessageBox.Show(Exception.Message);
                Environment.Exit(1);
            }
            catch(ArgumentOutOfRangeException Exception)
            {
                MessageBox.Show(Exception.Message);
                Environment.Exit(1);
            }
            catch(IOException Exception)
            {
                MessageBox.Show(Exception.Message);
                Environment.Exit(1);
            }
        }

        private void TreinInfoBtn_Click(object sender, EventArgs e)
        {
            platForm.GetTrainInfo();
            idLabel.Text = platForm.TrainID.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            platForm.GetSeatInfo();
            LabelFiller();
            display.Send(platForm.send());
        }

        private void LabelFiller()
         {
             for(int i = 0; i < platForm.trainUnits; i++)
             {
                 labels[i].Text = platForm.freeSeats[i].ToString();
             }
         }

    }
}
