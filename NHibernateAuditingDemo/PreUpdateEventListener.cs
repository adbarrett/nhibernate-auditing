namespace NHibernateAuditingDemo
{
    using System.Threading;
    using System.Threading.Tasks;
    using NHibernate.Event;

    public class PreUpdateEventListener : IPreUpdateEventListener
    {
        public bool OnPreUpdate(PreUpdateEvent e)
        {
            if (e.OldState != null && e.State != null)
                AuditEventListenerHelper.UpdateAuditTrail(
                    e.OldState, e.State, e.Entity,
                    e.Id.ToString(), e.Persister.PropertyNames, "UPDATE");

            return false;
        }

        public async Task<bool> OnPreUpdateAsync(PreUpdateEvent @event, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await Task.FromResult(OnPreUpdate(@event));
        }
    }
}
