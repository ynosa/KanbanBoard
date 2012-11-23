using System;
namespace KanbanBoard
{
    using System.ServiceModel.DomainServices.Client;
    using System.Threading.Tasks;

    public static class AsyncExtensions
    {
        public static Task<SubmitOperation> SubmitChangesAsync(this DomainContext context)
        {
            var t = new TaskCompletionSource<SubmitOperation>();            
            context.SubmitChanges(obj => t.TrySetResult(obj), null);            
            return t.Task;
        }
    }
}
