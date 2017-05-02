﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutofacDemo.Core;
using System.Data.Entity.Infrastructure;
using System.Data.Common;
using System.Data;
using AutofacDemo.Core.Data;
using AutofacDemo.Data.Mapping;
using AutofacDemo.Core.Domain;

namespace AutofacDemo.Data
{
    public class ObjectContext : DbContext
    {
        public ObjectContext() : base ("conn")
        {

        }

        public DbSet<Logs> LogList { get; set; }

        public DbSet<User> UserList { get; set; }

        #region Utilities

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new LogMap());
            base.OnModelCreating(modelBuilder);
        }

        //protected virtual TEntity AttachEntityToContext<TEntity>(TEntity entity) where TEntity : BaseEntity, new()
        //{
        //    //little hack here until Entity Framework really supports stored procedures
        //    //otherwise, navigation properties of loaded entities are not loaded until an entity is attached to the context
        //    var alreadyAttached = Set<TEntity>().Local.FirstOrDefault(x => x.Id == entity.Id);
        //    if (alreadyAttached == null)
        //    {
        //        //attach new entity
        //        Set<TEntity>().Attach(entity);
        //        return entity;
        //    }

        //    //entity is already loaded
        //    return alreadyAttached;
        //}

        #endregion

        //#region Methods

        //public string CreateDatabaseScript()
        //{
        //    return ((IObjectContextAdapter)this).ObjectContext.CreateDatabaseScript();
        //}

        //public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        //{
        //    return base.Set<TEntity>();
        //}

        //public IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : BaseEntity, new()
        //{
        //    //add parameters to command
        //    if (parameters != null && parameters.Length > 0)
        //    {
        //        for (int i = 0; i <= parameters.Length - 1; i++)
        //        {
        //            var p = parameters[i] as DbParameter;
        //            if (p == null)
        //                throw new Exception("Not support parameter type");

        //            commandText += i == 0 ? " " : ", ";

        //            commandText += "@" + p.ParameterName;
        //            if (p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Output)
        //            {
        //                //output parameter
        //                commandText += " output";
        //            }
        //        }
        //    }

        //    var result = this.Database.SqlQuery<TEntity>(commandText, parameters).ToList();

        //    //performance hack applied as described here - http://www.nopcommerce.com/boards/t/25483/fix-very-important-speed-improvement.aspx
        //    bool acd = this.Configuration.AutoDetectChangesEnabled;
        //    try
        //    {
        //        this.Configuration.AutoDetectChangesEnabled = false;

        //        for (int i = 0; i < result.Count; i++)
        //            result[i] = AttachEntityToContext(result[i]);
        //    }
        //    finally
        //    {
        //        this.Configuration.AutoDetectChangesEnabled = acd;
        //    }

        //    return result;
        //}

        //public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        //{
        //    return this.Database.SqlQuery<TElement>(sql, parameters);
        //}

        //public int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters)
        //{
        //    int? previousTimeout = null;
        //    if (timeout.HasValue)
        //    {
        //        //store previous timeout
        //        previousTimeout = ((IObjectContextAdapter)this).ObjectContext.CommandTimeout;
        //        ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = timeout;
        //    }

        //    var transactionalBehavior = doNotEnsureTransaction
        //        ? TransactionalBehavior.DoNotEnsureTransaction
        //        : TransactionalBehavior.EnsureTransaction;
        //    var result = this.Database.ExecuteSqlCommand(transactionalBehavior, sql, parameters);

        //    if (timeout.HasValue)
        //    {
        //        //Set previous timeout back
        //        ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = previousTimeout;
        //    }

        //    //return result
        //    return result;
        //}

        //public void Detach(object entity)
        //{
        //    if (entity == null)
        //        throw new ArgumentNullException("entity");

        //    ((IObjectContextAdapter)this).ObjectContext.Detach(entity);
        //}

        //#endregion

        //#region Properties

        //public virtual bool ProxyCreationEnabled
        //{
        //    get
        //    {
        //        return this.Configuration.ProxyCreationEnabled;
        //    }
        //    set
        //    {
        //        this.Configuration.ProxyCreationEnabled = value;
        //    }
        //}

        //public virtual bool AutoDetectChangesEnabled
        //{
        //    get
        //    {
        //        return this.Configuration.AutoDetectChangesEnabled;
        //    }
        //    set
        //    {
        //        this.Configuration.AutoDetectChangesEnabled = value;
        //    }
        //}

        //#endregion

    }
}
