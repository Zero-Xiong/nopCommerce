using Nop.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Plugin.Widgets.PromoSilder.Domain;

namespace Nop.Plugin.Widgets.PromoSilder.Data
{
    public class PromoSilderDbContext: DbContext, IDbContext
    {
        public PromoSilderDbContext(string nameOrConnectionString) 
            : base(nameOrConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PromoSilderMap());
            modelBuilder.Configurations.Add(new PromoSilderImageMap());

            base.OnModelCreating(modelBuilder);
        }

        public string CreateDatabaseInstallationScript()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateDatabaseScript();
        }

        public void Install()
        {
            Database.SetInitializer<PromoSilderDbContext>(null);

            Database.ExecuteSqlCommand(this.CreateDatabaseInstallationScript());

            SaveChanges();
        }

        public void UnInstall()
        {
            var tableNameSilder = this.GetTableName<PromoSilderRecord>();
            var tableNameSilderImage = this.GetTableName<PromoSilderImageRecord>();

            this.DropPluginTable(tableNameSilderImage);
            this.DropPluginTable(tableNameSilder);
            
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        public bool ProxyCreationEnabled
        {
            get
            {
                return this.Configuration.ProxyCreationEnabled;
                //throw new NotImplementedException();
            }

            set
            {
                this.Configuration.ProxyCreationEnabled = value;
                //throw new NotImplementedException();
            }
        }

        public bool AutoDetectChangesEnabled
        {
            get
            {
                return this.Configuration.AutoDetectChangesEnabled;
                //throw new NotImplementedException();
            }

            set
            {
                this.Configuration.AutoDetectChangesEnabled = value;
                //throw new NotImplementedException();
            }
        }

        public IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : BaseEntity, new()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = default(int?), params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Detach(object entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            ((IObjectContextAdapter)this).ObjectContext.Detach(entity);
        }
    }
}
