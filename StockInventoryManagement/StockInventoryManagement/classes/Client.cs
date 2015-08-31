using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockInventoryManagement.classes
{
    public class Client
    {
        public string _name, _surname, _address, _landline, _telephone, _email, _refcode;

        public long id;
        public string name
        {

            get
            {
                return _name;
            }

            set
            {
                try
                {
                    if (Job.Database.updateClient(id, "clientName", value))
                        _name = value;
                }
                catch (Exception) { }
            }

        }
        public string surname
        {
            get
            {
                return _surname;
            }

            set
            {
                try
                {
                    if (Job.Database.updateClient(id, "clientSurname", value))
                        _surname = value;
                }
                catch (Exception) { }
            }
        }
        public string address
        {
            get
            {
                return _address;
            }

            set
            {
                try
                {
                    if (Job.Database.updateClient(id, "clientAddress", value))
                        _address = value;
                }
                catch (Exception) { }
            }
        }
        public string landline
        {
            get
            {
                return _landline;
            }

            set
            {
                try
                {
                    if (Job.Database.updateClient(id, "clientLandline", value))
                        _landline = value;
                }
                catch (Exception) { }
            }
        }
        public string telephone
        {
            get
            {
                return _telephone;
            }

            set
            {
                try
                {
                    if (Job.Database.updateClient(id, "clientTelephone", value))
                        _telephone = value;
                }
                catch (Exception) { }
            }
        }
        public string email
        {
            get
            {
                return _email;
            }

            set
            {
                try
                {
                    if (Job.Database.updateClient(id, "clientEmail", value))
                        _email = value;
                }
                catch (Exception) { }
            }
        }
        public string refcode
        {
            get
            {
                return _refcode;
            }

            set
            {
                try
                {
                    if (Job.Database.updateClient(id, "clientRefCode", value))
                        _refcode = value;
                }
                catch (Exception) { }
            }
        }

        public bool inited = false;
        public void init(ref System.Data.SQLite.SQLiteDataReader dr)
        {
            inited = false;
            try
            {

                id = long.Parse(dr["clientId"].ToString());
                _name = dr["clientName"].ToString();
                _surname = dr["clientSurname"].ToString();
                _address = dr["clientAddress"].ToString();
                _landline = dr["clientLandline"].ToString();
                _telephone = dr["clientTelephone"].ToString();
                _email = dr["clientEmail"].ToString();
                _refcode = dr["clientRefCode"].ToString();

                inited = true;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to initialize client record. [" + ex.Message + "]");
            }
        }

        public void delete()
        {
            try
            {
                Job.Database.updateClient(id, "clientDeleted", "1");
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to delete client profile. [" + ex.Message + "]");
            }
        }

        public override string ToString()
        {
            return _name + " (" + _refcode + ")";
        }
    }
}
