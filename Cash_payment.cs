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
    public partial class Cash_payment : Form
    {
        private int customer_id;
        private int bill;
        private int staff_id;
        public Cash_payment(int customer_id, int bill, int staff_id)
        {
            InitializeComponent();
            this.customer_id = customer_id;
            this.bill = bill;
            this.staff_id = staff_id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Order_payment order_Payment = new Order_payment(customer_id,bill,staff_id);
            order_Payment.Show();
            this.Hide();

        }

        private void Cash_payment_Load(object sender, EventArgs e)
        {
            textBox3.Text=customer_id.ToString();
            textBox2.Text=bill.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox2.Text!=""&& textBox3.Text != "")
            {
                DateTime dateTime = DateTime.Now.Date;
                string cnstring = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";
                string query = "insert into cash_payment (amount,date,customer_id) values (@a,@d,@c)";

                using (SqlConnection con = new SqlConnection(cnstring))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@a", bill);
                        cmd.Parameters.AddWithValue("@d", dateTime);
                        cmd.Parameters.AddWithValue("@c", customer_id);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Payment paid successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Staff_dashboard staff_Dashboard = new Staff_dashboard(staff_id);
                staff_Dashboard.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Please fill all the fields.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
