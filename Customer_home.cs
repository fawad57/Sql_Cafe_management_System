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
    public partial class Customer_home : Form
    {
        int cust1, cust2;
        int bill1, bill2;
        int cust;
        int bill;
        int count;
        int shipper_id;
        int total;
        public Customer_home(int cust1,int cust2, int bill1, int bill2, int shipper_id)
        {
            this.cust1 = cust1;
            this.cust2 = cust2;
            this.bill1 = bill1;
            this.bill2 = bill2;
            cust = 0;
            bill = 0;
            total = 0;
            count = 0;
            InitializeComponent();
            this.shipper_id = shipper_id;
        }

        private void Customer_home_Load(object sender, EventArgs e)
        {
            if (count == 0)
            {
                cust = cust1;
                bill = bill1;
            }
            else if (count == 1)
            {
                cust = cust2;
                bill = bill2;
            }
            Random random = new Random();
            textBox3.Text = cust.ToString();
            textBox1.Text = bill.ToString();
            int randomNumber = random.Next(100, 150);

            itemname.Text = randomNumber.ToString();

            total = randomNumber + bill;
            textBox2.Text = total.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox2.Text != "" && textBox3.Text != "" && itemname.Text != "")
            {
                if (count == 2)
                {
                    MessageBox.Show("All orders have delivered successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Shipper shipper = new Shipper();
                    shipper.Show();
                    this.Hide();
                }




                DateTime date = DateTime.Now.Date;
                TimeSpan time = DateTime.Now.TimeOfDay;

                if (comboBox2.Text == "Cash")
                {
                    string cnstring = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";

                    string query = "insert into cash_payment (amount,date,customer_id) values (@am,@d,@c)";

                    using (SqlConnection con = new SqlConnection(cnstring))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@am", total);
                            cmd.Parameters.AddWithValue("@d", date);
                            cmd.Parameters.AddWithValue("@c", cust);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                else if (comboBox2.Text == "Card")
                {
                    string cnstring = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";

                    string query = "insert into card_payment (amount,date,customer_id) values (@am,@d,@c)";

                    using (SqlConnection con = new SqlConnection(cnstring))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@am", total);
                            cmd.Parameters.AddWithValue("@d", date);
                            cmd.Parameters.AddWithValue("@c", cust);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                else if (comboBox2.Text == "Online")
                {
                    string cnstring = "Data Source=FAWAD_HUMAYUN\\SQLEXPRESS01;Initial Catalog=Project_DB; Integrated Security=True; Encrypt=false";

                    string query = "insert into card_payment (amount,date,customer_id) values (@am,@d,@c)";

                    using (SqlConnection con = new SqlConnection(cnstring))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@am", total);
                            cmd.Parameters.AddWithValue("@d", date);
                            cmd.Parameters.AddWithValue("@c", cust);

                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                MessageBox.Show("Payment payed successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                count++;
            }
            else
            {
                MessageBox.Show("Fill all the fields", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
 
        }
        }
    }
}
