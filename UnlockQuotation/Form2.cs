using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UnlockQuotation
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            string username = "admin";
            string password = "Akkhie06";

            if( txtUser.Text == username && txtPassword.Text == password)
            {
                this.Hide();
                Form1 form1 = new Form1();
                form1.ShowDialog();

                this.Close();
            }
            else
            {
                MessageBox.Show("กรุณาตรวจสอบ User และ Password","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUser.Text = "";
                txtPassword.Text = "";
            }

            test
        }
    }
}
