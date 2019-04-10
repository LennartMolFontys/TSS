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
        private Display display = new Display(4);

        public Form1()
        {
            InitializeComponent();
            try
            {
                platForm.Connect("145.93.61.189", 8888);
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
               string test = platForm.GetTrainInfo();         
               MessageBox.Show(test);
        }
    }
}
