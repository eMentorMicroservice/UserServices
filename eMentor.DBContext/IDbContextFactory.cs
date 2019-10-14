using System;
using System.Collections.Generic;
using System.Text;

namespace eMentor.DBContext
{
    public interface IDbContextFactory
    {
        EMentorContext CreateDbContext();
    }
}
