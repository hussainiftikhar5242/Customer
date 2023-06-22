using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Customer.BL;
using Customer.DL;

namespace Customer
{
    public partial class CustomerForm : UserControl
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void addbutton_MouseHover(object sender, EventArgs e)
        {
            addbutton.Text = "Add Customer Details";
            addbutton.BackColor = Color.Green;
        }

        private void addbutton_MouseLeave(object sender, EventArgs e)
        {
            addbutton.Text = "Add Customer";
            addbutton.BackColor = Color.Wheat;
        }

        private void addbutton_Click(object sender, EventArgs e)
        {
            if (namebox.Text != "" && addressBox.Text != "" && numberBox.Text != "" && orderBox.Text != "")
            {
                string name = namebox.Text;
                string address = addressBox.Text;
                string number = numberBox.Text;
                string orderId = orderBox.Text;
                DateTime dateTime = dateTimePicker1.Value;

                CustomerBL customer = new CustomerBL(name, address, number, orderId, dateTime);

                MessageBox.Show("Data Added Successfully");

                CustomerDL.list.Add(customer);
                CustomerDL.storeDataIntoFile(customer);
                namebox.Text = "";
                addressBox.Text = "";
                numberBox.Text = "";
                orderBox.Text = "";
            }
        }

        private void showbutton_Click(object sender, EventArgs e)
        {
            AllCustomer customer = new AllCustomer();
            customer.Show();
        }

        private void namebox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void addressBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void numberBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void orderBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
