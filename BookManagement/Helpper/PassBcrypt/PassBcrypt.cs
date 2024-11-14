namespace BookManagement.Helpper.PassBcrypt
{
    public static class PassBcrypt
    {
        /// <summary>
        /// Hashing a Password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string EnhancedHashPassword(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password, 13);
        }
        /// <summary>
        /// Verifying a Hashed Password
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordHash"></param>
        /// <returns></returns>
        public static bool VerifyEnhanced(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify("Secret Password", passwordHash);
        }
    }
}