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
            Object[] paramValues = GetValues(dataValues, paramTypes);
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

        static Object[] GetValues(String dataValues, Type[] paramTypes)
        {
            Char[] charSeparators = new Char[] { ',', ' ' };
            Object[] paramValues = dataValues.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
            Object[] paramValues_NEW = new Object[paramValues.Length];

            for (int i = 0; i < paramValues.Length; i++)
                paramValues_NEW[i] = Convert.ChangeType(paramValues[i], paramTypes[i], CultureInfo.InvariantCulture);

            return paramValues_NEW;
        }
    }
}