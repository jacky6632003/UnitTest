using System;
using System.Collections.Generic;
using System.Text;

namespace Level05.Sample.Repository
{
    public interface IProfileRepository
    {
        string GetPassword(string account);
    }
}