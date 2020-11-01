using System.Security.Cryptography;
using System.Text;
using VSP_46275z_MyProject.Dal.Services.Password.Contracts;

namespace VSP_46275z_MyProject.Dal.Services.Password
{
    public class PasswordService : IPasswordService
    {
        public string Hash(string text)
        {
            var hash = string.Empty;
            var sha512 = new SHA512Managed();
            var bytes = Encoding.ASCII.GetBytes(text);

            using (sha512)
            {
                var hashValue = sha512.ComputeHash(bytes);

                foreach (var @byte in hashValue)
                {
                    hash += $"{@byte:x2}";
                }
            }

            return hash;
        }
    }
}