using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace FProjectCamping.Models.Infra
{
    public class HashUtility
    {
        public static string ToSHA256(string plainTxt,string salt)
        {
            using(var mySHA256 = SHA256.Create())
            {
                var passwordBytes=Encoding.UTF8.GetBytes(salt+plainTxt);
                var hash=mySHA256.ComputeHash(passwordBytes);
                var sb=new StringBuilder();
                foreach (var b in hash) sb.Append(b.ToString("X2"));
                 
                return sb.ToString();
            }
        }

        public static string GetSalt()
        {
            return System.Configuration.ConfigurationManager.AppSettings["salt"];

        }
    }
}