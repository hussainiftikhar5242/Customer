using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Customer.BL;

namespace Customer.DL
{
    public class CustomerDL
    {
        public static int checker = 0;
        static string path = "customer.txt";
        public static List<CustomerBL> list = new List<CustomerBL>();

        public static void storeDataIntoFile(CustomerBL temp)
        {
            StreamWriter file = new StreamWriter(path, true);
            file.WriteLine(temp.name + "," + temp.address + "," + temp.phoneNumber + "," + temp.orderId + "," + temp.dateTime);
            file.Flush();
            file.Close();
        }

        public static void readDataFromFile()
        {
            StreamReader SFile = new StreamReader(path);
            string Record;

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
                    CustomerBL customer = new CustomerBL(name, address, number, orderId, dateTime);
                    list.Add(customer);
                }
                SFile.Close();
            }


        }


    }
}
