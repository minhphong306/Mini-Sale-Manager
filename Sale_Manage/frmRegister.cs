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

            // Kiểm tra các trường bỏ trống
            if (acc == "")
            {
                MessageBox.Show("Vui lòng nhập vào tên tài khoản");
                return;
            }
            if (pass == "") {
                MessageBox.Show("Vui lòng nhập vào mật khẩu");
                return;
            }

            // Kiểm tra tên tài khoản, mật khẩu đã tồn tại
            string strSQL1 = string.Format("SELECT * FROM NHANVIEN " +
                                          "where TENTAIKHOAN = '{0}'", acc);
            DataTable data = DBHelper.getDataTable(strSQL1);
            int a = data.Rows.Count;
            if (a > 0)
            {
                MessageBox.Show("Tài khoản đã tồn tại");
                return;
            }

            // Đăng kí tài khoản
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
