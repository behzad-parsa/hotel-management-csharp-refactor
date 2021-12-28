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
        public static T ConvertToObj<T>(DataRow dataRow)
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
        
    }
}
