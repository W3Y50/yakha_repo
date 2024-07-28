using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Adapter_Task
{
    // Adapter class
    public class GoogleMailServerAdapter : IMailServer
    {
        private GoogleMailServer googleMailServer;

        public GoogleMailServerAdapter()
        {
            googleMailServer = new GoogleMailServer();
        }

        public void ConnectAndSendMail(string emailAdress, string content, string receiverName)
        {
            Console.WriteLine($"The Decrypted message is: {content}");
            Console.WriteLine("----------------------------------");

            // Encrypt the message
            string encryptedMessage = CryptoUtils.EncryptMessage(content);

            Console.WriteLine($"The Encrypted message is: {encryptedMessage}");
            googleMailServer.ConnectAndSendMail(emailAdress, encryptedMessage, receiverName);
            Console.WriteLine("----------------------------------");


            // Decrypt the received message, after the sending (simulated)
            string decryptedMessage = CryptoUtils.DecryptMessage(encryptedMessage);
            Console.WriteLine($"The Decrypted message is: {decryptedMessage}");
            Console.WriteLine("Email successfully encrypted...");
            Console.WriteLine("----------------------------------");
        }

        
    }
}

public class CryptoUtils
{
    private static byte[] Key = Encoding.UTF8.GetBytes("mysecretkey12345"); // Replace with your own key
    private static byte[] IV = new byte[16]; // AES requires 16 bytes for IV

    static CryptoUtils()
    {
        // Generate a random IV
        using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(IV);
        }
    }

    public static string EncryptMessage(string message)
    {
        // Create an AES encryption object
        using (Aes aes = Aes.Create())
        {
            aes.Key = Key;
            aes.IV = IV;
            aes.Padding = PaddingMode.PKCS7; // Set the padding mode to PKCS7

            // Encrypt the message
            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(message);
                    }
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }
    }

    public static string DecryptMessage(string encryptedMessage)
    {
        // Create an AES decryption object
        using (Aes aes = Aes.Create())
        {
            aes.Key = Key;
            aes.IV = IV;
            aes.Padding = PaddingMode.PKCS7; // Set the padding mode to PKCS7

            // Decrypt the message
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
            byte[] encryptedBytes = Convert.FromBase64String(encryptedMessage);
            using (MemoryStream ms = new MemoryStream(encryptedBytes))
            {
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(cs))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }
    }
}
