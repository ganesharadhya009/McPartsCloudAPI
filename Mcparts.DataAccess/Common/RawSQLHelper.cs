using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Mcparts.DataAccess.Common
{
    public class RawSQLHelper
    {
        //using (SqlCommand command = new SqlCommand(query, connection))
        //        {
        //            using (SqlDataReader _SqlDataReader = command.ExecuteReader())
        //            {
        //                lsitDepartment = DataReaderMapToList<Department>(_SqlDataReader);
        //            }
        //        }

        public static List<T> DataReaderMapToList<T>(IDataReader _IDataReader)
        {
            List<T> list = new List<T>();
            T _Objetc = default(T);
            while (_IDataReader.Read())
            {
                _Objetc = Activator.CreateInstance<T>();
                foreach (PropertyInfo _PropertyInfo in _Objetc.GetType().GetProperties())
                {
                    if (!object.Equals(_IDataReader[_PropertyInfo.Name], DBNull.Value))
                    {
                        _PropertyInfo.SetValue(_Objetc, _IDataReader[_PropertyInfo.Name], null);
                    }
                }
                list.Add(_Objetc);
            }
            return list;
        }
    }
}
