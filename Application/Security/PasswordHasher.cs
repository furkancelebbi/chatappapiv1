using System.Security.Cryptography;

namespace Application.Security
{
    public static class PasswordHasher
    {
        private const int SaltSize = 16;
        private const int KeySize = 32;
        private const int Iterations = 10000;
        private static readonly HashAlgorithmName _hashAlgorithm = HashAlgorithmName.SHA512;
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            passwordSalt = RandomNumberGenerator.GetBytes(SaltSize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                passwordSalt,
                Iterations,
                _hashAlgorithm,
                KeySize
                );
            passwordHash = hash;
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(
                password,
                passwordSalt,
                Iterations,
                _hashAlgorithm,
                KeySize
                );

            return CryptographicOperations.FixedTimeEquals(hashToCompare, passwordHash);
        }
    }
}
