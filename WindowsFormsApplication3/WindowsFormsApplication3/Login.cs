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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        // @ == معناها ان فى مسار على الهارد
       string constr = @"Data Source=YASSER\YASSER1;Initial Catalog=car;Integrated Security=True";
       SqlDataAdapter da;
       DataSet ds;
       private void button1_Click(object sender, EventArgs e)
       {    
           //open Connection
           SqlConnection con = new SqlConnection(constr);

           da = new SqlDataAdapter("select * from users where email='"+textBox1.Text +
           "'and password='" + textBox2.Text + "'", con);
           //بياخد كوبى من الداتا بتاعتى وهميه فى الرام
           ds = new DataSet();
           // x = اسم الجدول فى الرام الوهميه 
           da.Fill(ds,"x");
           if (ds.Tables["x"].Rows.Count > 0)
           {
               MessageBox.Show("تم التسجيل بنجاح");
               DataRow dr = ds.Tables["x"].Rows[0];
               Main m = new Main(Convert.ToInt32(dr.ItemArray.GetValue(0)), Convert.ToString(dr.ItemArray.GetValue(1)), Convert.ToInt32(dr.ItemArray.GetValue(6)));
               m.Show();
               this.Hide();
           }
           else
           {
               MessageBox.Show("Invaild user Or Password");
           }
       }

       private void button2_Click(object sender, EventArgs e)
       {
           regiser r = new regiser();
           r.Show();
           this.Hide();
       }

   
    }
}
