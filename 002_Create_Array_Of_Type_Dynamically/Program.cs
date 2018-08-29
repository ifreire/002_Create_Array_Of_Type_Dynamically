using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _002_Create_Array_Of_Type_Dynamically
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataTypes = "System.UInt32, System.String, System.String, System.Single";
            var dataValues = "1, Fulano, Matodo001, 25.49";

            Type[] paramTypes = GetParams(dataTypes);
            Object[] paramValues = GetValues(dataValues);
            Dictionary<Int32, Dictionary<Type, Object>> dic = new Dictionary<Int32, Dictionary<Type, Object>>();

            for (int x = 0; x < paramTypes.Length; x++)
            {
                Type type = paramTypes[x];
                Object value = paramValues[x];
                Dictionary<Type, Object> dicVal = new Dictionary<Type, Object>();
                dicVal.Add(type, Convert.ChangeType(value, type, CultureInfo.InvariantCulture));
                dic.Add(x, dicVal);
            }
        }

        static Type[] GetParams(String dataTypes)
        {
            //out or in parameters of your function.   
            char[] charSeparators = new char[] { ',', ' ' };
            string[] types = dataTypes.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);

            // create a list of data types for each argument
            List<Type> listTypes = new List<Type>();
            foreach (string t in types)
                listTypes.Add(Type.GetType(t));

            // convert the list to an array and return
            return listTypes.ToArray<Type>();
        }

        static Object[] GetValues(String dataValues)
        {
            char[] charSeparators = new char[] { ',', ' ' };
            return dataValues.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}