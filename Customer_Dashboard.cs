using Database_Project;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Customer_Dashboard : Form
    {
        private int customer_id;
        public Customer_Dashboard()
        {
            InitializeComponent();
        }
        public Customer_Dashboard(int cust)
        {
            customer_id = cust;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Place_order place_Order = new Place_order(customer_id);
            place_Order.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Customer_Statistics customer_Statistics = new Customer_Statistics(customer_id);
            customer_Statistics.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Book_table book = new Book_table(customer_id);
            book.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            View_Menu menu = new View_Menu(customer_id);
            menu.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Feedback feedback = new Feedback(customer_id);
            feedback.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
