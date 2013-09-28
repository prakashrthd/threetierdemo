using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FinalDemo.PL;
using FinalDemo.DAL;

namespace FinalDemo.BAL
{
    public class ContactsService
    {
               
        public  bool Insert(ContactsProperties businessObject)
        {
            clContactsSql objContactSql = new clContactsSql();
            return objContactSql.Insert(businessObject);
        }

        public  bool Update(ContactsProperties businessObject)
        {
            clContactsSql objContactSql = new clContactsSql();
            return objContactSql.Update(businessObject);
        }

        public  ContactsProperties SelectByPrimaryKey(int keys)
        {
            clContactsSql objContactSql = new clContactsSql();
            return objContactSql.SelectByPrimaryKey(keys);
        }

        public  List<ContactsProperties> SelectAll()
        {
            clContactsSql objContactSql = new clContactsSql();
            return objContactSql.SelectAll();
        }

        public  List<ContactsProperties> SelectByField(string fieldName, object value)
        {
            clContactsSql objContactSql = new clContactsSql();
            return objContactSql.SelectByField(fieldName, value);
        }

        public  bool Delete(int keys)
        {
            clContactsSql objContactSql = new clContactsSql();
            return objContactSql.Delete(keys);
        }

        public bool DeleteByField(string fieldName, object value)
        {
            clContactsSql objContactSql = new clContactsSql();
            return objContactSql.DeleteByField(fieldName, value);
        }

        public List<ContactsProperties> SelectAllSearch(string Search)
        {
            clContactsSql objContactSql = new clContactsSql();
            return objContactSql.SelectAllSearch(Search);
        }
    }
}
