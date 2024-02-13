
namespace OptimisationEvents.ObserverPattern
{
    public interface IObservableObject
    {
        event Action<ObservableObject, string>? Notifier;
    }
}