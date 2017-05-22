using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sale_Manage.Admin;

namespace Sale_Manage {
    public partial class frmMain : Form {
        public int ROLE{ get; set; }
        public frmMain() {
            this.StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
        }

        private void mnStaff_Click(object sender, EventArgs e)
        {
            new frmStaff().ShowDialog();
        }

        private void mnCategory_Click(object sender, EventArgs e)
        {
            new frmCategory().ShowDialog();
        }

        private void mnProvider_Click(object sender, EventArgs e)
        {
            new frmProvider().ShowDialog();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmProduct().ShowDialog();
        }

        private void frmMain_Load(object sender, EventArgs e) {
            if (ROLE == 2)
            {
                mnManage.Enabled = false;
            }
        }
    }
}
