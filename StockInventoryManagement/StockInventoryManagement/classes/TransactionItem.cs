using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockInventoryManagement.classes
{
    public class TransactionItem
    {
        public bool inited = false;

        public TransactionItem()
        {
        }

        public void init(ref System.Data.SQLite.SQLiteDataReader dr)
        {
            try
            {
                this.id = long.Parse(dr["dataId"].ToString());
                this.tranId = long.Parse(dr["dataTranId"].ToString());
                this.itemId = long.Parse(dr["dataItemId"].ToString());
                this.qty = double.Parse(dr["dataQty"].ToString());
                this.discount = double.Parse(dr["dataDiscount"].ToString());
                this.ppu = double.Parse(dr["dataPPU"].ToString());
                inited = true;
            }
            catch (Exception ex)
            {
                inited = false;
                throw new Exception("Unable to initialize transaction item. [" + ex.Message + "]");
            }
        }

        public static List<TransactionItem> getItems(long tranId)
        {
            List<TransactionItem> items = new List<TransactionItem>();

            try
            {
                System.Data.SQLite.SQLiteDataReader dr = Job.Database.executeReader("select * from _transaction_data where dataTranId=" + tranId);
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        try
                        {
                            TransactionItem item = new TransactionItem();
                            item.init(ref dr);
                            if (item.inited)
                            {
                                items.Add(item);
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Sorry, error while initializing transaction item, please try again." + Environment.NewLine + "Error message: " + ex.Message);
                        }
                    }
                }
                else
                {
                    throw new Exception("Sorry, error while getting all transaction items, please try again." + Environment.NewLine + "Error message: No data reader found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Sorry, error while getting all transaction items, please try again." + Environment.NewLine + "Error message: " + ex.Message);
            }

            return items;
        }

        public long id;
        public long tranId;

        public long itemId;
        public String item;
        public String itemCode;
        public double qty;
        public double discount;
        public double ppu;
    }
}
