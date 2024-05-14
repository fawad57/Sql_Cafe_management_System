using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Database_Project
{
    public partial class Update_Item : Form
    {
        public Update_Item()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Manage_food_items manage_Food_Items = new Manage_food_items();
            manage_Food_Items.Show();
            this.Hide();
        }

        Function fun = new Function();
        private void button1_Click(object sender, EventArgs e)
        {
            string cnstring = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";
            string category = textBox3.Text;
            int id = 1; 

            string query = "SELECT category_id FROM category WHERE name = @category";

            using (SqlConnection conn = new SqlConnection(cnstring))
            {
                conn.Open();
                using (SqlCommand cmd1 = new SqlCommand(query, conn))
                {
                    // Add parameter to the command
                    cmd1.Parameters.AddWithValue("@category", category);

                    SqlDataReader reader = cmd1.ExecuteReader();
                    if (reader.Read())
                    {
                        id = reader.GetInt32(0);
                    }
                    reader.Close();
                }
            }

            MessageBox.Show("Data Update successfully.","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
            query = "update food_items set name='"+textBox1.Text+"',category_id="+id+",price = "+textBox2.Text+" where food_id = "+food_id+"";

            using(SqlConnection conn = new SqlConnection(cnstring))
            {
                conn.Open();
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            load_Data();
        }
        private void load_Data()
        {
            string cnstring = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";

            string query = "SELECT f.name AS item_name, c.name AS category_name, f.price, f.status " +
                           "FROM food_items f " +
                           "JOIN category c ON c.category_id = f.category_id";
            using (SqlConnection con = new SqlConnection(cnstring))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    var reader = cmd.ExecuteReader();
                    DataTable dataTable1 = new DataTable();
                    dataTable1.Load(reader);
                    dataGridView1.DataSource = dataTable1;
                }
            }
        }

        private void Update_Item_Load(object sender, EventArgs e)
        {
            load_Data();
        }
        int food_id;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string f_name = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            string c_name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            int price = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());

            textBox3.Text = c_name;
            textBox2.Text = price.ToString();
            textBox1.Text = f_name;



            string cnstring = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";

            string query = "SELECT food_id FROM food_items WHERE name = @food";

            using (SqlConnection conn = new SqlConnection(cnstring))
            {
                conn.Open();
                using (SqlCommand cmd1 = new SqlCommand(query, conn))
                {
                    // Add parameter to the command
                    cmd1.Parameters.AddWithValue("@food", f_name);

                    SqlDataReader reader = cmd1.ExecuteReader();
                    if (reader.Read())
                    {
                        food_id = reader.GetInt32(0);
                    }
                    reader.Close();
                }
            }


        }
    }
}
