using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.BL
{
    public class CustomerBL
    {
        public string name;
        public string address;
        public string phoneNumber;
        public string orderId;
        public DateTime dateTime;

        public CustomerBL() { }
        public CustomerBL(string name, string address, string phoneNumber, string orderId, DateTime dateTime)
        {
            this.name = name;
            this.address = address;
            this.phoneNumber = phoneNumber;
            this.orderId = orderId;
            this.dateTime = dateTime;
        }
    }
}
