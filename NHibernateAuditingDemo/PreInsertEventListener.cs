namespace NHibernateAuditingDemo
{
    using System.Threading;
    using System.Threading.Tasks;
    using NHibernate.Event;

    public class PreInsertEventListener : IPreInsertEventListener
    {
        public bool OnPreInsert(PreInsertEvent e)
        {
            if (e.State != null)
                AuditEventListenerHelper.UpdateAuditTrail(
                    new object[e.State.Length], e.State, e.Entity,
                    e.Id.ToString(), e.Persister.PropertyNames, "INSERT");

            return false;
        }

        public async Task<bool> OnPreInsertAsync(PreInsertEvent @event, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await Task.FromResult(OnPreInsert(@event));
        }
    }
}
