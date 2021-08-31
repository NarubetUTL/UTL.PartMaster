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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void buttonCloser_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public bool stat;
        PartMaster MM = new PartMaster();
        public string UserP;
        public string RoleP;

        

       

        

        private void buttonLogin_Click_1(object sender, EventArgs e)
        {

            using (var d = new Entities())
            {
                //var Usern = d.UserAuthentications.Where(it => it.UserAuthen_Name == textBoxUsername.Text).Select(its => its.UserAuthen_Name);
                //var Passn = d.UserAuthentications.Where(it => it.UserAuthen_Name == textBoxUsername.Text).Select(its => its.UserAuthen_Password);

                var Usern = from User in d.UserAuthentications where User.UserAuthen_Name == textBoxUsername.Text select User.UserAuthen_Name;
                var Passn = from User in d.UserAuthentications where User.UserAuthen_Name == textBoxUsername.Text select User.UserAuthen_Password;

                //textBoxPassword.Text = "1" + Usern.FirstOrDefault() + "2";
                if (Usern.FirstOrDefault() != null)
                {
                    if (textBoxPassword.Text == Passn.FirstOrDefault())
                    {
                        UserP = Usern.FirstOrDefault();
                        //RoleP  = ;
                        PartMaster m = new PartMaster();

                        //m.labelUser.Text = UserP;
                        //m.labelRole.Text = (from User in d.UserAuthentications where User.UserAuthen_Name == textBoxUsername.Text select User.Role.Role_Name).FirstOrDefault();//chagne the algorithm for new database
                        m.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Password");
                        textBoxUsername.Text = "";
                        textBoxPassword.Text = "";

                    }
                }
                else
                {
                    MessageBox.Show("Invalid Username");
                    textBoxUsername.Text = "";
                    textBoxPassword.Text = "";
                }
            }
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

        }
    }
}
