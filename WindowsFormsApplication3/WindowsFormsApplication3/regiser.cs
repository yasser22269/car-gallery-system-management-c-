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
    public partial class regiser : Form
    {
        public regiser()
        {
            InitializeComponent();
        }

        // @ == معناها ان فى مسار على الهارد
        string constr = @"Data Source=YASSER\YASSER1;Initial Catalog=car;Integrated Security=True";
        SqlDataAdapter da;
        DataSet ds;

        private void button2_Click(object sender, EventArgs e)
        {
            //open Connection
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            if (textBox1.Text != "" && textBox2.Text != "" 
                && textBox3.Text != "" && textBox4.Text != ""
                 && textBox5.Text != "" && textBox6.Text != ""){
                     //SqlCommand بتشتغل مع = insert delete update
                SqlCommand command = new SqlCommand("insert users(name,email,password,city,address,phone) values('" 
                + textBox1.Text +"','"+textBox2.Text + "','"  +textBox4.Text
                + "','" + textBox6.Text + "','" + textBox3.Text + "','" + textBox5.Text + "')", con);

                // Executeالى اتعملها row بيرجع بعدد 
             int i =  command.ExecuteNonQuery();

             if (i > 0)
              {
                    MessageBox.Show("تم التسجيل بنجاح يمكنك التسجيل الان");
                    con.Close();
                   Login l = new Login();
                   l.Show();
                    this.Hide();
                }else
                     MessageBox.Show("هناك مشكلة حاول مرة اخرة فى وقت اخر");
                 
                   
            }
            else
            {
                MessageBox.Show("يجب ملئ جميع البيانات");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Show();
            this.Hide();
        }

      

        
    }
}
