using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace stringSplitter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string initialiseString = "ID:2365UnitAmount:3Length:3TotalSeats:30Length:5TotalSeats:30Length:6TotalSeats:30";
            label1.Text = StringSplitter.GetTrainId(initialiseString).ToString();
            StringSplitter.GetUnitInfo(initialiseString, StringSplitter.GetUnitAmount(initialiseString));
        }
    }
}
