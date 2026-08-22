using System;
using System.Security.Cryptography;
using System.Text;

namespace Server.Services
{
    public static class PasswordHasher
    {
        private const int SaltSize = 16; // 128-bit
        private const int HashSize = 32;  // 256-bit
        private const int Iterations = 60000; // 60,000 تكرار

        public static string HashPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("كلمة المرور لا يمكن أن تكون فارغة.", nameof(password));

            // إنشاء الملح (Salt)
            byte[] salt = GenerateSalt();

            // إنشاء الهاش باستخدام خوارزمية PBKDF2 مع SHA-256
            byte[] hash = GenerateHash(password, salt);

            // دمج الملح والهاش للتخزين
            byte[] combinedBytes = CombineSaltAndHash(salt, hash);

            return Convert.ToBase64String(combinedBytes);
        }

        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            if (string.IsNullOrWhiteSpace(enteredPassword))
                throw new ArgumentException("كلمة المرور المدخلة فارغة.", nameof(enteredPassword));

            if (string.IsNullOrWhiteSpace(storedHash))
                throw new ArgumentException("الهاش المخزن غير صالح.", nameof(storedHash));

            // استخراج الملح والهاش من القيمة المخزنة
            byte[] storedBytes = Convert.FromBase64String(storedHash);
            if (storedBytes.Length != SaltSize + HashSize)
                throw new ArgumentException("تنسيق الهاش المخزن غير صحيح.");

            byte[] salt = new byte[SaltSize];
            byte[] storedHashBytes = new byte[HashSize];
            Buffer.BlockCopy(storedBytes, 0, salt, 0, SaltSize);
            Buffer.BlockCopy(storedBytes, SaltSize, storedHashBytes, 0, HashSize);

            // حساب هاش كلمة المرور المدخلة
            byte[] enteredHash = GenerateHash(enteredPassword, salt);

            // مقارنة الهاشات بطريقة آمنة
            return SafeCompare(enteredHash, storedHashBytes);
        }

        // ===== الدوال المساعدة =====
        private static byte[] GenerateSalt()
        {
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        private static byte[] GenerateHash(string password, byte[] salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(
                password: password,
                salt: salt,
                iterations: Iterations,
                hashAlgorithm: HashAlgorithmName.SHA256))
            {
                return pbkdf2.GetBytes(HashSize);
            }
        }

        private static byte[] CombineSaltAndHash(byte[] salt, byte[] hash)
        {
            byte[] combined = new byte[SaltSize + HashSize];
            Buffer.BlockCopy(salt, 0, combined, 0, SaltSize);
            Buffer.BlockCopy(hash, 0, combined, SaltSize, HashSize);
            return combined;
        }

        // دالة مقارنة آمنة ضد هجمات التوقيت
        private static bool SafeCompare(byte[] a, byte[] b)
        {
            if (a.Length != b.Length) return false;

            int result = 0;
            for (int i = 0; i < a.Length; i++)
            {
                result |= a[i] ^ b[i]; // استخدام XOR وتجميع النتائج
            }
            return result == 0;
        }
    }

    //    public class PasswordHasher
    //{
    //    public static string HashPassword(string password)
    //    {
    //        using (SHA256 sha256 = SHA256.Create())
    //        {
    //            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
    //            return Convert.ToBase64String(hashBytes);
    //        }
    //    }
    //    public static bool VerifyPassword(string enteredPassword, string storedHash)=>HashPassword(enteredPassword)==storedHash;


    //}

}