using System;
using System.Text;

namespace _6MKT.BackOffice.Domain.ValueObjects.Password
{
    public static class GeneratePassword
    {
        public static string Build(int length)
        {
            const string valid = "!@#$%¨&*()^};/.{abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            var res = new StringBuilder();
            var rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
    }
}