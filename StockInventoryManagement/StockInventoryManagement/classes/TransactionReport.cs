using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockInventoryManagement.classes
{
    public class TransactionReport
    {
        public long tranId;
        public DateTime? date;
        public double sales = 0, purchases = 0;
    }
}
