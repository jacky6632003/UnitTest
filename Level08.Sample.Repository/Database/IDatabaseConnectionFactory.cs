using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Level08.Sample.Repository.Database
{
    public interface IDatabaseConnectionFactory
    {
        IDbConnection Create();
    }
}