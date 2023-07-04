using System.Security.Cryptography;
using System.Text;

namespace Core.Utilities.Tools;

public static class TokenGeneratorTools
{
    public static string GenerateHashString(
        HashAlgorithm hashAlgorithm,
        string input)
    {
        var sb = new StringBuilder();
        using (hashAlgorithm)
        {
            var inputBytes = Encoding.ASCII.GetBytes(input);
            var hashBytes = hashAlgorithm.ComputeHash(inputBytes);


            foreach (var hashByte in hashBytes)
            {
                sb.Append(hashByte.ToString("X2").ToLower());
            }
        }

        return sb.ToString();
    }
}