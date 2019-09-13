using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)

        {

            this._dbContext = dbContext;

        }

        public ApplicationDbContext DbContext

        {

            get { return _dbContext; }

        }

        public void Commit()

        {

            try

            {

                DbContext.SaveChanges();

            }

            catch (Exception ex)

            {

                throw ex;

            }

        }
    }
}
