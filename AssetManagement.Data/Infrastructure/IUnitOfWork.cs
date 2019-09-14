using AssetManagement.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Data.Infrastructure
{

    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;

        void Commit();
    }

    //public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    //{
    //    TContext Context { get; }
    //}
}
