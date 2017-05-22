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
                lbStatus.Text = "Vui lòng nhập vào tên tài khoản";
                lbStatus.Visible = true;
                return;
            }
            if (pass == "") {
                lbStatus.Text = "Vui lòng nhập vào mật khẩu";
                lbStatus.Visible = true;
                return;
            }
            string strSQL = string.Format("SELECT * FROM NHANVIEN " +
                                          "where TENTAIKHOAN = '{0}' and MATKHAU = '{1}'", acc, pass);
            DataTable data = DBHelper.getDataTable(strSQL);
            //int a = 3;
            int a = data.Rows.Count;
            if (a == 0)
            {
                lbStatus.Text = "Sai tên đăng nhập";
                lbStatus.Visible = true;
                return;
            }
            else
            {
                long state = long.Parse(data.Rows[0]["TRANGTHAI"].ToString());
                if (state == 0)
                {
                    lbStatus.Text = "Tài khoản đã bị khóa";
                    lbStatus.Visible = true;
                    return;
                }

                lbStatus.Visible = false;
                this.Hide();
                int role = int.Parse(data.Rows[0]["MABOPHAN"].ToString());
                frmMain fMain = new frmMain();
                fMain.ROLE = role;
                fMain.ShowDialog();
                this.Close();
            }

        }
    }
}
