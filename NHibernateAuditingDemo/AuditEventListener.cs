namespace NHibernateAuditingDemo
{
    using System;
    using System.Threading;
    using NHibernate;

    public static class AuditEventListenerHelper
    {
        public static void UpdateAuditTrail(object[] oldState, object[] newState,
            object entity, string id, string[] propertyNames, string action)
        {
            if (!(entity is IAuditable))
                return;

            ISessionFactory sessionFactory = NHibernateSessionFactory.GetSessionFactory();
            using (ISession auditSession = sessionFactory.OpenSession())
            using (ITransaction auditTransaction = auditSession.BeginTransaction())
            {
                var auditLog = new AuditLog
                {
                    Id = Guid.NewGuid().ToString(),
                    Username = Thread.CurrentPrincipal.Identity.Name ?? "Unknown",
                    Action = action,
                    Timestamp = DateTime.Now,
                    TableName = entity.GetType().Name,
                    RecordId = id
                };

                auditSession.Save(auditLog);

                for (var i = 0; i < newState.Length; i++)
                {
                    string newValue = GetValueString(newState[i]);
                    string oldValue = GetValueString(oldState[i]);

                    if (newValue == oldValue)
                        continue;

                    var auditLogDetail = new AuditLogDetail
                    {
                        Id = Guid.NewGuid().ToString(),
                        AuditLog = auditLog,
                        FieldName = propertyNames[i],
                        OldValue = oldValue,
                        NewValue = newValue
                    };

                    auditSession.Save(auditLogDetail);
                }

                auditTransaction.Commit();
            }
        }

        private static string GetValueString(object value)
        {
            if (value == null)
                return null;

            string type = value.GetType().Name.Replace("Proxy", "");
            switch (type)
            {
                case "Department":
                    return (value as Department).Id.ToString();
                default:
                    return value.ToString();
            }
        }
    }
}
