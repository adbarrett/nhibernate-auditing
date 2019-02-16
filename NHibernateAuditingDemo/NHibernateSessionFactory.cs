namespace NHibernateAuditingDemo
{
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using FluentNHibernate.Conventions.Helpers;
    using NHibernate;
    using NHibernate.Event;
    using NHibernate.Tool.hbm2ddl;

    public static class NHibernateSessionFactory
    {
        public static ISessionFactory GetSessionFactory()
        {
            return Fluently.Configure()
                .Database(
                    MsSqlConfiguration.MsSql2012.ConnectionString(
                        x => x.FromConnectionStringWithKey("NHibernateAuditing")))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<AuditLogMapping>()
                    .Conventions.Add(ForeignKey.EndsWith("Id")))
                .ExposeConfiguration(config =>
                {
                    new SchemaUpdate(config).Execute(false, true);
                    config.EventListeners.PreInsertEventListeners =
                        new IPreInsertEventListener[]
                            { new PreInsertEventListener() };
                    config.EventListeners.PreUpdateEventListeners =
                        new IPreUpdateEventListener[]
                            { new PreUpdateEventListener() };
                    config.EventListeners.PreDeleteEventListeners =
                        new IPreDeleteEventListener[]
                            { new PreDeleteEventListener() };
                })
                .BuildSessionFactory();
        }
    }
}
