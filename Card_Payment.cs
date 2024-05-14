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
    public partial class Card_Payment : Form
    {
        private int customer_id;
        private int bill;
        private int staff_id;
        public Card_Payment(int c,int b, int s)
        {
            InitializeComponent();
            customer_id = c;
            bill = b;
            staff_id = s;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!=""&& textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                string no = textBox5.Text;
                string type = textBox4.Text;
                string exp = textBox1.Text;
                DateTime dateTime = DateTime.Now.Date;
                DateTime dateTime1 = DateTime.Now.ToLocalTime();

                string cnstring = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";
                string query = "insert into card_payment (amount,date,customer_id,card_no,card_type,expiry_date) values (@a,@d,@c,@cn,@ct,@e)";

                using (SqlConnection con = new SqlConnection(cnstring))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@a", bill);
                        cmd.Parameters.AddWithValue("@d", dateTime);
                        cmd.Parameters.AddWithValue("@c", customer_id);
                        cmd.Parameters.AddWithValue("@cn", no);
                        cmd.Parameters.AddWithValue("@ct", type);
                        cmd.Parameters.AddWithValue("@e", exp);
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

        private void Card_Payment_Load(object sender, EventArgs e)
        {
            textBox3.Text = customer_id.ToString();
            textBox2.Text = bill.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Order_payment order_Payment = new Order_payment(customer_id, bill, staff_id);
            order_Payment.Show();
            this.Hide();
        }
    }
}
