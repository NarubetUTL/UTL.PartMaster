using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Authentication
{
    public partial class Application_Profile : Form
    {
        public Application_Profile()
        {
            InitializeComponent();
        }
        

        private void Application_Profile_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        

        public void Application_Profile_Load(object sender, EventArgs e)
        {
            var d = new DataLinQDataContext();
            var AppAll = from Applicationss in d.Applicationsses  select new { AppCode=Applicationss.Application_Code,AppName=Applicationss.Application_Name,URL=Applicationss.Application_URL,Description=Applicationss.Application_Des,Status=Applicationss.Application_Status } ;
            dataGridView1.DataSource = AppAll;

            //ribbonTabaccess.Pressed=true;
        }

        private void buttonAPPCreate_Click(object sender, EventArgs e)
        {
            CreateAppPro CAP = new CreateAppPro();
            var value=CAP.ShowDialog();
            //MessageBox.Show(value.ToString());
            if (value.ToString() == "Cancel")
            {
                var d = new DataLinQDataContext();
                var AppAll = from Applicationss in d.Applicationsses select new { AppCode = Applicationss.Application_Code, AppName = Applicationss.Application_Name, URL = Applicationss.Application_URL, Description = Applicationss.Application_Des, Status = Applicationss.Application_Status };
                dataGridView1.DataSource = AppAll;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataSet ds1 = new DataSet();
            ////MessageBox.Show(gridMovies.Rows.Count.ToString());
            //if (e.RowIndex == -1)
            //{
            //    return;
            //}
            //if (e.RowIndex == dataGridView1.Rows.Count - 1)
            //{
            //    return;
            //}
            //else
            //{
            //    dataGridView1.Rows[e.RowIndex].Selected = true;
            //    //ดึงจาก datatable
            //    DataRow dr = ds1.Tables["Product"].Rows[e.RowIndex];
            //    labelCode.Text = dr["ProductID"].ToString();
            //    textBoxName.Text = dr["ProductName"].ToString();
            //    textBoxPrice.Text = dr["ProductPrice"].ToString();

            //    textCost.Text = dr["ProductCost"].ToString();



            //    textBoxLong.Text = dr["ProductDet"].ToString();
            //    textBoxInsurance.Text = dr["ProductInsurance"].ToString();
            //    //MessageBox.Show(dr["Mov_Pic"].ToString());

            //    string sql = "SELECT ProductPic FROM Product Where ProductID =" + dr["ProductID"].ToString() + "";
            //    if (conn.State != ConnectionState.Open)
            //        conn.Open();

            //    command = new SqlCommand(sql, conn);

            //    SqlDataReader reader = command.ExecuteReader();
            //    reader.Read();

            //    if (reader.HasRows)
            //    {
            //        if (dr["ProductPic"].ToString() != "")
            //        {

            //            byte[] img = (byte[])(reader[0]);

            //            if (img == null)
            //            {
            //                pictureBox1.Image = null;
            //            }
            //            else
            //            {

            //                MemoryStream ms = new MemoryStream(img);
            //                pictureBox1.Image = Image.FromStream(ms);
            //            }
            //        }


            //    }
            //    else
            //    {
            //        MessageBox.Show("This is does not exits");
            //    }
            //    conn.Close();


            //}

        }
    }
}
