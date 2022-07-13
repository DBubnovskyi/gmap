using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapProcassor.Models
{
    public static class Extension
    {
        public static string UTF8(this string str)
        {
            byte[] bytes = Encoding.Default.GetBytes(str);
            str = Encoding.UTF8.GetString(bytes);
            return str;
        }

        public static string UTF32(this string str)
        {
            byte[] bytes = Encoding.Default.GetBytes(str);
            str = Encoding.UTF32.GetString(bytes);
            return str;
        }

        public static string Unicode(this string str)
        {
            byte[] bytes = Encoding.Default.GetBytes(str);
            str = Encoding.Unicode.GetString(bytes);
            return str;
        }
    }
}
