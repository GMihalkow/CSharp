using System;
using System.Text;
using VSP_46275z_MyProject.Dal.Services.CryptService.Contracts;

namespace VSP_46275z_MyProject.Dal.Services.CryptService
{
    public class CryptService : ICryptService
    {
        public string Encrypt(string text)
        {
            var inputbuffer = Encoding.Unicode.GetBytes(text);

            return Convert.ToBase64String(inputbuffer);
        }

        public string Decrypt(string text)
        {
            var resultBuffer = Convert.FromBase64String(text);

            return Encoding.Unicode.GetString(resultBuffer);
        }
    }
}