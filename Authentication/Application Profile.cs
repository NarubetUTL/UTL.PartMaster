using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


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

        //test

        public void Application_Profile_Load(object sender, EventArgs e)
        {
            using (var d = new Entities())
            {
                var AppAll = from Applicationss in d.Applicationsses select new { AppCode = Applicationss.Application_Code, AppName = Applicationss.Application_Name, URL = Applicationss.Application_URL, Description = Applicationss.Application_Des, Status = Applicationss.Application_Status };
                dataGridView1.DataSource = AppAll.ToList();
            }
            //ribbonTabaccess.Pressed=true;
        }

        private void buttonAPPCreate_Click(object sender, EventArgs e)
        {
            CreateAppPro CAP = new CreateAppPro();
            var value=CAP.ShowDialog();
            //MessageBox.Show(value.ToString());
            if (value.ToString() == "Cancel")
            {
                using (var d = new Entities())
                {
                    var AppAll = from Applicationss in d.Applicationsses select new { AppCode = Applicationss.Application_Code, AppName = Applicationss.Application_Name, URL = Applicationss.Application_URL, Description = Applicationss.Application_Des, Status = Applicationss.Application_Status };
                    dataGridView1.DataSource = AppAll.ToList();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            //DataSet ds1 = new DataSet();
            
            //MessageBox.Show(gridMovies.Rows.Count.ToString());
            if (e.RowIndex == -1)
            {
                return;
            }
            if (e.RowIndex == dataGridView1.Rows.Count - 1)
            {
                return;
            }
            else
            {

                dataGridView1.Rows[e.RowIndex].Selected = true;
                //ดึงจาก datatable
                //DataRow dr = ds1.Tables["Product"].Rows[e.RowIndex];
                labelCode.Text = "Code :"+dataGridView1.SelectedCells[0].Value.ToString();
                labelCode.Text +="\n"+"Name :"+ dataGridView1.SelectedCells[1].Value.ToString();
                if (dataGridView1.SelectedCells[2].Value.ToString().Length < 30)
                {
                    labelCode.Text += "\n" + "URL :" + dataGridView1.SelectedCells[2].Value.ToString();

                }
                else
                {


                    string a = dataGridView1.SelectedCells[2].Value.ToString();
                    string newa = a.Substring(0, 30);
                    if (a.Substring(30).Length < 30)
                    {
                        newa += "\n" + a.Substring(30);
                    }
                    else
                    {
                        int la = a.Substring(30).Length / 30;
                        //int last = a.Substring(30).Length % 30;
                        //if(last != 0)
                        //{
                        //    la =la + 1;
                        //}
                        for (int i = 0; i < la; i++)
                        {

                            newa += "\n" + a.Substring(30 * (i + 1), 30);
                            if (a.Substring(30 * (i + 2)).Length < 30 && a.Substring(30*(i+2)).Length !=0)
                            {
                                newa += "\n" + a.Substring(30 * (i + 2));
                            }
                        }
                    }
                    labelCode.Text += "\n" + "URL :" + newa;



                }

                //labelCode.Text += "\n"+"Description :"+ dataGridView1.SelectedCells[3].Value.ToString();
                if (dataGridView1.SelectedCells[3].Value.ToString().Length < 30)
                {
                    labelCode.Text += "\n" + "Description :" + dataGridView1.SelectedCells[3].Value.ToString();

                }
                else
                {


                    string a = dataGridView1.SelectedCells[3].Value.ToString();
                    string newa = a.Substring(0, 30);
                    if (a.Substring(30).Length < 30)
                    {
                        newa+="\n"+a.Substring(30);
                    }
                    else
                    {
                        int la = a.Substring(30).Length / 30;
                        //int last = a.Substring(30).Length % 30;
                        //if(last != 0)
                        //{
                        //    la =la + 1;
                        //}
                        for(int i = 0; i < la; i++)
                        {

                            newa += "\n" + a.Substring(30 * (i + 1),30);
                            if (a.Substring(30 * (i + 2)).Length < 30 && a.Substring(30 * (i + 2)).Length != 0)
                            {
                                newa += "\n" + a.Substring(30 * (i + 2));
                            }
                        }
                    }
                    labelCode.Text += "\n" + "Description :" + newa;
                    


                }


                labelCode.Text +="\n"+"Status :"+ dataGridView1.SelectedCells[4].Value.ToString();
                //MessageBox.Show(dr["Mov_Pic"].ToString());

                //string sql = "SELECT ProductPic FROM Product Where ProductID =" + dr["ProductID"].ToString() + "";
                //if (conn.State != ConnectionState.Open)
                //    conn.Open();

                //command = new SqlCommand(sql, conn);

                //SqlDataReader reader = command.ExecuteReader();
                //reader.Read();

                //if (reader.HasRows)
                //{
                //    if (dr["ProductPic"].ToString() != "")
                //    {

                //        byte[] img = (byte[])(reader[0]);

                //        if (img == null)
                //        {
                //            pictureBox1.Image = null;
                //        }
                //        else
                //        {

                //            MemoryStream ms = new MemoryStream(img);
                //            pictureBox1.Image = Image.FromStream(ms);
                //        }
                //    }


                //}
                //else
                //{
                //    MessageBox.Show("This is does not exits");
                //}
                //conn.Close();


            }

        }
    }
}
