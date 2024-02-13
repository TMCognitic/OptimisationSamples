using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimisationEvents.ObserverPattern
{
    public abstract class ObservableObject : IObservableObject
    {
        public event Action<ObservableObject, string>? Notifier;

        protected void Set<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return;

            field = value;
            Notify(propertyName);
        }

        protected void Notify(string propertyName)
        {
            Notifier?.Invoke(this, propertyName);
        }
    }
}
