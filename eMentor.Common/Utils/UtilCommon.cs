using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using static eMentor.Common.Utils.UtilEnum;

namespace eMentor.Common.Utils
{
    public static class UtilCommon
    {
        static bool invalid = false;
        static SymmetricSecurityKey _secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.API_KEY));
        static string Key { get; set; } = "A!9HHhi%XjjYY4YP2@Nob009X";
        public static bool IsValidEmail(string email)
        {
            invalid = false;

            if (string.IsNullOrEmpty(email)) return false;

            try
            {
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {

                return false;
            }

            if (invalid)
                return false;

            try
            {
                return Regex.IsMatch(email,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {

                return false;
            }
        }

        public static bool IsValidPhone(string Phone)
        {
            try
            {
                if (string.IsNullOrEmpty(Phone))
                    return false;
                var r = new Regex(@"(^\+[0-9]{2}|^\+[0-9]{2}\(0\)|^\(\+[0-9]{2}\)\(0\)|^00[0-9]{2}|^0)([0-9]{9}$|[0-9\-\s]{10}$)");
                return r.IsMatch(Phone);

            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public static bool IsValidPassword(string password)
        {
            try
            {
                if (string.IsNullOrEmpty(password))
                    return false;
                var r = new Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,12}$");
                return r.IsMatch(password);
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        private static string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }

        public static string GenerateToken(string id, int exp, UserRole role)
        {
            var claims = new Claim[] {
                new Claim(ClaimTypes.Name, id),
                new Claim("Role", ((int)role).ToString()),
                new Claim(ClaimTypes.Role, role.ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, $"{new DateTimeOffset(DateTime.UtcNow.AddDays(exp == 0? 1: exp)).ToUnixTimeSeconds()}"),
                new Claim(JwtRegisteredClaimNames.Nbf, $"{new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds()}")};

            var token = new JwtSecurityToken(
                issuer: Constants.API_ISSUER,
                audience: Constants.API_CLIENT,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(exp),
                signingCredentials: new SigningCredentials(_secretKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public static string GeneratePasscode(string passcode, string salt)
        {
            byte[] plainTextWithSaltBytes = Encoding.UTF8.GetBytes(passcode + salt);
            HashAlgorithm algorithm = new SHA256Managed();
            var buffer = algorithm.ComputeHash(plainTextWithSaltBytes);
            return Convert.ToBase64String(buffer);
        }

        public static string ImageUpload(string folderDir, IFormFile uploadedFile)
        {
            string fileName = null;

            if (uploadedFile != null && uploadedFile.Length > 0)
            {
                fileName = Guid.NewGuid().ToString() + "." + uploadedFile.FileName.Split('.').LastOrDefault();

                var path = Path.Combine(Directory.GetCurrentDirectory(), folderDir);
                Directory.CreateDirectory(path);

                var filePath = Path.Combine(folderDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    uploadedFile.CopyTo(fileStream);
                }
            }

            return fileName;
        }

        public static string GetDisplayImageUrl(string imageName)
        {
            if (string.IsNullOrEmpty(imageName))
                return string.Empty;
            return Path.Combine(Constants.ImageDisplayPrefix, imageName);
        }

        public static string EncryptMD5(string text)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        byte[] textBytes = UTF8Encoding.UTF8.GetBytes(text);
                        byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                        return Convert.ToBase64String(bytes, 0, bytes.Length);
                    }
                }
            }
        }
        public static string EncryptMD5(object obj)
        {
            var text = JsonConvert.SerializeObject(obj);
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateEncryptor())
                    {
                        byte[] textBytes = UTF8Encoding.UTF8.GetBytes(text);
                        byte[] bytes = transform.TransformFinalBlock(textBytes, 0, textBytes.Length);
                        return Convert.ToBase64String(bytes, 0, bytes.Length);
                    }
                }
            }
        }
        public static string DecryptMD5(string cipher)
        {
            using (var md5 = new MD5CryptoServiceProvider())
            {
                using (var tdes = new TripleDESCryptoServiceProvider())
                {
                    tdes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(Key));
                    tdes.Mode = CipherMode.ECB;
                    tdes.Padding = PaddingMode.PKCS7;

                    using (var transform = tdes.CreateDecryptor())
                    {
                        byte[] cipherBytes = Convert.FromBase64String(cipher);
                        byte[] bytes = transform.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
                        return UTF8Encoding.UTF8.GetString(bytes);
                    }
                }
            }
        }
    }
}
