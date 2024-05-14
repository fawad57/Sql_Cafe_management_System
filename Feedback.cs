using Project;
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
    public partial class Feedback : Form
    {
        private int customer_id;
        public Feedback(int customer_id)
        {
            InitializeComponent();
            this.customer_id = customer_id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Submit_Feedback submit_Feedback = new Submit_Feedback(customer_id);
            submit_Feedback.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer_Dashboard customer_Dashboard = new Customer_Dashboard(customer_id);
            customer_Dashboard.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Check_Feedback check_Feedback = new Check_Feedback(customer_id);
            check_Feedback.Show();
            this.Hide();
        }
    }
}
