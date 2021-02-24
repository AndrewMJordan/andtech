using UnityEngine;

namespace Andtech {

	public abstract class SubsystemBehaviour<T> : SingletonBehaviour<T> where T : SubsystemBehaviour<T> {
		private static readonly ObserverSet<T> observers = new ObserverSet<T>();

		static SubsystemBehaviour() {
			Commissioned += (sender, e) => observers.Set(e.Instance);
			Decommissioned += (sender, e) => observers.Clear(e.Instance);
		}

		/// <summary>
		/// Adds a subsystem observer.
		/// </summary>
		/// <param name="observer">The observer to add.</param>
		/// <returns>The observer was successfully added.</returns>
		/// <remarks>The observer will be immediately receive registration callbacks if the subsystem is already active.</remarks>
		public static bool Register(IObserver<T> observer) => observers.Add(observer);

		/// <summary>
		/// Removes a subsystem observer.
		/// </summary>
		/// <param name="observer">The observer to remove.</param>
		/// <returns>The observer was successfully removed.</returns>
		/// <remarks>The observer will be immediately receive registration callbacks if the subsystem is currently active.</remarks>
		public static bool Unregister(IObserver<T> observer) => observers.Remove(observer);

		[RuntimeInitializeOnLoadMethod]
		internal static void ResetCache() => observers?.Clear();
	}
}
