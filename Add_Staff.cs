using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Database_Project
{
    public partial class Add_Staff : Form
    {
        public Add_Staff()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            comboBox1.Items.Clear();
            String con = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";
            using (SqlConnection cn = new SqlConnection(con))
            {
                cn.Open();
                String query = "select name from Staff_Roll";
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

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox5.Text != "")
            {
                string f_name = textBox1.Text;
                string l_name = textBox2.Text;
                string email = textBox3.Text;
                string phone_no = textBox5.Text;
                string roll = comboBox1.Text;

                int roll_id = 0;

                string cnstring = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";
                string query = "select roll_id from staff_roll where name =@name";
                using (SqlConnection conn = new SqlConnection(cnstring))
                {
                    conn.Open();
                    using (SqlCommand cmd2 = new SqlCommand(query, conn))
                    {
                        cmd2.Parameters.AddWithValue("@name", roll);
                        SqlDataReader reader = cmd2.ExecuteReader();
                        if (reader.Read())
                        {
                            roll_id = reader.GetInt32(0);
                        }
                        reader.Close();
                    }
                }

                query = "insert into staff (f_name,l_name,email,roll_id) values (@fname,@lname,@email,@roll)";

                using (SqlConnection sqlConnection = new SqlConnection(cnstring))
                {
                    sqlConnection.Open();
                    using (SqlCommand cmd2 = new SqlCommand(query, sqlConnection))
                    {
                        cmd2.Parameters.AddWithValue("@fname", f_name);
                        cmd2.Parameters.AddWithValue("@lname", l_name);
                        cmd2.Parameters.AddWithValue("@email", email);
                        cmd2.Parameters.AddWithValue("@roll", roll_id);

                        cmd2.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("New Staff member has been added successfully","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                this.Hide();

            }

            else
            {
                MessageBox.Show("Please fill all the fields","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }
    }
}
