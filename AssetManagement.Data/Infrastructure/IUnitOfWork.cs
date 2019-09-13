using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
