using System;
using System.Collections.Generic;
using System.Text;

namespace Level04.Sample.Repository
{
    public interface IProfileRepository
    {
        /// <summary>
        /// Gets the password.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns>System.String.</returns>
        string GetPassword(string account);
    }
}