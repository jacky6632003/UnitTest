using Level05.Sample.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Level05.Sample.Service
{
    public class AuthenticationService
    {
        private readonly IProfileRepository _profileRepository;

        private readonly IHashTokenService _hashTokenService;

        private readonly ILog _log;

        public AuthenticationService(IProfileRepository profileRepository,
                                     IHashTokenService hashTokenService,
                                     ILog log)
        {
            this._profileRepository = profileRepository;
            this._hashTokenService = hashTokenService;
            this._log = log;
        }

        /// <summary>
        /// Determines whether the specified account is valid.
        /// </summary>
        /// <param name="account">The account.</param>
        /// <param name="validateCode">The validate code.</param>
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

            if (!isValid)
            {
                // TODO: 如何驗證當有非法登入的情況發生時，有正確地記錄log？
                var content = $"account:{account} try to login failed";
                this._log.Save(content);
            }

            return isValid;
        }
    }
}