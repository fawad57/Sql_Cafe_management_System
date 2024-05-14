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

namespace Database_Project
{
    public partial class Promotions : Form
    {
        public Promotions()
        {
            InitializeComponent();
        }

        private void comboBox3_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox3.Items.Clear();
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
                            comboBox3.Items.Add(dr["name"].ToString());
                        }
                    }
                }
            }
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox1.Items.Clear();
            String con = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";
            using (SqlConnection cn = new SqlConnection(con))
            {
                cn.Open();
                String query = "select name from food_items where category_id  =(select category_id from category where name = '" + comboBox3.Text + "')";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            comboBox1.Items.Add(dr["name"].ToString());
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox2.Text != "") 
            {
                string name = textBox1.Text;
                string description = textBox2.Text;
                string type = comboBox2.Text;
                string value = textBox3.Text;
                string s_date = textBox4.Text;
                string e_date = textBox5.Text;

                String con = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";

                string query = "insert into promotions (name,description,start_date,end_date,discount_type,discount_value) values (@n,@d,@sd,@ed,@dt,@dv)";

                using (SqlConnection cn = new SqlConnection(con))
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@n", name);
                        cmd.Parameters.AddWithValue("@d", description);
                        cmd.Parameters.AddWithValue("@sd", s_date);
                        cmd.Parameters.AddWithValue("@ed", e_date);
                        cmd.Parameters.AddWithValue("@dt", type);
                        cmd.Parameters.AddWithValue("@dv", value);

                        cmd.ExecuteNonQuery();
                    }
                }

                string f_name = comboBox1.Text;
                int f_id = 0;

                query = "select food_id from food_items where name =@food";
                using (SqlConnection conn = new SqlConnection(con))
                {
                    conn.Open();
                    using (SqlCommand cmd2 = new SqlCommand(query, conn))
                    {
                        cmd2.Parameters.AddWithValue("@food", f_name);
                        SqlDataReader reader = cmd2.ExecuteReader();
                        if (reader.Read())
                        {
                            f_id = reader.GetInt32(0);
                        }
                        reader.Close();
                    }
                }

                int pro_id = 0;

                query = "select Max(promotion_id) from promotions";

                using(SqlConnection conn = new SqlConnection(con))
                {
                    conn.Open();
                    using(SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            pro_id = reader.GetInt32(0);
                        }
                    }
                }

                query = "insert into food_promotions (promotion_id,food_id) values ("+pro_id+","+f_id+")";

                using( SqlConnection conn = new SqlConnection(con))
                {
                    conn.Open() ;
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Promotion is created successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Please fill all the field.","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }
    }
}
