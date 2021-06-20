using System.Threading;

namespace WinFormsAsync
{
    public class ContextAwaiter
    {
        private readonly SynchronizationContext context;

        public ContextAwaiter(SynchronizationContext context = null)
        {
            if (context == null)
            {
                context = SynchronizationContext.Current;
            }
            this.context = context;
        }

        public NotifyCompletion GetAwaiter()
        {
            return new NotifyCompletion(context);
        }
    }
}