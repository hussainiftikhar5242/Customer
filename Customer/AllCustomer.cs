using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Customer.DL;
using Customer.BL;

namespace Customer
{
    public partial class AllCustomer : Form
    {
        public AllCustomer()
        {
            InitializeComponent();
        }

        private void AllCustomer_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = true;

            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Address", "Address");
            dataGridView1.Columns.Add("Phone", "Phone");
            dataGridView1.Columns.Add("Order ID", "Order ID");
            dataGridView1.Columns.Add("date And Time", "Date and Time");

            foreach (CustomerBL temp in CustomerDL.list)
            {
                dataGridView1.Rows.Add(temp.name, temp.address, temp.phoneNumber, temp.orderId, temp.dateTime);
            }
        }

        private void backbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
