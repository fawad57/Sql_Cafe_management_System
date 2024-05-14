using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Database_Project
{
    public partial class New_item : Form
    {
        Function fn = new Function();


        public New_item()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cnstring = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";
            if (itemname.Text != "" && itemprice.Text != "" && comboBox2.Text != "")
            {
                String name = itemname.Text;
                int price = int.Parse(itemprice.Text);
                String status = "Available";
                string category = comboBox2.Text;
                int id = 1; 

                string query = "SELECT category_id FROM category WHERE name = @category";

                using (SqlConnection conn = new SqlConnection(cnstring))
                {
                    conn.Open();
                    using (SqlCommand cmd1 = new SqlCommand(query, conn))
                    {
                
                        cmd1.Parameters.AddWithValue("@category", category);

                        SqlDataReader reader = cmd1.ExecuteReader();
                        if (reader.Read())
                        {
                            id = reader.GetInt32(0);
                        }
                        reader.Close();
                    }
                }

   
                string insertQuery = "INSERT INTO food_items (category_id, name, price, status) VALUES (@id, @name, @price, @status)";

                using (SqlConnection con = new SqlConnection(cnstring))
                {
                    con.Open();
                    using (SqlCommand cm = new SqlCommand(insertQuery, con))
                    {
                        // Add parameters to the command
                        cm.Parameters.AddWithValue("@id", id);
                        cm.Parameters.AddWithValue("@name", name);
                        cm.Parameters.AddWithValue("@price", price);
                        cm.Parameters.AddWithValue("@status", status);

                        // Execute the query
                        cm.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Food item is added successfully","Information",MessageBoxButtons.OK);
                Manage_food_items manage_Food_Items = new Manage_food_items();
                manage_Food_Items.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please fill all the fields");
            }

        }


        private void comboBox2_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox2.Items.Clear();
            String con = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";
            using (SqlConnection cn = new SqlConnection(con))
            {
                cn.Open();
                String query = "select * from category_view";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            comboBox2.Items.Add(dr["name"].ToString());
                        }
                    }
                }
            }
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Manage_food_items manage_Food_Items_ = new Manage_food_items();
            manage_Food_Items_.Show();
            this.Hide();
        }
    }
}
