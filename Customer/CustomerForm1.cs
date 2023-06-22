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
    public partial class CustomerForm1 : Form
    {
        public CustomerForm1()
        {
            InitializeComponent();
        }


        private void addbutton_Click_1(object sender, EventArgs e)
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

        private void showbutton_Click_1(object sender, EventArgs e)
        {
            AllCustomer customer = new AllCustomer();
            customer.Show();
        }

        private void backbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
