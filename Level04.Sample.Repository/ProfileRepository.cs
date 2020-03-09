using System;
using System.Collections.Generic;
using System.Text;

namespace Level04.Sample.Repository
{
    public class ProfileRepository : IProfileRepository
    {
        /// <summary>
        /// Gets the password.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <returns>System.String.</returns>
        public string GetPassword(string account)
        {
            var result = DataContext.GetPassword(account);
            return result;
        }
    }
}