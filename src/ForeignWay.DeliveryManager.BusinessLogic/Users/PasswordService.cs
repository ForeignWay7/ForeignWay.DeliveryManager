using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ForeignWay.DeliveryManager.BusinessLogic.Users
{
    public class PasswordService : IPasswordService
    {
        public async Task<string> CreateHashAsync(string passwordText)
        {
            var passwordHash = GenerateHash(passwordText, passwordText.Length);

            return await Task.FromResult(passwordHash);
        }

        private string GenerateHash(string input, int salt)
        {
            var bytes = Encoding.UTF8.GetBytes(input + salt);
            var hash = SHA256.Create().ComputeHash(bytes);

            return ByteArrayToHexString(hash);
        }

        private string ByteArrayToHexString(byte[] bytes)
        {
            var stringBuilder = new StringBuilder(bytes.Length * 2);

            foreach (var b in bytes)
                stringBuilder.Append(b);

            return stringBuilder.ToString();
        }
    }
}