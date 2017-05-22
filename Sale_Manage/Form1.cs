using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sale_Manage {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void llbRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            this.Hide();
            frmRegister fRegister = new frmRegister();
            fRegister.ShowDialog();
            this.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e) {
            string acc = txtAcc.Text.Trim().Replace("-", "");
            string pass = txtPass.Text;
           
            if (acc == "") {
                MessageBox.Show("Vui lòng nhập vào tên tài khoản");
                return;
            }
            if (pass == "") {
                MessageBox.Show("Vui lòng nhập vào mật khẩu");
                return;
            }
            string strSQL = string.Format("SELECT * FROM NHANVIEN " +
                                          "where TENTAIKHOAN = '{0}' and MATKHAU = '{1}'", acc, pass);
            DataTable data = DBHelper.getDataTable(strSQL);
            //int a = 3;
            int a = data.Rows.Count;
            if (a == 0)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng");
                return;
            }
            else
            {
                this.Hide();
                frmMain fMain = new frmMain();
                fMain.ShowDialog();
                this.Close();
            }

            
        }
    }
}
