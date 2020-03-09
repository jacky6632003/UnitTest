using System;
using System.Collections.Generic;
using System.Text;

namespace Level05.Sample.Service
{
    public interface IHashTokenService
    {
        string GetRandom(string account);
    }
}