using System;
using System.Security.Cryptography;
using System.Text;
using VSP_46275z_MyProject.Dal.Services.CryptService.Contracts;

namespace VSP_46275z_MyProject.Dal.Services.CryptService
{
    public class CryptService : ICryptService
    {
        private readonly byte[] key = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
        private readonly byte[] iv = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };


        public string Encrypt(string text)
        {
            using (var algorithm = DES.Create())
            {
                var transform = algorithm.CreateEncryptor(this.key, this.iv);

                var inputbuffer = Encoding.Unicode.GetBytes(text);
                var outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);

                return Convert.ToBase64String(outputBuffer);
            }
        }

        public string Decrypt(string text)
        {
            using (var algorithm = DES.Create())
            {
                var transform = algorithm.CreateDecryptor(this.key, this.iv);

                var inputbuffer = Convert.FromBase64String(text);
                var outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);

                return Encoding.Unicode.GetString(outputBuffer);

            }
        }
    }
}