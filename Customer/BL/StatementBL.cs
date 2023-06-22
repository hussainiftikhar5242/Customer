using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.BL
{
    public class StatementBL
    {

        public float mintUsed = 0f;
        public float textUsed = 0f;
        public float mbUsed = 0f;
        public float VAT = 0f;
        public float grandTotal = 0f;
        public float totalBill = 0f;

        public StatementBL(float mintUsed, float textUsed, float mbUsed, float vAT, float grandTotal, float totalBill)
        {

            this.mintUsed = mintUsed;
            this.textUsed = textUsed;
            this.mbUsed = mbUsed;
            VAT = vAT;
            this.grandTotal = grandTotal;
            this.totalBill = totalBill;
        }


    }
}
