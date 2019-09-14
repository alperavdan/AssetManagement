using System;
using System.Collections.Generic;
using System.Text;
using AssetManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace AssetManagement.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        public ApplicationDbContext _Context { get; }
        private Dictionary<Type, object> _repositories;

        public UnitOfWork(ApplicationDbContext dbContext)

        {

           _Context = dbContext;

        }



        public void Dispose()
        {
            _Context.Dispose();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            if(_repositories == null) _repositories = new Dictionary<Type, object>();

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type)) _repositories[type] = new RepositoryBase<TEntity>(_Context);
            return (IRepository<TEntity>)_repositories[type];
        }

        public void Commit()
        {

            try

            {

                _Context.SaveChanges();

            }

            catch (Exception ex)

            {

                throw ex;

            }

        }
    }
}
