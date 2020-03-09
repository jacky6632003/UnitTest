using System;
using System.Collections.Generic;
using System.Text;

namespace Level04.Sample.Service
{
    public interface IHashTokenService
    {
        /// <summary>
        /// Gets the random.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns>System.String.</returns>
        string GetRandom(string account);
    }
}