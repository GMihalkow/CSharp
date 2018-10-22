namespace SIS.Framework.Services
{
    using SIS.Framework.Services.Contracts;
    using System.Security.Cryptography;
    using System.Text;

    public class HashService : IHashService
    {
        public string Compute256Hash(string rawData)
        {
            //Create a Sha256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                //ComputeHash -  returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                //Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int index = 0; index < bytes.Length; index++)
                {
                    builder.Append(bytes[index].ToString("x2"));
                }

                return builder.ToString().TrimEnd();
            }
        }
    }
}