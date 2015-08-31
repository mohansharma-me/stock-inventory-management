using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockInventoryManagement.classes
{
    public class Transaction
    {
        public enum TransactionType
        {
            SALE, //1
            PURCHASE //2
        }

        public void init(ref System.Data.SQLite.SQLiteDataReader dr)
        {
            try
            {

                this.id = long.Parse(dr["tranId"].ToString());
                this.client_id = long.Parse(dr["tranClientId"].ToString());
                this.total_price = double.Parse(dr["tranTotalPrice"].ToString());
                this.timestamp = (DateTime?)dr["tranTime"];
                this.type = dr["tranType"].ToString().Equals("SALE") ? TransactionType.SALE : TransactionType.PURCHASE;

                this.delivery_address = dr["tranDeliveryAddress"].ToString();
                this.delivery_date = (DateTime?)dr["tranDeliveryDate"];

                this.items = TransactionItem.getItems(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, error while getting transaction item from database, please try again." + Environment.NewLine + ex.Message);
            }
        }

        public long id;
        public double total_price;
        public DateTime? timestamp;
        public TransactionType type;

        public long client_id;

        public String delivery_address;
        public DateTime? delivery_date;

        public List<TransactionItem> items;
    }
}
