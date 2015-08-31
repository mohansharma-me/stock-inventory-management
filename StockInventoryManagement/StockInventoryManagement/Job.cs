using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

namespace StockInventoryManagement
{
    public class Job
    {
        #region Forms

        public static frmMain mainForm = null;

        #endregion

        #region Database Class
        public static class Database
        {

            #region Database Variables

            public const String DATABASE_FILE = "database.db";
            public const String DATABASE_VERSION = "3";
            private static SQLiteConnection sqlConnection = null;

            #endregion

            #region Database Methods

            public static long last_inserted_rowid()
            {
                return (long)Job.Database.executeScalar("select last_insert_rowid()");
            }

            public static bool isDatabaseConnected()
            {
                try
                {
                    return sqlConnection == null || (sqlConnection != null && (sqlConnection.State == System.Data.ConnectionState.Closed || sqlConnection.State == System.Data.ConnectionState.Broken)) ? false : true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(mainForm, "Sorry, error occured while validating database connection, please try again." + Environment.NewLine + "Error message: " + ex.Message, "Can't validate database connection.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }

            public static bool openDatabaseConnection()
            {
                try
                {
                    bool itWasNewDB = false;
                    if (isDatabaseConnected()) return true;
                    if (!System.IO.File.Exists(DATABASE_FILE))
                    {
                        SQLiteConnection.CreateFile(DATABASE_FILE);
                        itWasNewDB = true;
                    }
                    else
                    {
                        try
                        {
                            if (System.IO.File.ReadAllBytes(DATABASE_FILE).Length == 0)
                            {
                                itWasNewDB = true;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(mainForm, "Error:" + ex);
                        }
                    }

                    sqlConnection = new SQLiteConnection("Data Source=" + DATABASE_FILE + "; Version=" + DATABASE_VERSION + "; New=False; FailIfMissing=True; Synchronous=Full; Compress=True;");
                    sqlConnection.StateChange += sqlConnection_StateChange;
                    sqlConnection.Open();
                    if (itWasNewDB)
                    {
                        #region Database Initializing

                        executeQuery("create table if not exists _transaction(tranId integer primary key autoincrement, tranTotalPrice double, tranTime datetime, tranType text, tranDeliveryAddress text, tranDeliveryDate datetime, tranDeleted integer default 0, tranClientId integer default 0)");
                        executeQuery("create table if not exists _transaction_data(dataId integer primary key autoincrement, dataTranId integer, dataItemId integer, dataQty double, dataDiscount double, dataPPU double, dataDeleted integer default 0)");
                        executeQuery("create table if not exists _item(itemId integer primary key autoincrement, itemName text, itemCode text, itemPPU double, itemDeleted integer default 0)");
                        executeQuery("create table if not exists _client(clientId integer primary key autoincrement, clientName text, clientSurname text, clientAddress text, clientLandline text, clientTelephone text, clientEmail text, clientRefCode text, clientDeleted integer default 0)");

                        #endregion
                    }
                    return isDatabaseConnected();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(mainForm, "Sorry, error occured while establishing connection with database, please try again." + Environment.NewLine + "Error message: " + ex.Message, "Can't connect to database.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }

            static void sqlConnection_StateChange(object sender, System.Data.StateChangeEventArgs e)
            {
                mainForm.tlblDatabaseStatus.Text = "Database: " + getConnectionStatus(e.CurrentState);
            }

            static string getConnectionStatus(System.Data.ConnectionState state)
            {
                switch (state)
                {
                    case ConnectionState.Broken:
                        return "Broken";
                    case ConnectionState.Closed:
                        return "Disconnected";
                    case ConnectionState.Connecting:
                        return "Connecting...";
                    case ConnectionState.Executing:
                        return "Operating...";
                    case ConnectionState.Fetching:
                        return "Retrieving...";
                    case ConnectionState.Open:
                        return "Connected";
                }
                return "n/a";
            }

            public static void closeDatabaseConnection()
            {
                try
                {
                    if (isDatabaseConnected())
                    {
                        sqlConnection.Close();
                        sqlConnection = null;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(mainForm, "Sorry, error occured while closing database connection, please try again." + Environment.NewLine + "Error message: " + ex.Message, "Can't disconnect to database.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            public static int executeQuery(String query, SQLiteParameter[] parameterArray = null)
            {
                if (isDatabaseConnected())
                {
                    try
                    {
                        SQLiteCommand cmd = new SQLiteCommand(query, sqlConnection);
                        if (parameterArray != null)
                            cmd.Parameters.AddRange(parameterArray);
                        return cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Unable to perform operation on database. [" + ex.Message + "]");
                    }
                }
                else
                {
                    throw new Exception("No database connected.");
                }
                return -1;
            }

            public static object executeScalar(String query)
            {
                try
                {
                    if (isDatabaseConnected())
                    {
                        SQLiteCommand cmd = new SQLiteCommand(query, sqlConnection);
                        object obj = cmd.ExecuteScalar();
                        cmd.Dispose();
                        return obj;
                    }
                    else
                    {
                        throw new Exception("No database connected.");
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to perform scalar operation.");
                }
            }

            public static SQLiteDataReader executeReader(String query, SQLiteParameter[] parameterArray = null)
            {
                if (isDatabaseConnected())
                {
                    try
                    {
                        SQLiteCommand cmd = new SQLiteCommand(query, sqlConnection);
                        if (parameterArray != null)
                            cmd.Parameters.AddRange(parameterArray);
                        return cmd.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Unable to perform operation on database. [" + ex.Message + "]");
                        //MessageBox.Show(mainForm, "Sorry, error while performing operation on database, please try again.", "Operation Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    throw new Exception("No database connected.");
                    //MessageBox.Show(mainForm, "No database connected, please try again by restarting software.", "No database connection found.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                return null;
            }

            public static long countRows(String table, String where = null)
            {
                try
                {
                    String _w = where != null ? " where " + where : "";
                    SQLiteDataReader dr = Job.Database.executeReader("select count(*) as total from " + table + _w);
                    if (dr.Read())
                    {
                        return long.Parse(dr["total"].ToString());
                    }
                    return 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to perform count operation on database.");
                }
                return -1;
            }

            #endregion

            #region Database Operation Methods

            public static classes.Transaction getTransaction(long tranId)
            {
                classes.Transaction tran = null;
                try
                {
                    #region MyRegion
                    SQLiteDataReader dr = executeReader("select * from _transaction where tranId=@id", new SQLiteParameter[] {
                        new SQLiteParameter("@id",tranId)
                    });
                    if(dr!=null && dr.Read())
                    {
                        tran = new classes.Transaction();
                        tran.init(ref dr);
                    }
                    #endregion
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to get transaction details. [" + ex.Message + "]");
                }
                return tran;
            }

            public static List<classes.Transaction> getClientTransactions(long clientId)
            {
                List<classes.Transaction> tranList = new List<classes.Transaction>();
                try
                {
                    SQLiteDataReader dr = executeReader("select tranId from _transaction where tranClientId=@clientId", new SQLiteParameter[] { new SQLiteParameter("@clientId", clientId) });
                    if(dr!=null)
                    {
                        while(dr.Read())
                        {
                            long tranId = long.Parse(dr["tranId"].ToString());
                            classes.Transaction tran = getTransaction(tranId);
                            if (tran != null)
                                tranList.Add(tran);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to get client transaction details. [" + ex.Message + "]");
                }
                return tranList;
            }

            public static List<classes.TransactionReport> getTransactionReport(ref string mostItem, ref string leastItem, ref double totalSales, ref double totalPurchase, DateTime? from, DateTime? to)
            {
                try
                {
                    System.Collections.Hashtable table = new System.Collections.Hashtable();
                    List<classes.TransactionReport> report = new List<classes.TransactionReport>();

                    if (from.HasValue)
                        from = new DateTime(from.Value.Year, from.Value.Month, from.Value.Day, 0, 0, 0);

                    if (to.HasValue)
                        to = new DateTime(to.Value.Year, to.Value.Month, to.Value.Day, 23, 59, 59);

                    String where = "where ";
                    if (from.HasValue && to.HasValue)
                    {
                        where += "DATES>=@from and DATES<=@to and ";
                    }
                    where += "1=1";
                    //, new SQLiteParameter[] { new SQLiteParameter("@from", from), new SQLiteParameter("@to", to) }
                    SQLiteParameter[] param = new SQLiteParameter[2];
                    param[0] = new SQLiteParameter("@from", from);
                    param[1] = new SQLiteParameter("@to", to);
                    //SQLiteDataReader dr = Job.Database.executeReader("select tranTime as DATES, tranType as TYPE, sum(tranTotalPrice) as AMOUNT from _transaction " + where + " group by tranTime, tranType", param);
                    SQLiteDataReader dr = Job.Database.executeReader("select tranId, tranTime as DATES, tranType as TYPE, tranTotalPrice as AMOUNT from _transaction " + where, param);
                    if (dr != null)
                    {
                        while (dr.Read())
                        {
                            try
                            {
                                long tranId = long.Parse(dr["tranId"].ToString());
                                DateTime? date = (DateTime?)dr["DATES"];
                                String type = dr["TYPE"].ToString().ToUpper();
                                double amount = double.Parse(dr["AMOUNT"].ToString());

                                if (true)
                                {
                                    table.Add(tranId, new classes.TransactionReport());
                                }

                                classes.TransactionReport entry = ((classes.TransactionReport)table[tranId]);
                                entry.date = date;
                                entry.tranId = tranId;
                                switch (type)
                                {
                                    case "SALE":
                                        entry.sales = amount;
                                        totalSales += entry.sales;
                                        break;
                                    case "PURCHASE":
                                        entry.purchases = amount;
                                        totalPurchase += entry.purchases;
                                        break;
                                }
                            }
                            catch (Exception) { }
                        }
                    }

                    System.Collections.IEnumerator tor = table.Values.GetEnumerator();
                    while (tor.MoveNext())
                    {
                        report.Add((classes.TransactionReport)tor.Current);
                    }

                    #region Minimum and Maximum Items sold
                    double min = double.MaxValue, max = 0;
                    SQLiteDataReader dr1 = Job.Database.executeReader("select itemName, sum(dataQty) as QTY from _item left join (select dataQty, dataItemId from _transaction, _transaction_data where dataTranId=tranId and tranTime>=@from and tranTime<=@to) on dataItemId=itemId group by itemId", param);
                    if (dr1 != null)
                    {
                        while (dr1.Read())
                        {
                            double qty = dr1["QTY"].ToString().Trim().Length > 0 ? double.Parse(dr1["QTY"].ToString()) : 0;
                            string item = dr1["itemName"].ToString();

                            // most
                            if (qty > max)
                            {
                                mostItem = item;
                            }

                            //min
                            if (qty < min)
                            {
                                leastItem = item;
                            }
                        }
                    }
                    #endregion

                    return report;
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to generate transaction report. [" + ex.Message + "]");
                }
            }

            public static bool getItemReport(long itemId, ref double purchaseQty, ref double saleQty)
            {

                try
                {
                    SQLiteDataReader dr = executeReader("select * from (select sum(td.dataQty) as purchaseQty from _transaction t, _transaction_data td where td.dataTranId=t.tranId and td.dataItemId=@itemId and t.tranType='PURCHASE'), (select sum(td.dataQty) as saleQty from _transaction t, _transaction_data td where td.dataTranId=t.tranId and td.dataItemId=@itemId and t.tranType='SALE')", new SQLiteParameter[] { new SQLiteParameter("@itemId", itemId) });

                    if (dr != null && dr.Read())
                    {
                        purchaseQty = saleQty = 0;
                        String p = dr["purchaseQty"].ToString();
                        String s = dr["saleQty"].ToString();
                        if (p.Trim().Length > 0)
                            purchaseQty = double.Parse(p);
                        if (s.Trim().Length > 0)
                            saleQty = double.Parse(s);
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to get item report. [" + ex.Message + "]");
                }

                return false;
            }

            public static List<classes.Item> getStockReport()
            {
                List<classes.Item> items = new List<classes.Item>();

                try
                {

                    List<classes.Item> allItems = getAllItems();

                    foreach (classes.Item item in allItems)
                    {
                        double purchased = 0, saled = 0;
                        if (getItemReport(item.id, ref purchased, ref saled))
                        {
                            classes.Item newItem = item;
                            newItem.itemPPU = purchased;
                            newItem.discount = saled;
                            newItem.qty = purchased - saled;
                            items.Add(newItem);
                        }
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Unable retrieve stock report. [" + ex.Message + "]");
                }

                return items;
            }

            public static List<classes.Item> getAllItems()
            {
                List<classes.Item> items = new List<classes.Item>();

                try
                {
                    SQLiteDataReader dr = executeReader("select * from _item where itemDeleted=0");
                    if (dr != null)
                    {
                        classes.Item tmpItem = null;
                        while (dr.Read())
                        {
                            tmpItem = new classes.Item();
                            tmpItem.init(ref dr);
                            if (tmpItem.inited)
                                items.Add(tmpItem);
                            tmpItem = null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to retrieve stock items from database.");
                }

                return items;
            }
            public static bool addItem(String itemName, String itemCode, double itemPPU)
            {

                try
                {
                    String whereCode = " or lower(itemCode) LIKE '" + itemCode.Trim().ToLower() + "'";
                    if (itemCode.Trim().Length == 0) whereCode = "";
                    if (countRows("_item", "lower(itemName) LIKE '" + itemName.ToLower().Trim() + "'" + whereCode) > 0)
                    {
                        throw new Exception("Sorry, item already exists with same name or code.");
                    }
                    List<SQLiteParameter> parameters = new List<SQLiteParameter>();
                    parameters.Add(new SQLiteParameter("@name", itemName));
                    parameters.Add(new SQLiteParameter("@code", itemCode));
                    parameters.Add(new SQLiteParameter("@ppu", itemPPU));
                    int inserted = Job.Database.executeQuery("insert into _item(itemName,itemCode,itemPPU) values(@name,@code,@ppu)", parameters.ToArray());
                    return inserted > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to add new item into database. [" + ex.Message + "]");
                }

                return false;
            }

            public static double getAvailableItem(long itemId)
            {
                try
                {
                    List<classes.Item> items = getStockReport();
                    classes.Item item = items.Find(x => (x.id == itemId));
                    if (item != null)
                    {
                        return item.qty;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to retrieve available items from database. [" + ex.Message + "]");
                }
                return 0;
            }

            public static bool deleteItem(long id)
            {

                try
                {
                    int inserted = Job.Database.executeQuery("update _item set itemDeleted=1 where itemId=@id", new SQLiteParameter[] { new SQLiteParameter("@id", id) });
                    return inserted > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to delete item from database. [" + ex.Message + "]");
                }

                return false;
            }

            public static classes.Item findItem(String code, String name)
            {
                classes.Item item = null;

                try
                {
                    SQLiteDataReader dr = Job.Database.executeReader("select * from _item where itemName LIKE '" + name + "' or itemCode LIKE '" + code + "' limit 1");
                    if (dr != null)
                    {
                        if (dr.Read())
                        {
                            item = new classes.Item();
                            item.init(ref dr);
                            return item.inited ? item : null;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to find item data by code/name.");
                }

                return item;
            }
            public static bool addTransactionData(long tranId, classes.TransactionItem item)
            {
                try
                {
                    List<SQLiteParameter> parameters = new List<SQLiteParameter>();
                    parameters.Add(new SQLiteParameter("@tranId", tranId));
                    parameters.Add(new SQLiteParameter("@itemId", item.itemId));
                    //parameters.Add(new SQLiteParameter("@item", item.item));
                    //parameters.Add(new SQLiteParameter("@itemCode", item.itemCode));
                    parameters.Add(new SQLiteParameter("@qty", item.qty));
                    parameters.Add(new SQLiteParameter("@discount", item.discount));
                    parameters.Add(new SQLiteParameter("@ppu", item.ppu));
                    int inserted = Job.Database.executeQuery("insert into _transaction_data(dataTranId,dataItemId,dataQty,dataDiscount,dataPPU) values(@tranId,@itemId,@qty,@discount,@ppu)", parameters.ToArray());
                    return inserted > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to add new tranaction data into database.");
                }
                return false;
            }

            public static long LastTransactionID { get; set; }
            public static bool addTransaction(double totalPrice, DateTime dateTime, classes.Transaction.TransactionType type, String deliveryAddress, DateTime? deliveryDate, List<classes.TransactionItem> items, long client_id = 0)
            {
                try
                {
                    List<SQLiteParameter> parameters = new List<SQLiteParameter>();
                    parameters.Add(new SQLiteParameter("@client", client_id));
                    parameters.Add(new SQLiteParameter("@price", totalPrice));
                    parameters.Add(new SQLiteParameter("@time", dateTime));
                    parameters.Add(new SQLiteParameter("@type", type.ToString()));
                    parameters.Add(new SQLiteParameter("@deliveryAddress", deliveryAddress == null ? "" : deliveryAddress));
                    parameters.Add(new SQLiteParameter("@deliveryDate", !deliveryDate.HasValue ? DateTime.MinValue : deliveryDate.Value));
                    int inserted = Job.Database.executeQuery("insert into _transaction(tranTotalPrice, tranTime, tranType, tranDeliveryAddress, tranDeliveryDate, tranClientId) values(@price,@time,@type,@deliveryAddress,@deliveryDate,@client)", parameters.ToArray());

                    if (inserted == 1)
                    {
                        long tranId = last_inserted_rowid();
                        LastTransactionID = tranId;
                        foreach (classes.TransactionItem item in items)
                        {
                            addTransactionData(tranId, item);
                        }
                        return true;
                    }
                    else
                    {
                        throw new Exception("Unable to add new transaction record into database.");
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception("Sorry, error while add new transaction into database, please try again." + Environment.NewLine + "Error message: " + ex.Message);
                }
                return false;
            }


            public static bool addClient(String name, String surname, String address, String landline, String telephone, String email, String refCode)
            {
                try
                {
                    List<SQLiteParameter> parameters = new List<SQLiteParameter>();
                    parameters.Add(new SQLiteParameter("@name", name));
                    parameters.Add(new SQLiteParameter("@surname", surname));
                    parameters.Add(new SQLiteParameter("@address", address));
                    parameters.Add(new SQLiteParameter("@landline", landline));
                    parameters.Add(new SQLiteParameter("@telephone", telephone));
                    parameters.Add(new SQLiteParameter("@email", email));
                    parameters.Add(new SQLiteParameter("@refcode", refCode));
                    int inserted = executeQuery("insert into _client(clientName,clientSurname,clientAddress,clientLandline,clientTelephone,clientEmail,clientRefCode) values(@name,@surname,@address,@landline,@telephone,@email,@refcode)", parameters.ToArray());
                    return inserted > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to add new client record. [" + ex.Message + "]");
                }
                return false;
            }
            public static List<classes.Client> getAllClients()
            {
                List<classes.Client> clients = new List<classes.Client>();

                try
                {
                    SQLiteDataReader dr = executeReader("select * from _client where clientDeleted=0");
                    if (dr != null)
                    {
                        while (dr.Read())
                        {
                            classes.Client client = new classes.Client();
                            client.init(ref dr);
                            if (client.inited)
                            {
                                clients.Add(client);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to retrieve client records. [" + ex.Message + "]");
                }

                return clients;
            }
            public static bool updateClient(long clientId, string column, string value)
            {

                try
                {
                    int inserted = executeQuery("update _client set " + column + "=@val", new SQLiteParameter[] { new SQLiteParameter("@val", value) });
                    return inserted > 0;
                }
                catch (Exception ex)
                {
                    throw new Exception("Unable to update client record. [" + ex.Message + "]");
                }

                return false;

            }

            #endregion
        }
        #endregion

        #region General UI Methods
        public static void initActionListView(BrightIdeasSoftware.ObjectListView olv)
        {
            List<classes.ActionItem> actions = new List<classes.ActionItem>();
            actions.Add(new classes.ActionItem("Stock", classes.ActionItem.Action.STOCK));
            actions.Add(new classes.ActionItem("Transactions", classes.ActionItem.Action.TRANSACTIONS));
            actions.Add(new classes.ActionItem("Clients", classes.ActionItem.Action.CLIENTS));
            actions.Add(new classes.ActionItem("Items", classes.ActionItem.Action.ITEMS));
            olv.SetObjects(actions);
        }

        public static long printTranID = 0;

        public static void showInvoiceDialog(IWin32Window target, long tranId)
        {
            try
            {
                printTranID = tranId;
                System.Drawing.Printing.PrintDocument pDoc = new System.Drawing.Printing.PrintDocument();
                pDoc.PrintPage += PDoc_PrintPage;

                //PrintDialog printDialog = new PrintDialog();
                //printDialog.Document = pDoc;

                PrintPreviewDialog ppDialog = new PrintPreviewDialog();
                ppDialog.FindForm().WindowState = FormWindowState.Maximized;
                ppDialog.Document = pDoc;

                if (ppDialog.ShowDialog(target) == DialogResult.OK)
                {
                    pDoc.Print();
                }

                //new forms.frmInvoice(tranId).ShowDialog(target);
            }
            catch (Exception ex)
            {
                MessageBox.Show(target, "Sorry, error occured please try again after setting default printer in your Printers Setttings." + Environment.NewLine + "Error message : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static void PDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            string client_name = "", client_address = "";
            double total_price = 0;
            List<classes.Item> items = new List<classes.Item>();

            bool print = false;
            SQLiteDataReader dr = Database.executeReader("select * from _transaction where tranId=@id", new SQLiteParameter[] { new SQLiteParameter("@id", printTranID) });
            if (dr.Read())
            {
                long clientId = long.Parse(dr["tranClientId"].ToString());
                total_price = double.Parse(dr["tranTotalPrice"].ToString());
                if (clientId == 0)
                {

                }
                else
                {
                    SQLiteDataReader dr2 = Database.executeReader("select * from _client where clientId=@id", new SQLiteParameter[] { new SQLiteParameter("@id", clientId) });
                    if (dr2.Read())
                    {
                        client_name = dr2["clientName"].ToString();
                        client_address = dr2["clientAddress"].ToString();
                    }
                    dr2.Close();
                }

                SQLiteDataReader dr1 = Database.executeReader("select * from _transaction_data,_item where dataItemId=itemId and dataTranId=@id", new SQLiteParameter[] { new SQLiteParameter("@id", printTranID) });
                while (dr1.Read())
                {
                    classes.Item item = new classes.Item();
                    item.itemName = dr1["itemName"].ToString();
                    item.qty = double.Parse(dr1["dataQty"].ToString());
                    item.itemPPU = (item.qty * double.Parse(dr1["dataPPU"].ToString())) - double.Parse(dr1["dataDiscount"].ToString());
                    items.Add(item);
                }
                print = true;

            }
            dr.Close();

            if (print)
            {


                Font baseFont = new Font(FontFamily.GenericSansSerif, 16);
                SolidBrush blackBrush = new SolidBrush(Color.Black);
                Graphics g = e.Graphics;
                float x = 10, y = 10;
                g.DrawString(Properties.Settings.Default.appOwner, baseFont, blackBrush, x, y);
                y += baseFont.Height + 5;
                g.DrawString("", baseFont, blackBrush, x, y);
                g.DrawString("INVOICE", new Font(baseFont, FontStyle.Bold), blackBrush, 600, y);
                y += baseFont.Height + 15;
                g.DrawLine(new Pen(blackBrush, 10), x, y, e.PageBounds.Width - 10, y);
                y += baseFont.Height;

                g.DrawString("Bill To:", new Font(baseFont, FontStyle.Bold), blackBrush, x, y);
                x += g.MeasureString("Bill To: ", baseFont).Width + 5;
                g.DrawString(client_name, baseFont, blackBrush, x, y);

                y += (baseFont.Height * 2);
                x = 10;
                g.DrawString("Items", baseFont, blackBrush, x, y);
                x += 500;
                g.DrawString("Qty", baseFont, blackBrush, x, y);
                x += 200;
                g.DrawString("Amount", baseFont, blackBrush, x, y);
                y += baseFont.Height + 15;
                x = 10;
                g.DrawLine(new Pen(blackBrush, 5), x, y, e.PageBounds.Width - 10, y);
                y += baseFont.Height + 10;

                foreach (classes.Item item in items)
                {
                    x = 10;
                    g.DrawString(item.itemName, baseFont, blackBrush, x, y);
                    x += 500;
                    g.DrawString(item.qty.ToString("0.00"), baseFont, blackBrush, x, y);
                    x += 200;
                    g.DrawString(item.itemPPU.ToString("0.00"), baseFont, blackBrush, x, y);
                    y += baseFont.Height + 15;
                }
                x = 10;
                g.DrawLine(new Pen(blackBrush, 5), x, y, e.PageBounds.Width - 10, y);
                y += baseFont.Height + 10;

                x += 10 + 500;
                g.DrawString("Total: " + total_price.ToString("0.00"), baseFont, blackBrush, x, y);
                y += baseFont.Height + 10;
                double vat = total_price * Properties.Settings.Default.appSettingVAT / 100;
                vat += total_price;
                g.DrawString("VAT: " + vat.ToString("0.00"), baseFont, blackBrush, x, y);

            }
        }

        #endregion
    }
}
