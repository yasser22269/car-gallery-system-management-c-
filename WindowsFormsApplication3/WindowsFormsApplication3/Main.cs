using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Main : Form
    {
        string constr = @"Data Source=YASSER\YASSER1;Initial Catalog=car;Integrated Security=True";
        SqlDataAdapter da;
        DataSet ds;


        public int id, userType;
        public string name;
        public Main(int id,string name,int userType)
        {
            this.id = id;
            this.userType = userType;
            this.name = name;
            InitializeComponent();
            label7.Text = name;
            if (userType == 0)
            {
                button1.Visible = false;
                button5.Visible = false;
                button4.Visible = false;
                button2.Visible = false;
                button7.Visible = false;
                button6.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
            }
            else
            {
                button3.Visible = false;
                button9.Visible = false;
                button10.Visible = false;
            }
        }
    
        public Main()
        {
            InitializeComponent();
        }


        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cars c = new cars(id, name, userType);
            c.Show();
            this.Hide();
        }

     

        private void button3_Click(object sender, EventArgs e)
        {
            Profile p = new Profile(id,name,userType);
            p.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            BuyCar b = new BuyCar(id,name,userType);
            b.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MyOrder b = new MyOrder(id, name, userType);
            b.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Orders b = new Orders(id, name, userType);
            b.Show();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sells l = new sells(id, name, userType);
            l.Show();
            this.Hide();
        }



       

       

        

        private void button2_Layout(object sender, LayoutEventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);

            da = new SqlDataAdapter("select Count(*) from cars", con);
            //بياخد كوبى من الداتا بتاعتى وهميه فى الرام
            ds = new DataSet();
            // x = اسم الجدول فى الرام الوهميه 
            da.Fill(ds, "x");
            if (ds.Tables["x"].Rows.Count > 0)
            {
                DataRow dr = ds.Tables["x"].Rows[0];
                int xx = Convert.ToInt32(dr.ItemArray.GetValue(0));
                button2.Text = Convert.ToString(xx);

            }
        }

        private void button6_Layout(object sender, LayoutEventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);

            da = new SqlDataAdapter("select Count(id) from orders where accepted=0", con);
            //بياخد كوبى من الداتا بتاعتى وهميه فى الرام
            ds = new DataSet();
            // x = اسم الجدول فى الرام الوهميه 
            da.Fill(ds, "x");
            if (ds.Tables["x"].Rows.Count > 0)
            {
                DataRow dr = ds.Tables["x"].Rows[0];
                int xx = Convert.ToInt32(dr.ItemArray.GetValue(0));
                button6.Text = Convert.ToString(xx);

            }
        }

        private void button7_Layout(object sender, LayoutEventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);

            da = new SqlDataAdapter("select Count(*) from orders where accepted=1", con);
            //بياخد كوبى من الداتا بتاعتى وهميه فى الرام
            ds = new DataSet();
            // x = اسم الجدول فى الرام الوهميه 
            da.Fill(ds, "x");
            if (ds.Tables["x"].Rows.Count > 0)
            {
                DataRow dr = ds.Tables["x"].Rows[0];
                int xx = Convert.ToInt32(dr.ItemArray.GetValue(0));
                button7.Text = Convert.ToString(xx);

            }
        }

     

     

      

       

       
    }
}
