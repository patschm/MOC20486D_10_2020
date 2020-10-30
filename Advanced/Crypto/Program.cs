using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Crypto
{
    class Program
    {
        static void Main(string[] args)
        {
            //IntegrityAsym();
            ConfidentialitySym();
        }

        private static void ConfidentialitySym()
        {
            // Sender
            string bericht = "Hello World";
            AesManaged alg = new AesManaged();
            byte[] key = alg.Key;
            byte[] iv = alg.IV;

            byte[] cipher;
            using(MemoryStream opvangbak = new MemoryStream())
            {
                using(CryptoStream cr = new CryptoStream(opvangbak, alg.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    using(StreamWriter wr = new StreamWriter(cr))
                    {
                        wr.WriteLine(bericht);
                    }
                }
                cipher = opvangbak.ToArray();
            }

            Console.WriteLine(Encoding.UTF8.GetString(cipher));


            // Ontvanger
            alg = new AesManaged();
            alg.Key = key;
            alg.IV = iv;

            using (MemoryStream initBak = new MemoryStream(cipher))
            {
                using (CryptoStream cr = new CryptoStream(initBak, alg.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    using (StreamReader rdr = new StreamReader(cr))
                    {
                        string data = rdr.ReadToEnd();
                        Console.WriteLine(data);
                    }
                }
            }



        }

        private static void IntegrityAsym()
        {
            // Sender
            string bericht = "Hello World";
            SHA1Managed sh = new SHA1Managed();
            byte[] hash = sh.ComputeHash(Encoding.UTF8.GetBytes(bericht));
            DSACryptoServiceProvider dsa = new DSACryptoServiceProvider();
            string pubKey = dsa.ToXmlString(false);
            byte[] signature = dsa.CreateSignature(hash);


            // Ed
            bericht += ".";


            // Receiver
            SHA1Managed sh2 = new SHA1Managed();
            byte[] hashs = sh2.ComputeHash(Encoding.UTF8.GetBytes(bericht));
            DSACryptoServiceProvider dsa2 = new DSACryptoServiceProvider();
            dsa2.FromXmlString(pubKey);
            bool isOk = dsa2.VerifyHash(hashs, "SHA1", signature);

            Console.WriteLine(isOk);
            Console.WriteLine(Convert.ToBase64String(hashs));
            Console.WriteLine(Convert.ToBase64String(hash));
        }
    }
}
