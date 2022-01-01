using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace HotelManagement
{
    public class HashPassword
    {
        private byte[] salt { get; set; }
        private byte[] hashBytes { get; set; }

        public string ConvertPass(string pass)
        {
            salt = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(salt);
            var pbkdf2 = new Rfc2898DeriveBytes(pass, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            hashBytes = new byte[36];

            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string savePass = Convert.ToBase64String(hashBytes);
            return savePass;
        }


        public bool ComparePass(string savePass, string enterPass)
        {
            hashBytes = new byte[36];
            hashBytes = Convert.FromBase64String(savePass);
            salt = new byte[16];           
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(enterPass, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);
            //byte[] hashBytesEnterPass = new byte[36];
            //hashBytesEnterPass = ConvertPass(enterPass, salt);
            //////string savePassdd = Convert.ToBase64String(hashBytesEnterPass);
            bool flag = true;
            for (int i = 0; i < 20; i++)
            {
                //if (hashBytes[i + 16] != hashBytesEnterPass[i + 16])
                //{
                //    flag = false;
                //    break;
                //}

                if (hashBytes[i + 16] != hash[i])
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }
    }
    //public byte[] ConvertPass(string pass, byte[] salt)
    //{
    //    //salt = new byte[16];
    //    //new RNGCryptoServiceProvider().GetBytes(salt);

    //    var pbkdf2 = new Rfc2898DeriveBytes(pass, salt, 10000);

    //    byte[] hash = pbkdf2.GetBytes(20);

    //    hashBytes = new byte[36];

    //    Array.Copy(salt, 0, hashBytes, 0, 16);
    //    Array.Copy(hash, 0, hashBytes, 16, 20);

    //    return hashBytes;



    //}
}
