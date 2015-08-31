using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockInventoryManagement.classes
{
    public class Item
    {
        public long id;
        public String itemName;
        public String itemCode;
        public double itemPPU;


        public double discount;
        public double qty;

        public bool inited = false;

        public void init(ref System.Data.SQLite.SQLiteDataReader dr)
        {
            try
            {

                id = long.Parse(dr["itemId"].ToString());
                itemName = dr["itemName"].ToString();
                itemCode = dr["itemCode"].ToString();
                itemPPU = double.Parse(dr["itemPPU"].ToString());

                inited = true;
            }
            catch (Exception ex)
            {
                inited = false;
                throw new Exception("Unable to initialize stock item. [" + ex.Message + "]");
            }
        }

        public bool delete()
        {
            return Job.Database.deleteItem(id);
        }

        public override string ToString()
        {
            return itemName;
        }
    }
}
