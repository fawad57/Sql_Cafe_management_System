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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            Promotions promotions = new Promotions();
            promotions.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_Staff add_Staff = new Add_Staff();
            add_Staff.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Manage_food_items manage_Food_Items = new Manage_food_items();
            manage_Food_Items.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cafe_statistics check_Details = new Cafe_statistics();
            check_Details.Show();
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
