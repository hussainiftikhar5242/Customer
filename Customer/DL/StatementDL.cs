using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Customer.BL;

namespace Customer.DL
{
    public class StatementDL
    {
        static int checker = 0;
        public static List<StatementBL> statementsList = new List<StatementBL>();
        public static List<CustomerBL> statementCustList = new List<CustomerBL>();

        static string path = "statement.txt";
        public static void storeDataIntoFile(CustomerBL temp, StatementBL statement)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(temp.name + "," + temp.address + "," + temp.phoneNumber + "," + temp.orderId + "," + temp.dateTime + "," + statement.mintUsed + "," + statement.textUsed + "," + statement.mbUsed + "," + statement.VAT + "," + statement.totalBill + "," + statement.grandTotal);
            file.Flush();
            file.Close();
        }

        public static void readDataFromFile()
        {
            StreamReader SFile = new StreamReader(path);
            string Record;

            if (checker == 0)
            {
                if (File.Exists(path))
                {
                    while ((Record = SFile.ReadLine()) != null)
                    {
                        string[] SplitRecord = Record.Split(',');
                        string name = SplitRecord[0];
                        string address = SplitRecord[1];
                        string number = SplitRecord[2];
                        string orderId = SplitRecord[3];
                        DateTime dateTime = DateTime.Parse(SplitRecord[4]);
                        float mintused = float.Parse(SplitRecord[5]);
                        float textUsed = float.Parse(SplitRecord[6]);
                        float mbUsed = float.Parse(SplitRecord[7]);
                        float vat = float.Parse(SplitRecord[8]);
                        float finalBill = float.Parse(SplitRecord[9]);
                        float grandCOst = float.Parse(SplitRecord[10]);
                        CustomerBL customer = new CustomerBL(name, address, number, orderId, dateTime);
                        statementCustList.Add(customer);
                        StatementBL statement = new StatementBL(mintused, textUsed, mbUsed, vat, grandCOst, finalBill);
                        statementsList.Add(statement);
                    }
                    SFile.Close();
                }
                checker = 1;
            }
        }
    }
}
