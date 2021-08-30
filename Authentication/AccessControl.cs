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
    public partial class AccessControl : Form
    {
        public AccessControl()
        {
            InitializeComponent();
            //this.IsMdiContainer=true;
        }
        PartMaster PM = new PartMaster();
        Application_Profile AP = new Application_Profile();

        //MainMDI MD = new MainMDI();


        private void ribbonButtonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public event EventHandler ACButtonClicked;
        protected virtual void ACCButtonClicked(EventArgs e)
        {
            ACButtonClicked.Invoke(this, e);
        }
        public void panelAccess_Click(object sender, EventArgs e)
        {
            //var MD = new MainMDI();

            //AP.MdiParent = MD;
            //OnCloseButtonClicked(e);
            //AP.Show();
            //MD.buttonAC_Click(sender, e);
            ACCButtonClicked(e);

        }

        private void panelExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }



        public event EventHandler PMButtonClicked;
        protected virtual void PMMButtonClicked(EventArgs e)
        {
            PMButtonClicked.Invoke(this, e);
        }
        private void panelConvert_Click(object sender, EventArgs e)
        {
            PMMButtonClicked(e);

        }
        //public event EventHandler CloseButtonClicked;
        //protected virtual void OnCloseButtonClicked(EventArgs e)
        //{
        //    CloseButtonClicked.Invoke(this, e);
        //}

    }
}
