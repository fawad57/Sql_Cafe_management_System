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
    public partial class Staff_dashboard : Form
    {
        private int staff_id;
        public Staff_dashboard()
        {
            InitializeComponent();
        }
        public Staff_dashboard(int id)
        {
            staff_id = id;
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Manage_food_items manage_Food_Items = new Manage_food_items(staff_id);
            manage_Food_Items.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Take_order take_Order = new Take_order(staff_id);
            take_Order.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Staff_statistics staff_Statistics = new Staff_statistics(staff_id);
            staff_Statistics.Show();
            this.Hide();
        }
    }
}
