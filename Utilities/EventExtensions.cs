namespace Utilities
{
    public static class EventExtensions
    {
        public static bool IsRegistered<T>(this EventHandler<T> eventHandler, Delegate toAdd)
        {
            return eventHandler != null && !eventHandler.GetInvocationList().Contains(toAdd);
        }
    }
}
