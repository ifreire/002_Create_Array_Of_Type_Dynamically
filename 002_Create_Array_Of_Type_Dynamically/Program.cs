using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _002_Create_Array_Of_Type_Dynamically
{
    class Program
    {
        private static char[] charSeparators = new char[] { ',', ' ' };

        static void Main(string[] args)
        {
            var dataTypes = "System.UInt32, System.String, System.String, System.Single";
            var dataValues = "1, Fulano, Matodo001, 25.49";

            Type[] paramTypes = GetParams(dataTypes);
            Object[] paramValues = GetValues(dataValues, paramTypes);
        }

        static Type[] GetParams(String dataTypes)
        {
            string[] types = dataTypes.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            List<Type> listTypes = new List<Type>();

            foreach (string type in types)
                listTypes.Add(Type.GetType(type));

            return listTypes.ToArray();
        }

        static Object[] GetValues(String dataValues, Type[] paramTypes)
        {
            Object[] paramValues = dataValues.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            Object[] paramValues_NEW = new Object[paramValues.Length];

            for (int i = 0; i < paramValues.Length; i++)
                paramValues_NEW[i] = Convert.ChangeType(paramValues[i], paramTypes[i], CultureInfo.InvariantCulture);

            return paramValues_NEW;
        }
    }
}