using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_Project
{
    public partial class Order_payment : Form
    {
        private int customer_id;
        private int bill;
        private int staff_id;
        public Order_payment(int customer_id, int bill, int staff_id)
        {
            InitializeComponent();
            this.customer_id = customer_id;
            this.bill = bill;
            this.staff_id = staff_id;
        }

        private void Order_payment_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cash_payment cash_Payment = new Cash_payment(customer_id,bill,staff_id);
            cash_Payment.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Card_Payment card_Payment = new Card_Payment(customer_id, bill, staff_id);
            card_Payment.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Online_Payment online_Payment = new Online_Payment(customer_id,bill,staff_id);
            online_Payment.Show();
            this.Hide();
        }
    }
}
