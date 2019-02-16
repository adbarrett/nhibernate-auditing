using System.Threading;
using System.Threading.Tasks;
using NHibernate.Event;

namespace NHibernateAuditingDemo.NHibernate.EventListeners
{
    public class PreDeleteEventListener : IPreDeleteEventListener
    {
        public bool OnPreDelete(PreDeleteEvent e)
        {
            if (e.DeletedState != null)
                AuditEventListenerHelper.UpdateAuditTrail(
                    e.DeletedState, new object[e.DeletedState.Length], e.Entity,
                    e.Id.ToString(), e.Persister.PropertyNames, "DELETE");

            return false;
        }

        public async Task<bool> OnPreDeleteAsync(PreDeleteEvent @event, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return await Task.FromResult(OnPreDelete(@event));
        }
    }
}
