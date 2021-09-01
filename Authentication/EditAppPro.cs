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
    public partial class EditAppPro : Form
    {
        public EditAppPro()
        {
            InitializeComponent();
        }
        Application_Profile Ap = new Application_Profile();

        private void EditAppPro_Load(object sender, EventArgs e)
        {

            using (var d = new Entities())
            {
                //labelCode.Text = Ap.labelTruecode.Text;
                var keypoint = d.Applicationsses.Where(o => (o.Application_Code == labelCode.Text)).FirstOrDefault();
                textBoxAppName.Text = keypoint.Application_Name;
                textBoxDes.Text = keypoint.Application_Des;
                textBoxURL.Text = keypoint.Application_URL;
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            using (var d = new Entities())
            {
                var update = d.Applicationsses.Where(o => (o.Application_Code == labelCode.Text)).FirstOrDefault();
                if (update != null)
                {
                    //MessageBox.Show(update.Application_Status);



                    update.Application_Name = textBoxAppName.Text;
                    update.Application_Des = textBoxDes.Text;
                    update.Application_URL = textBoxURL.Text;
                    
                    

                    d.SaveChanges();

                    MessageBox.Show("Edit Success");
                    this.Close();

                }



            }
        }
    }
}
