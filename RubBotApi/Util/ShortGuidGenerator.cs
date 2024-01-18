using System.Security.Cryptography;

namespace RubBotApi.Util;

public static class ShortGuidGenerator
{
    public static string GenerateShortGuid()
    {
        using (var sha256 = SHA256.Create())
        {
            Guid guid = Guid.NewGuid();
            byte[] hashBytes = sha256.ComputeHash(guid.ToByteArray());
            string shortGuid = BitConverter.ToString(hashBytes, 0, 8).Replace("-", "").ToLower();
            return shortGuid;
        }
    }
}