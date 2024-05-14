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
    public partial class Shipper : Form
    {
        int shipperID;
        int cart_id;
        int customer_id;
        int bill;
        int count;

        int cust1,bill1,cust2,bill2;
        public Shipper()
        {
            InitializeComponent();
        }
        public Shipper(int shipperID)
        {
            InitializeComponent();
            cart_id = 0;
            customer_id = 0;
            bill = 0;
            count = 0;
            this.shipperID = shipperID;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer_home customer_Home = new Customer_home(cust1,cust2,bill1,bill2,shipperID);
            customer_Home.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void load_data()
        {
            string cnstring = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";

            DataTable dataTable = new DataTable();

            string query = "select cart_id,ct.customer_id,c.f_name,c.L_name,total_bill  From cart ct join customers c on c.customer_id=ct.customer_id where delivery_id is null";

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

        private void Shipper_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (count == 2)
            {
                MessageBox.Show("You get your maximum orders.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (dataGridView1.SelectedRows.Count == 0) 
            {
                MessageBox.Show("Please select any row first.","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                string cnstring = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";
                string query = "insert into delivery (cart_id,shipper_id,date) values (@cart,@shipper,@date)";

                DateTime dateTime = DateTime.Now.Date;

                using (SqlConnection con = new SqlConnection(cnstring))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@cart", cart_id);
                        cmd.Parameters.AddWithValue("@shipper", shipperID);
                        cmd.Parameters.AddWithValue("@date", dateTime);

                        cmd.ExecuteNonQuery();
                    }

                }

                query = "select max(delivery_id) from delivery";
                int id = 0;
                using (SqlConnection con = new SqlConnection(cnstring))
                {
                    con.Open() ;
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            id = reader.GetInt32(0);
                        }
                        reader.Close();
                    }
                    
                }

                query = " update cart set delivery_id = " + id + "where cart_id=" + cart_id + "";

                using (SqlConnection con = new SqlConnection(cnstring))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery ();
                }

                if(count == 0)
                {
                    cust1 = customer_id;
                    bill1 = bill;
                    count++;
                }
                else if (count == 1)
                {
                    cust2 = customer_id;
                    bill2 = bill;
                    count++;
                }

                MessageBox.Show("Delivery is Added.","Information",MessageBoxButtons.OK,MessageBoxIcon.Information );
                load_data();
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cart_id = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            customer_id = (int)dataGridView1.Rows[e.RowIndex].Cells[1].Value;
            bill = (int)dataGridView1.Rows[e.RowIndex].Cells[4].Value;

  
        }

    }
}
