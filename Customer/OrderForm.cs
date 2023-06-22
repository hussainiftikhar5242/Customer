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
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;

namespace Customer
{
    public partial class OrderForm : Form
    {
        public OrderForm()
        {
            InitializeComponent();
        }

        private void backbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {
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

            int count = StatementDL.statementCustList.Count;
            float totalOrderBill = 0f;

            for (int i = 0; i < count; i++)
            {
                totalOrderBill = totalOrderBill + StatementDL.statementsList[i].grandTotal;
                dataGridView1.Rows.Add(StatementDL.statementCustList[i].name, StatementDL.statementCustList[i].address, StatementDL.statementCustList[i].phoneNumber, StatementDL.statementCustList[i].orderId, StatementDL.statementCustList[i].dateTime, StatementDL.statementsList[i].textUsed, StatementDL.statementsList[i].mintUsed, StatementDL.statementsList[i].mbUsed, StatementDL.statementsList[i].totalBill, StatementDL.statementsList[i].VAT, StatementDL.statementsList[i].grandTotal);
            }

            pricelabel.Text = "" + totalOrderBill;

            saveIntoPdf();

        }

        private void saveIntoPdf()
        {
            Document document = new Document();

            // Create a new PDF writer to write the document to a file
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream("data.pdf", FileMode.Create));

            // Open the document
            document.Open();

            // Create a new table with the same number of columns as your DataGridView
            PdfPTable table = new PdfPTable(dataGridView1.Columns.Count);
            iTextSharp.text.Font font = FontFactory.GetFont(FontFactory.HELVETICA, 12f);

            // Add table headers
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                table.AddCell(new Phrase(dataGridView1.Columns[i].HeaderText, font));
            }

            // Add table rows
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        table.AddCell(new Phrase(dataGridView1.Rows[i].Cells[j].Value.ToString()));
                    }
                }
            }

            // Add the table to the document
            document.Add(table);

            // Close the document
            document.Close();
        }
    }
}
