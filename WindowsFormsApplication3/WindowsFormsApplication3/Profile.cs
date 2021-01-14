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
    public partial class Profile : Form
    {
        public int id, userType;
        public string name;
        public Profile(int id, string name, int userType)
        {
            this.id = id;
            this.userType = userType;
            this.name = name;
            InitializeComponent();
            textBox1.Text = name;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // @ == معناها ان فى مسار على الهارد
        string constr = @"Data Source=YASSER\YASSER1;Initial Catalog=car;Integrated Security=True";
        SqlDataAdapter da;
        DataSet ds;
        private void button2_Click(object sender, EventArgs e)
        {
            Main m = new Main(id, textBox1.Text, userType);
            m.Show();
            this.Hide();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            //open Connection
            SqlConnection con = new SqlConnection(constr);

            da = new SqlDataAdapter("select * from users where id='" + id + "'", con);
              //بياخد كوبى من الداتا بتاعتى وهميه فى الرام
           ds = new DataSet();
           // x = اسم الجدول فى الرام الوهميه 
           da.Fill(ds,"x");
           if (ds.Tables["x"].Rows.Count > 0)
           {
               DataRow dr = ds.Tables["x"].Rows[0];

               textBox1.Text = Convert.ToString(dr.ItemArray.GetValue(1));
               textBox2.Text = Convert.ToString(dr.ItemArray.GetValue(2));
               textBox4.Text = Convert.ToString(dr.ItemArray.GetValue(3));
               textBox6.Text = Convert.ToString(dr.ItemArray.GetValue(4));
               textBox3.Text = Convert.ToString(dr.ItemArray.GetValue(5));
               textBox5.Text = Convert.ToString(dr.ItemArray.GetValue(7));
           }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //open Connection
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            if (textBox1.Text != "" && textBox2.Text != ""
                && textBox3.Text != "" && textBox4.Text != ""
                 && textBox5.Text != "" && textBox6.Text != "")
            {
                    string query = "update users SET name='"+ textBox1.Text +
               "',email='" + textBox2.Text +
               "',password='" + textBox4.Text +
               "',city='" + textBox6.Text +
               "',address='" + textBox3.Text +
               "',phone='" + textBox5.Text +
               "' where id='" + id + "';";

                SqlCommand command =
                  new SqlCommand(query, con);

                // Executeالى اتعملها row بيرجع بعدد 
                int i = command.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("تم التعديل بنجاح");
                    Main l = new Main(id, textBox1.Text, userType);
                    l.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("هناك مشكلة حاول مرة اخرة فى وقت اخر");


            }
            else
            {
                MessageBox.Show("يجب ملئ جميع البيانات");
            }
        }
    }
}
