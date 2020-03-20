using MyMechanic.DataNHibernate.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace MyMechanic.DataNHibernate
{
    public class FhConfig
    {
        public static ISessionFactory CreateSessionFactory()
        {
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyMechanic;Integrated Security=SSPI")
                    .ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<UserMap>())

                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(true, true))
                .BuildSessionFactory();

            return sessionFactory;
        }
    }
}