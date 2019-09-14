using AssetManagement.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AssetManagement.Data.Infrastructure
{
    public  class RepositoryBase<T>:IRepository<T> where T : BaseEntity
    {
        #region Properties

        private ApplicationDbContext _dataContext;
        private readonly IUnitOfWork _unitOfWork;

        private readonly DbSet<T> dbSet;

        protected ApplicationDbContext DbContext

        {

            get { return _dataContext; }

        }

        #endregion

        public RepositoryBase(ApplicationDbContext dbContext)

        {

            _dataContext = dbContext;

            dbSet = DbContext.Set<T>();
            _unitOfWork = new UnitOfWork(dbContext);

        }

        #region Implementation

        public virtual void Add(T entity)

        {

            dbSet.Add(entity);
            _unitOfWork.Commit();

        }

        public virtual void Update(T entity)

        {

            dbSet.Attach(entity);

            _dataContext.Entry(entity).State = EntityState.Modified;
            _unitOfWork.Commit();
        }

        public virtual void Delete(T entity)

        {

            dbSet.Remove(entity);
            _unitOfWork.Commit();
        }

        public virtual void Delete(Expression<Func<T, bool>> where)

        {

            IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();

            foreach (T obj in objects)
                dbSet.Remove(obj);

            _unitOfWork.Commit();
        }

        public virtual T GetById(long id, params string[] navigations)

        {

            var set = dbSet.AsQueryable();

            foreach (string nav in navigations)

                set = set.Include(nav);


            return set.FirstOrDefault(f => f.Id == id);

        }

        public virtual IEnumerable<T> GetAll(params string[] navigations)

        {

            var set = dbSet.AsQueryable();

            foreach (string nav in navigations)

                set = set.Include(nav);

            return set.AsEnumerable();

        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where, params string[] navigations)

        {

            var set = dbSet.AsQueryable();

            foreach (string nav in navigations)

                set = set.Include(nav);

            return set.Where(where).AsEnumerable();

        }

        public T Get(Expression<Func<T, bool>> where, params string[] navigations)

        {

            var set = dbSet.AsQueryable();

            foreach (string nav in navigations)

                set = set.Include(nav);

            return set.Where(where).FirstOrDefault<T>();

        }

        #endregion

    }
}

