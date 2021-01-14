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
    public partial class sells : Form
    {
       
          // @ == معناها ان فى مسار على الهارد
        string constr = @"Data Source=YASSER\YASSER1;Initial Catalog=car;Integrated Security=True";
        SqlDataAdapter da;
        DataSet ds;

           public int id, userType;
        public string name;
        public sells(int id, string name, int userType)
        {
            this.id = id;
            this.userType = userType;
            this.name = name;
          InitializeComponent();
        }
        public void views()
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            //And O.user_id in (select id from users) 
            string query = "select O.id,c.name,c.model,c.Brand,c.price,U.name from cars as c,orders as O,users as U where c.id= O.car_id And O.accepted =1 And U.id=O.user_id";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            //بياخد كوبى من الداتا بتاعتى وهميه فى الرام
            ds = new DataSet();
            // x = اسم الجدول فى الرام الوهميه 
            da.Fill(ds, "x");
            view1.DataSource = ds.Tables["x"];

        }



        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Main m = new Main(id, name, userType);
            m.Show();
            this.Hide();
        }

        private void sells_Load(object sender, EventArgs e)
        {
            views(); // فانكشن بتاعتها فوق

        }

        private void view1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}
