namespace NHibernateAuditingDemo
{
    using FluentNHibernate.Mapping;

    public class AuditLogMapping : ClassMap<AuditLog>
    {
        public AuditLogMapping()
        {
            Table("AuditLogs");
            Id(x => x.Id);
            Map(x => x.Username);
            Map(x => x.Action);
            Map(x => x.Timestamp);
            Map(x => x.TableName);
            Map(x => x.RecordId);
            HasMany(x => x.AuditLogDetails);
        }
    }
}
