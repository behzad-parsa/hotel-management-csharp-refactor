using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Services
{
    public class Mapper
    {
        //Convert DataTable To Tagert Object (or Model)
        public static T ConvertRowToObj<T>(DataRow dataRow)
        {
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dataRow.Table.Columns)
            {
                foreach (PropertyInfo property in typeof(T).GetProperties())
                {
                    if (property.Name == column.ColumnName)
                        property.SetValue(obj, dataRow[column.ColumnName], null);

                    else
                        continue;
                }

            }

            return obj;
        }


        public static List<T> ConvertDataTableToList<T> (DataTable dataTable)
        {
            List<T> objectList = new List<T>();
            foreach (DataRow row in dataTable.Rows)
            {
                T item = ConvertRowToObj<T>(row);
                objectList.Add(item);
            }
            return objectList;
        }
        
    }
}
