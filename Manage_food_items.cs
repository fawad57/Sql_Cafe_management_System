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
    public partial class Manage_food_items : Form
    {
        private int staff_id;
        public Manage_food_items()
        {
            InitializeComponent();
        }
        public Manage_food_items(int staff_id)
        {
            InitializeComponent();
            this.staff_id = staff_id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            New_item new_Item = new New_item();
            new_Item.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Update_Item update_Item = new Update_Item();
            update_Item.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Check_item check_Item = new Check_item();
            check_Item.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (staff_id != 0)
            {
                Staff_dashboard staff_Dashboard = new Staff_dashboard(staff_id);
                staff_Dashboard.Show();
                this.Hide();
            }
            else
            {
                Dashboard dashboard = new Dashboard();
                dashboard.Show();
                this.Hide();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Remove remove = new Remove();
            remove.Show();
            this.Hide();
        }
    }
}
