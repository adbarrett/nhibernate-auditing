using FluentNHibernate.Mapping;
using NHibernateAuditingDemo.Models;

namespace NHibernateAuditingDemo.NHibernate.Mappings
{
    public class AuditLogDetailMapping : ClassMap<AuditLogDetail>
    {
        public AuditLogDetailMapping()
        {
            Table("AuditLogDetails");
            Id(x => x.Id);
            References(x => x.AuditLog);
            Map(x => x.FieldName);
            Map(x => x.OldValue);
            Map(x => x.NewValue);
        }
    }
}
