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
    public partial class CreateAppPro : Form
    {
        public CreateAppPro()
        {
            InitializeComponent();
        }
        //com
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                using (var d = new Entities())
                {
                    Applicationss AppIn = new Applicationss();

                     
                    AppIn.Application_Name = textBoxAppName.Text;
                    AppIn.Application_Code = textBoxAppCode.Text;
                    AppIn.Application_URL = textBoxURL.Text;
                    AppIn.Application_Des = textBoxDes.Text;
                    AppIn.Application_Status = "Active";
                    d.Applicationsses.Add(AppIn);
                    
                    d.SaveChanges();
                    MessageBox.Show("Create Success");
                    //var AppAll = from Applicationss in d.Applicationsses select new { AppCode = Applicationss.Application_Code, AppName = Applicationss.Application_Name, URL = Applicationss.Application_URL, Description = Applicationss.Application_Des, Status = Applicationss.Application_Status };
                    //Application_Profile AP = new Application_Profile();
                    //App.dataGridView1.DataSource = AppAll;

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
