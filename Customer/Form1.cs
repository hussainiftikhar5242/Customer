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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private void customerbutton_Click(object sender, EventArgs e)
        {
            CustomerForm1 customerForm = new CustomerForm1();
            customerForm.Show();
        }

        private void statementbutton_Click(object sender, EventArgs e)
        {
            StatementForm statementForm = new StatementForm();
            statementForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OrderForm orderForm = new OrderForm();
            orderForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CustomerDL.readDataFromFile();
            StatementDL.readDataFromFile();
        }
    }
}
