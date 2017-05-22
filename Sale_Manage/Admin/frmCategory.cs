using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sale_Manage.Model;

namespace Sale_Manage.Admin {
    public partial class frmCategory : Form {
        // Attribute
        private List<CategoryModel> categories;
        private DataTable dataTable;
        private int MODE;
        private const int EDIT = 1, ADD = 2, WAIT = 3;
        private string[] strColName = { "id", "name" };
        private string[] strHeader = { "Mã danh mục", "Tên danh mục" };
        private int[] size = { 30, 70 };

        public frmCategory() {
            InitializeComponent();
        }

        private void changeState() {
            switch (MODE) {
                case WAIT:
                    txtCategoryName.Enabled = false;

                    btnAdd.Enabled = true;
                    btnEdit.Enabled = true;
                    btnDelete.Enabled = true;

                    btnOk.Enabled = false;
                    btnCancel.Enabled = false;
                    break;
                case EDIT:
                    txtCategoryName.Enabled = true;

                    btnAdd.Enabled = false;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;

                    btnOk.Enabled = true;
                    btnCancel.Enabled = true;
                    break;
                case ADD:
                    txtCategoryName.Enabled = true;

                    btnAdd.Enabled = false;
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;

                    btnOk.Enabled = true;
                    btnCancel.Enabled = true;
                    break;
            }
        }

        private void btnExit_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e) {
            String name = txtCategoryName.Text;
            long id = long.Parse(txtCategoryCode.Text);
            CategoryModel c = new CategoryModel() {
                ID = id,
                Name = name
            };
            switch (MODE) {
                case EDIT:
                    //DBHelper.updateCategory(c);
                    break;
                case ADD:
                   // DBHelper.insertCategory(c);
                    break;
            }
            frmCategory_Load(null, null);
        }

        private void btnEdit_Click(object sender, EventArgs e) {
            MODE = EDIT;
            changeState();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            MODE = WAIT;
            changeState();
        }
        
        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow dr = dgvData.Rows[e.RowIndex];
                txtCategoryCode.Text = dr.Cells[0].Value.ToString();
                txtCategoryName.Text = dr.Cells[1].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            MODE = ADD;
            changeState();
        }

        private void frmCategory_Load(object sender, EventArgs e) {
            dataTable = new DataTable();
            categories = new List<CategoryModel>();
            MODE = WAIT;
            changeState();

            // Lấy dữ liệu từ CSDL
            string strSQL = "SELECT * FROM DANHMUC";
            dataTable = DBHelper.getDataTable(strSQL);

            // Gán dl bảng vào binding, binding gán vào dgv
            dgvData.DataSource = dataTable;
            
            // Set view for data grid view
            for (int i = 0; i < strHeader.Length; i++) {
                dgvData.Columns[i].Width = (dgvData.Width / 100) * size[i];
                dgvData.Columns[i].HeaderText = strHeader[i];
            }
        }
    }
}
