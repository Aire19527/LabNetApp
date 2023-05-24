using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Common.Helpers
{
    public static class Utils
    {
        public static double ConvertToUnixTimestamp(DateTime date)
        {
            DateTime origin = DateTime.UtcNow;
            TimeSpan diff = date.ToUniversalTime() - origin;
            return Math.Floor(diff.TotalSeconds);
        }

        public static String PassEncrypt(string str)
        {
            string passEncriptada = BCrypt.Net.BCrypt.HashPassword(str);
            return passEncriptada;
        }

        public static bool VerifyPassword(string enteredPassword, string hashedPassword)
        {
            return (BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPassword));


        }

        public static bool IsValidPassword(string password)
        {
            var validationAttribute = new ValidPasswordAttribute();
            return validationAttribute.IsValid(password);
        }

        /// <summary>
        /// Method to get value claim from JwtToken
        /// </summary>
        /// <param name="authorization"> Request.Headers["Authorization"] </param>
        /// <param name="claim"></param>
        /// <returns></returns>
        public static string GetClaimValue(string token, string claim)
        {
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            string authHeader = token.Replace("Bearer ", "").Replace("bearer ", "");
            JwtSecurityToken tokenS = handler.ReadToken(authHeader) as JwtSecurityToken;

            Claim claimData = tokenS.Claims.FirstOrDefault(cl => cl.Type.ToUpper() == claim.ToUpper());

            if (claimData == null || string.IsNullOrEmpty(claimData.Value))
                throw new UnauthorizedAccessException();

            return claimData.Value;
        }
    }


}
