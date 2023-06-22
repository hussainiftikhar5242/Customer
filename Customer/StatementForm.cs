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
    public partial class StatementForm : Form
    {
        public StatementForm()
        {
            InitializeComponent();
            CustomerDL.list.Clear();
            namecomboBox.Items.Clear();
            CustomerDL.readDataFromFile();
            for (int i = 0; i < CustomerDL.list.Count; i++)
            {
                namecomboBox.Items.Add(CustomerDL.list[i].name);
            }
        }


        private float totalMbBill(float mb)
        {
            float mbBill = 0f;
            if (mb < 500)
            {
                mbBill = 0;
            }
            else
            {
                float temp = mb - 500;
                temp = temp * 50;
                mbBill = temp;
            }
            return mbBill;

        }

        private float totalTextBill(float text)
        {
            float textBill = 0f;
            if (text < 500)
            {
                textBill = 0;
            }
            else
            {
                float temp = text - 500;
                temp = temp * 10;
                textBill = temp;
            }
            return textBill;

        }


        private float totalMinsBill(float mins)
        {
            float minsBill = 0f;
            if (mins < 500)
            {
                minsBill = 0;
            }
            else
            {
                float temp = mins - 500;
                temp = temp * 20;
                minsBill = temp;
            }
            return minsBill;

        }

       

        private void addbutton_Click_1(object sender, EventArgs e)
        {
            float text = 0;
            float mins = 0;
            float minsBill = 0f;
            float mb = 0;
            bool billtextChecker = false;
            bool mintChecker = false;
            bool mbchecker = false;
            float mbBill = 0f;
            float textbill = 0f;
            try
            {
                text = float.Parse(textBox.Text);
                billtextChecker = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                billtextChecker = false;
            }
            try
            {
                mins = float.Parse(minttextBox.Text);
                mintChecker = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                mintChecker = false;
            }
            try
            {
                mb = float.Parse(mbtextBox.Text);
                mbchecker = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                mbchecker = false;
            }

            if (mbchecker == true && billtextChecker == true && mintChecker == true)
            {
                mbBill = totalMbBill(mb);
                minsBill = totalMinsBill(mins);
                textbill = totalTextBill(text);

                float planCost = 0f;
                if (plancomboBox.SelectedIndex == 0)
                {
                    planCost = 10;
                }
                else if (plancomboBox.SelectedIndex == 1)
                {
                    planCost = 20;
                }
                else if (plancomboBox.SelectedIndex == 2)
                {
                    planCost = 30;
                }

                float finalcost = planCost + mbBill + minsBill + textbill;
                float vatcost = finalcost * 0.2f;

                float grandcost = vatcost + finalcost;

                int index = namecomboBox.SelectedIndex;


                dataGridView1.AutoGenerateColumns = true;

                dataGridView1.Columns.Add("Name", "Name");
                dataGridView1.Columns.Add("Address", "Address");
                dataGridView1.Columns.Add("Phone", "Phone");
                dataGridView1.Columns.Add("Order ID", "Order ID");
                dataGridView1.Columns.Add("date And Time", "Date and Time");

                dataGridView1.Columns.Add("Cost of Text Used", "Cost of Text Used");
                dataGridView1.Columns.Add("Cost of Minutes Used", "Cost of Minutes Used");
                dataGridView1.Columns.Add("Cost of Internet Used", "Cost of Internet Used");
                dataGridView1.Columns.Add("Total Cost of monthly bill", "Total Cost of monthly bill");
                dataGridView1.Columns.Add("VAT", "VAT");
                dataGridView1.Columns.Add("Grand Total", "Grand Total");

                CustomerBL customer1 = CustomerDL.list[index];

                dataGridView1.Rows.Add(customer1.name, customer1.address, customer1.phoneNumber, customer1.orderId, customer1.dateTime, textbill, minsBill, mbBill, finalcost, vatcost, grandcost);

                StatementBL statement = new StatementBL(minsBill, textbill, mbBill, vatcost, grandcost, finalcost);

                StatementDL.storeDataIntoFile(customer1, statement);
                StatementDL.statementsList.Add(statement);
                StatementDL.statementCustList.Add(customer1);
                MessageBox.Show("Data save Successfully");
            }
            else
            {
                MessageBox.Show("Please enter Correct value ");
            }
        }

        private void billbutton_Click(object sender, EventArgs e)
        {
            OrderForm orderForm = new OrderForm();
            orderForm.Show();
        }

        private void restetbutton_Click_1(object sender, EventArgs e)
        {
            textBox.Text = "";
            minttextBox.Text = "";
            mbtextBox.Text = "";
            namecomboBox.Text = "";
            plancomboBox.Text = "";
        }

        private void backbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
