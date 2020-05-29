using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Meta.TI.Domain.Extensions
{
    public static class StringExtensions
    {
        public static string GetMd5Hash(this string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }
    }
}
