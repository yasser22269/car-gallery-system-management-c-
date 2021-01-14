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
    public partial class Orders : Form
    {
      
         // @ == معناها ان فى مسار على الهارد
        string constr = @"Data Source=YASSER\YASSER1;Initial Catalog=car;Integrated Security=True";
        SqlDataAdapter da;
        DataSet ds;

           public int id, userType;
        public string name;
        public Orders(int id, string name, int userType)
        {
            this.id = id;
            this.userType = userType;
            this.name = name;
          InitializeComponent();
        }
          
         public void clearData() {
             textBox6.Text 
                 = textBox5.Text =
                 textBox1.Text =
                 textBox2.Text =
                 textBox3.Text =
                 textBox4.Text = "";
             checkBox2.Checked = false;
             checkBox1.Checked = false;
        }
        public void views() {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            //And O.user_id in (select id from users) 
            string query = "select O.id,c.name,c.model,c.Brand,c.price,U.name from cars as c,orders as O,users as U where c.id= O.car_id And O.accepted =0 And U.id=O.user_id";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
             //بياخد كوبى من الداتا بتاعتى وهميه فى الرام
               ds = new DataSet();
               // x = اسم الجدول فى الرام الوهميه 
               da.Fill(ds,"x");
               view1.DataSource = ds.Tables["x"];
               
        }


        private void Orders_Load(object sender, EventArgs e)
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
            textBox6.Text = view1.SelectedRows[0].Cells[4].Value.ToString();
            textBox3.Text = view1.SelectedRows[0].Cells[5].Value.ToString();
        }

        

        private void Edit_Click(object sender, EventArgs e)
        {
            //open Connection
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            if (textBox5.Text != "" && checkBox1.Checked && checkBox2.Checked == false)
            {
                //SqlCommand بتشتغل مع = insert delete update
                string query = "update orders SET accepted=1 where id='" + textBox5.Text + "';";
                // update cars SET buyed=1 where id =(select car_id from orders where id =" + textBox5.Text + ");
                SqlCommand command = new SqlCommand(query, con);

                // Executeالى اتعملها row بيرجع بعدد 
                int i = command.ExecuteNonQuery();

                if (i > 0)
                {
                    MessageBox.Show("تم التحديث بنجاح");
                  //  string query2 = "update cars SET buyed=1 where id(select car_id from orders);";
                    //SqlCommand command2 = new SqlCommand(query2, con);


                    clearData();
                    views();
                }
                else
                    MessageBox.Show("هناك مشكلة حاول مرة اخرة فى وقت اخر");
            }
            else if (textBox5.Text != "" && checkBox2.Checked && checkBox1.Checked == false)
            {
                //SqlCommand بتشتغل مع = insert delete update
                string query = "update orders SET accepted=2 where id='" + textBox5.Text + "';";

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
                MessageBox.Show("يجب ملئ جميع البيانات بطريقة صحيحه");
            }
        }

        private void ClearB_Click(object sender, EventArgs e)
        {
            clearData();

        }

    }
}
