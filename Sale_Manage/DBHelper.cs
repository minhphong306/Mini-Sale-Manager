using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sale_Manage.Model;

namespace Sale_Manage {
    class DBHelper {
        // Attribute
        private static string strImg = System.IO.Directory.GetCurrentDirectory() + "";
        private static string strConnect = "Data Source=DESTRUCTION-VIR;Initial Catalog=banlinhkien;Persist Security Info=True;User ID=saadmin;Password=daicaphong";
        private static SqlConnection conn;

        public static void openConnection() {
            // Tao ket noi
            conn = new SqlConnection(strConnect);

            // Mo ket noi
            if (conn.State != System.Data.ConnectionState.Open) {
                conn.Open();
            }
        }

        public static void closeConnection() {
            conn.Close();
            conn.Dispose();
        }


        public static DataTable getDataTable(string sql) {
            try {
                DataTable table = new DataTable();
                openConnection();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                adapter.Fill(table);
                closeConnection();
                return table;
            }
            catch (Exception ex) {
                System.Windows.Forms.MessageBox.Show("Lỗi ở lấy bảng dữ liệu : " + ex.Message);
                return null;
            }

        }

        // Hàm thực hiện lệnh Insert or Update or Delete
        public static bool excuteQuery(string query) {
            try {
                openConnection();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = conn;
                sqlCommand.CommandText = query;
                sqlCommand.ExecuteNonQuery();
                closeConnection();
                return true;
            }
            catch (Exception ex) {
                System.Windows.Forms.MessageBox.Show("Lỗi ở thực thi câu lệnh sql : " + ex.Message);
                return false;
            }
        }

    }
}
