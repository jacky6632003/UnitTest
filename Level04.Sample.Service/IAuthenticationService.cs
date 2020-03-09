using System;
using System.Collections.Generic;
using System.Text;

namespace Level04.Sample.Service
{
    public interface IAuthenticationService
    {
        /// <summary>
        /// Determines whether the specified account is valid.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <param name="validateCode">The password.</param>
        /// <returns><c>true</c> if the specified account is valid; otherwise, <c>false</c>.</returns>
        bool IsValid(string account, string validateCode);
    }
}