using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Receipt
{
    class Validation
    {
        public static string Number(string value)
        {
            int result;
            if (int.TryParse(value, out result))
                return value;
            else
                throw new ArgumentException("No letters/characters in number!");
        }

        public static string ValidateType(string value, string[] mas)
        {
            string s;
            if (mas[0] == "privatbank")
            {
                s = "Bank";
            }
            else
            {
                s = "Payment Type";
            }
            foreach (var e in mas)
            {
                if (value == e)
                    return value;
            }
            throw new ArgumentException($"Incorrect {s}");
        }

        public static string ValidateDate(string value)
        {
            if (value == "0") return value;
            DateTime v;
            try
            {
                v = DateTime.Parse(value);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Non-existent Date."); ;
            }

            if (DateTime.Compare(DateTime.Now, v) < 0)
            {
                throw new ArgumentException("Non-existent Date.");
            }
            return v.ToString("yyyy-MM-dd");
        }

        public static string String(string value)
        {
            foreach (char c in value)
            {
                if (char.IsDigit(c))
                    throw new ArgumentException("No integers in string!");
            }
            return value;
        }

        public static string ValidatePrice(string value)
        {
            string strValue = value.ToString(CultureInfo.InvariantCulture).
                IndexOf(".", StringComparison.Ordinal) == -1 ? value.ToString(CultureInfo.InvariantCulture)
                                                               + "." : value.ToString(CultureInfo.InvariantCulture);
            if (strValue.Substring(strValue.IndexOf(".", StringComparison.Ordinal)).Length > 3)
            {
                throw new ArgumentException("Price must have two digits after coma.");
            }
            return value;
        }

    }
}
