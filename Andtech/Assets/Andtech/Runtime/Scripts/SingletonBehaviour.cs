using System;
using System.Diagnostics;
using UnityEngine;

namespace Andtech {

	/// <summary>
	/// Base class for defining singleton MonoBehaviours.
	/// </summary>
	/// <typeparam name="T">The type of the singleton instance.</typeparam>
	[DebuggerStepThrough]
	public abstract class SingletonBehaviour<T> : MonoBehaviour where T : SingletonBehaviour<T> {
		public bool IsSingletonInstance {
			get {
				if (slot is null)
					return false;

				if (!slot.HasValue)
					return false;

				return ReferenceEquals(this, Instance);
			}
		}

		/// <summary>
		/// The type has a commissioned instance.
		/// </summary>
		public static bool HasInstance => slot.HasValue;
		/// <summary>
		/// The current singleton instance.
		/// </summary>
		public static T Instance {
			get {
				if (!HasInstance)
					throw new SingletonReferenceException(typeof(T));

				return slot.Value;
			}
			set => slot.Value = value;
		}

		private static readonly Slot<T> slot;

		static SingletonBehaviour() {
			slot = new Slot<T>();
			slot.OnValueChanged += (oldValue, newValue) => {
				if (oldValue != null)
					Decommissioned?.Invoke(null, new SingletonEventArgs { Instance = oldValue });
				if (newValue != null)
					Commissioned?.Invoke(null, new SingletonEventArgs { Instance = newValue });
			};
		}

		[RuntimeInitializeOnLoadMethod]
		internal static void ResetCache() => Instance = null;

		#region MONOBEHAVIOUR
		protected virtual void OnEnable() {
			if (!HasInstance)
				Instance = this as T;
		}

		protected virtual void OnDisable() {
			if (IsSingletonInstance)
				Instance = null;
		}
		#endregion

		#region EVENT
		/// <summary>
		/// A singleton instance became newly active.
		/// </summary>
		public static event EventHandler<SingletonEventArgs> Commissioned;
		/// <summary>
		/// The former singleton instance became inactive.
		/// </summary>
		public static event EventHandler<SingletonEventArgs> Decommissioned;
		#endregion

		#region TYPE
		public class SingletonEventArgs : EventArgs {
			public T Instance { get; internal set; }
		}
		#endregion
	}
}
