using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class spinner : Form
    {
        public spinner()
        {
            InitializeComponent();
        }

        int startPoint = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            startPoint+=1;
           
            spinner1.Value = startPoint;
            timervar.Text = ""+startPoint;
            if (spinner1.Value == 100) {
                spinner1.Value = 0;
                timer1.Stop();
                Login l = new Login();
                l.Show();
                this.Hide();
            
            }
        }

        private void spinner_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
