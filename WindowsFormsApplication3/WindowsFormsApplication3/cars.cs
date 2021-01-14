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
    public partial class cars : Form
    {
        // @ == معناها ان فى مسار على الهارد
        string constr = @"Data Source=YASSER\YASSER1;Initial Catalog=car;Integrated Security=True";
        SqlDataAdapter da;
        DataSet ds;

           public int id, userType;
        public string name;
        public cars(int id,string name,int userType)
        {
            this.id = id;
            this.userType = userType;
            this.name = name;
          InitializeComponent();
        }
          
         public void clearData() {
             textBox5.Text = textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
        }
        public void views() {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "select * from cars";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
             //بياخد كوبى من الداتا بتاعتى وهميه فى الرام
               ds = new DataSet();
               // x = اسم الجدول فى الرام الوهميه 
               da.Fill(ds,"x");
               view1.DataSource = ds.Tables["x"];
               
        }
        
        private void ADD_Click(object sender, EventArgs e)
        {
            //open Connection
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            if (textBox1.Text != "" && textBox2.Text != ""
                && textBox3.Text != "" && textBox4.Text != "")
            {


                int price;
                bool isNumeric = int.TryParse(textBox3.Text, out price);
                if (isNumeric)
                {
                //SqlCommand بتشتغل مع = insert delete update
                SqlCommand command = new SqlCommand("insert cars(name,model,Brand,price) values('"
               + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text
                + "','" + price + "')", con);

                // Executeالى اتعملها row بيرجع بعدد 
                int i = command.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("تم الحفظ بنجاح");
                   clearData();
                   views();
               }
                else
                    MessageBox.Show("هناك مشكلة حاول مرة اخرة فى وقت اخر");
                }
                else
                {
                    MessageBox.Show(" يرجى ادخال السعر رقم");
                }
            }
            else
            {
                MessageBox.Show("يجب ملئ جميع البيانات");
            }
        }

        private void cars_Load(object sender, EventArgs e)
        {
            views(); // فانكشن بتاعتها فوق
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Main m = new Main(id,name,userType);
            m.Show();
            this.Hide();
        }

        private void view1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = view1.SelectedRows[0].Cells[0].Value.ToString();
            textBox1.Text = view1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = view1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = view1.SelectedRows[0].Cells[3].Value.ToString();
            textBox3.Text = view1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            //open Connection
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            if (textBox5.Text != "")
            {
                //SqlCommand بتشتغل مع = insert delete update
                string query ="delete from cars where id="+textBox5.Text+";";
                SqlCommand command = new SqlCommand(query, con);

                // Executeالى اتعملها row بيرجع بعدد 
                int i = command.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("تم الحذف بنجاح");
                    clearData();
                    views();
                }
                else
                    MessageBox.Show("هناك مشكلة حاول مرة اخرة فى وقت اخر");
            }
            else
            {
                MessageBox.Show("حتى الحذف id يجب وجود ");
            }
        }

        private void ClearB_Click(object sender, EventArgs e)
        {
            clearData();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            //open Connection
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            if (textBox1.Text != "" && textBox2.Text != ""
                && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                int price;
                bool isNumeric = int.TryParse(textBox3.Text, out price);
                if (isNumeric)
                {
                //SqlCommand بتشتغل مع = insert delete update
           string query = "update cars SET name='"+ textBox1.Text +
               "',model='" + textBox2.Text +
               "',Brand='" + textBox4.Text +
               "',price='" + price +
               "' where id='" + textBox5.Text + "';";
               
                SqlCommand command = new SqlCommand(query, con);

                // Executeالى اتعملها row بيرجع بعدد 
                int i = command.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("تم التحديث بنجاح");
                    clearData();
                    views();
                }
                else
                    MessageBox.Show("هناك مشكلة حاول مرة اخرة فى وقت اخر");
            }
            else
            {
                MessageBox.Show(" يرجى ادخال السعر رقم");
            }
            }
            else
            {
                MessageBox.Show("يجب ملئ جميع البيانات");
            }
        }

        
    }
}
