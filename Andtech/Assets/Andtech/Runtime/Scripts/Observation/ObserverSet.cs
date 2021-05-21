using System.Collections.Generic;

namespace Andtech {

	public class ObserverSet<T> {
		public T Subject {
			get => subject;
			private set {
				var oldValue = Subject;
				var newValue = value;
				var same = ReferenceEquals(newValue, oldValue);
				if (same)
				{
					return;
				}

				if (oldValue != null) {
					foreach (var observer in observers)
					{
						observer.OnUnregister(oldValue);
					}
				}
				subject = newValue;
				if (newValue != null) {
					foreach (var observer in observers)
					{
						observer.OnRegister(Subject);
					}
				}
			}
		}
		public bool HasSubject => Subject != null;

		private T subject;

		private readonly HashSet<IObserver<T>> observers = new HashSet<IObserver<T>>();

		public void Set(T instance) {
			if (HasSubject)
			{
				return;
			}

			Subject = instance;
		}

		public void Clear(T instance) {
			if (instance.Equals(Subject))
			{
				Subject = default;
			}
		}

		public void Clear() => observers.Clear();

		/// <summary>
		/// Adds an observer.
		/// </summary>
		/// <param name="observer">The observer to add.</param>
		/// <returns>The observer was successfully added.</returns>
		/// <remarks>The observer will be immediately receive registration callbacks if the subject is already enabled.</remarks>
		public bool Add(IObserver<T> observer) {
			if (!observers.Add(observer))
			{
				return false;
			}

			// Late registration
			//	If the observer is added while the subject is enabled, let observer respond to the registration.
			if (HasSubject)
			{
				observer.OnRegister(Subject);
			}

			return true;
		}

		/// <summary>
		/// Removes an observer.
		/// </summary>
		/// <param name="observer">The observer to remove.</param>
		/// <returns>The observer was successfully removed.</returns>
		/// <remarks>The observer will be immediately receive registration callbacks if the subject is currently enabled.</remarks>
		public bool Remove(IObserver<T> observer) {
			if (!observers.Remove(observer))
			{
				return false;
			}

			if (HasSubject)
			{
				observer.OnUnregister(Subject);
			}

			return true;
		}
	}
}
