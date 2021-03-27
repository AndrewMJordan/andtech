/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

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
			slot.Replaced += (sender, e) => {
				if (e.OldValue != null)
					Decommissioned?.Invoke(null, new SingletonEventArgs { Instance = e.OldValue });
				if (e.NewValue != null)
					Commissioned?.Invoke(null, new SingletonEventArgs { Instance = e.NewValue });
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
