using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockInventoryManagement.classes
{
    public class ActionItem
    {
        public enum Action
        {
            STOCK,
            TRANSACTIONS,
            CLIENTS,
            ITEMS
        }

        public String title;
        public Action action;

        public ActionItem(String title, Action action)
        {
            this.title = title;
            this.action = action;
        }
    }
}
