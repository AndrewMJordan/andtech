using System.Collections.Generic;

namespace Andtech
{

	public class ObserverSet<T>
	{
		public T Subject
		{
			get => subject;
			private set
			{
				var oldValue = Subject;
				var newValue = value;
				var same = ReferenceEquals(newValue, oldValue);
				if (same)
				{
					return;
				}

				Lock();
				if (oldValue != null)
				{
					foreach (var observer in observers)
					{
						try
						{
							observer.OnUnregister(oldValue);
						}
						catch { }
					}
				}
				subject = newValue;
				if (newValue != null)
				{
					foreach (var observer in observers)
					{
						try
						{
							observer.OnRegister(newValue);
						}
						catch { }
					}
				}
				Unlock();
				observers.Flush();
			}
		}
		public bool HasSubject => Subject != null;

		private bool isLocked;
		private T subject;
		private readonly DeferCollection<IObserver<T>> observers;

		public ObserverSet()
		{
			var hashSet = new HashSet<IObserver<T>>();
			observers = new DeferCollection<IObserver<T>>(hashSet);
		}

		public void Set(T instance)
		{
			if (!HasSubject)
			{
				Subject = instance;
			}
		}

		public void Clear(T instance)
		{
			if (ReferenceEquals(instance, Subject))
			{
				Subject = default;
			}
		}

		/// <summary>
		/// Clears the list of observers.
		/// </summary>
		public void Clear() => observers.Clear();

		/// <summary>
		/// Adds an observer.
		/// </summary>
		/// <param name="observer">The observer to add.</param>
		/// <returns>The observer was successfully added.</returns>
		/// <remarks>The observer will be immediately receive registration callbacks if the subject is already active.</remarks>
		public bool Add(IObserver<T> observer)
		{
			if (!observers.CanAdd(observer))
			{
				return false;
			}

			observers.Add(observer);

			// Late registration
			//	If the observer is added while the subject is active, let observer respond to the registration.
			if (!isLocked && HasSubject)
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
		/// <remarks>The observer will be immediately receive registration callbacks if the subject is currently active.</remarks>
		public bool Remove(IObserver<T> observer)
		{
			if (!observers.CanRemove(observer))
			{
				return false;
			}

			observers.Remove(observer);

			// Early unregistration
			//	If the observer is removed while the subject is still active, let observer respond to the unregistration.
			if (!isLocked && HasSubject)
			{
				observer.OnUnregister(Subject);
			}

			return true;
		}

		private void Lock()
		{
			isLocked = true;
			observers.Lock();
		}

		private void Unlock()
		{
			isLocked = false;
			observers.Unlock();
		}
	}
}
