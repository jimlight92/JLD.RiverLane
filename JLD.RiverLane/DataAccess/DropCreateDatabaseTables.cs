using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Xml;

namespace JLD.RiverLane.DataAccess
{
    public class DropCreateDatabaseTables<TContext> : IDatabaseInitializer<TContext> where TContext : DbContext
    {
        public void InitializeDatabase(TContext context)
        {

            if (context.Database.Exists())
            {
                if (ModelHasChanged(context))
                {
                    this.ClearDatabase(context);
                    CreateModelTables(context);
                    this.CreateMetaDataTable(context);
                    Seed(context);
                    context.SaveChanges();
                }
            }
            else
            {
                string dbName = context.Database.Connection.Database;
                string error = String.Format("Database {0} does not exist!", dbName);

                throw new DataMisalignedException(error);
            }
        }

        private bool ModelHasChanged(TContext context)
        {
            return !context.Database.CompatibleWithModel(true);
        }

        private void ClearDatabase(TContext context)
        {
            try
            {
                context.Database.ExecuteSqlCommand("DROP TABLE  __MigrationHistory");
            }
            catch { }

            List<string> tableNames = context.Database.SqlQuery<string>("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_NAME NOT LIKE '%Migration%' AND TABLE_NAME NOT LIKE 'AspNet%'").ToList();

            for (int i = 0; tableNames.Count > 0; i++)
            {
                try
                {
                    context.Database.ExecuteSqlCommand(string.Format("DROP TABLE {0}", tableNames.ElementAt(i % tableNames.Count)));
                    tableNames.RemoveAt(i % tableNames.Count);
                    i = -1; //flag: a table was removed. in the next iteration i++ will be the 0 index.
                }
                catch (System.Data.SqlClient.SqlException e) // ignore errors as these are expected due to linked foreign key data 
                {
                    if ((i % tableNames.Count) == (tableNames.Count - 1))
                    {
                        //end of tables-list without any success to delete any table, then exit with exception:
                        throw new System.Data.DataException("Unable to clear all relevant tables in database (foriegn key constraint ?). See inner-exception for more details.", e);
                    }

                }

            }

        }

        private void CreateModelTables(TContext context)
        {
            var dbCreationScript = ((IObjectContextAdapter)context).ObjectContext.CreateDatabaseScript();
            context.Database.ExecuteSqlCommand(dbCreationScript);
        }

        private void CreateMetaDataTable(TContext context)
        {
            // create meta data table DDL
            string sql = @"CREATE TABLE dbo.__MigrationHistory (
                                MigrationId NVARCHAR(255) NOT NULL,
                                CreatedOn DATETIME NOT NULL,
                                Model VARBINARY(MAX) NOT NULL,
                                ProductVersion NVARCHAR(32) NOT NULL);
  
                            ALTER TABLE dbo.__MigrationHistory ADD PRIMARY KEY (MigrationId);
  
                            INSERT INTO dbo.__MigrationHistory (MigrationId, CreatedOn, Model, ProductVersion)
                            VALUES ('InitialCreate', GetDate(), @p0, @p1);";

            // execute SQL command
            context.Database.ExecuteSqlCommand(sql, GetModel(context), GetProductVersion());
        }

        private byte[] GetModel(TContext context)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var gzipStream = new GZipStream(memoryStream, CompressionMode.Compress))
                {
                    using (var xmlWriter = XmlWriter.Create(gzipStream, new XmlWriterSettings { Indent = true }))
                    {
                        EdmxWriter.WriteEdmx(context, xmlWriter);
                    }
                }

                return memoryStream.ToArray();
            }
        }

        private string GetProductVersion()
        {
            return typeof(DbContext).Assembly
                                    .GetCustomAttributes(false)
                                    .OfType<AssemblyInformationalVersionAttribute>()
                                    .Single()
                                    .InformationalVersion;
        }

        protected virtual void Seed(TContext context)
        {
            /// Let your Database Initializer class handle the seeding of data
        }
    }
}