using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Construlink.Data;

public static class Encrypter
{
    private static readonly byte[] Key = GenerateStaticKey("9F23ED25-5E94-45B7-9939-BA32AB0B2B73", Encoding.UTF8.GetBytes("#d4bad")); // 32-byte key for AES-256
    private static readonly byte[] IV = GenerateStaticIV("9F23ED25-5E94-45B7-9939-BA32AB0B2B73", Encoding.UTF8.GetBytes("#d4bad")); // 16-byte IV for AES

    public static string Encrypt(string plainText)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Key;
            aesAlg.IV = IV;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    string base64CipherText = Convert.ToBase64String(msEncrypt.ToArray());
                    return HttpUtility.UrlEncode(base64CipherText);
                }
            }
        }
    }

    public static string Decrypt(string cipherText)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Key;
            aesAlg.IV = IV;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            string base64CipherText = HttpUtility.UrlDecode(cipherText);
            using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(base64CipherText)))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }
    }

    public static byte[] GenerateStaticKey(string passphrase, byte[] salt)
    {
        // Use PBKDF2 to derive a 32-byte key from the passphrase and salt
        using (var deriveBytes = new Rfc2898DeriveBytes(passphrase, salt, 100000, HashAlgorithmName.SHA256))
        {
            return deriveBytes.GetBytes(32); // 32-byte key for AES-256
        }
    }
    public static byte[] GenerateStaticIV(string passphrase, byte[] salt)
    {
        // Use PBKDF2 to derive a 16-byte IV from the passphrase and salt
        using (var deriveBytes = new Rfc2898DeriveBytes(passphrase, salt, 100000, HashAlgorithmName.SHA256))
        {
            return deriveBytes.GetBytes(16); // 16-byte IV for AES
        }
    }

}
