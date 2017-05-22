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
    public partial class frmRegister : Form {
        public frmRegister() {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void btnBack_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string acc = txtAcc.Text.Trim().Replace("-", "");
            string pass = txtPass.Text;
            long bp = long.Parse(cbMod.SelectedValue.ToString());
            if (acc == "")
            {
                MessageBox.Show("Vui lòng nhập vào tên tài khoản");
                return;
            }
            if (pass == "") {
                MessageBox.Show("Vui lòng nhập vào mật khẩu");
                return;
            }
            string strSQL =
                string.Format(
                    "INSERT INTO NHANVIEN " +
                    "(TENNHANVIEN, SODIENTHOAI, EMAIL, " +
                    " DIACHI, MABOPHAN, TRANGTHAI, TENTAIKHOAN, MATKHAU) " +
                    "VALUES('{0}', '{1}', '{2}', '{3}', {4}, {5}, '{6}', '{7}')",
                    acc, "0", "-", "-", bp, 1, acc, pass);

            if (DBHelper.excuteQuery(strSQL))
            {
                MessageBox.Show("Bạn đã đăng ký thành công. Vui lòng đăng nhập.");
                this.Close();
            }
            else
            {
                MessageBox.Show("Không thể đăng kí tài khoản");
            }
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            string strSQL = "SELECT * FROM BOPHAN";
            DataTable table = DBHelper.getDataTable(strSQL);

            cbMod.DataSource = table;
            cbMod.DisplayMember = "TENBOPHAN";
            cbMod.ValueMember = "MABOPHAN";
            
        }
    }
}
