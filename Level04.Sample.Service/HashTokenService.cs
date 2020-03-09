using Level04.Sample.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level04.Sample.Service
{
    public class HashTokenService : IHashTokenService
    {
        /// <summary>
        /// Gets the random.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns>System.String.</returns>
        public string GetRandom(string account)
        {
            var seed = new Random((int)SystemTime.Now.Ticks & 0x0000FFFF);
            var result = seed.Next(0, 999999);
            return result.ToString("000000");
        }
    }
}