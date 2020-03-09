using Level04.Sample.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level04.Sample.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IProfileRepository _profileRepository;

        private readonly IHashTokenService _hashTokenService;

        public AuthenticationService(IProfileRepository profileRepository,
                                     IHashTokenService hashTokenService)
        {
            this._profileRepository = profileRepository;
            this._hashTokenService = hashTokenService;
        }

        /// <summary>
        /// Determines whether the specified account is valid.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <param name="validateCode">The password.</param>
        /// <returns><c>true</c> if the specified account is valid; otherwise, <c>false</c>.</returns>
        public bool IsValid(string account, string validateCode)
        {
            // 根據 account 取得自訂密碼
            var passwordFromDataContext = this._profileRepository.GetPassword(account);

            // 根據 account 取得 Hash Token 目前的亂數
            var randomCode = this._hashTokenService.GetRandom(account);

            // 驗證傳入的 validateCode 是否等於自訂密碼 + Hash Token 亂數
            var validPassword = string.Concat(passwordFromDataContext, randomCode);
            var isValid = validateCode.Equals(validPassword);

            return isValid;
        }
    }
}