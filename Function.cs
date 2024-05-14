using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Project
{
    internal class Function
    {
        public SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";
            return conn;
        }
        public DataSet getData(String guery)
        {
             SqlConnection con = GetConnection();
            SqlCommand cmd = con.CreateCommand();
            cmd.Connection = con;
            cmd.CommandText = guery;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet data = new DataSet();
            adapter.Fill(data);
            return data;
        }

        public void setData(String query)
        {
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Data processed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
