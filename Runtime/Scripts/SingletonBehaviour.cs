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

namespace Andtech
{


	/// <summary>
	/// Base class for defining singleton MonoBehaviours.
	/// </summary>
	/// <typeparam name="T">The type of the singleton instance.</typeparam>
	[DebuggerStepThrough]
	public abstract class SingletonBehaviour : MonoBehaviour
	{
		/// <summary>
		/// There exists a singleton instance.
		/// </summary>
		public static bool HasInstance => slot.HasValue;
		/// <summary>
		/// Is this the current singleton instance?
		/// </summary>
		public bool IsSingletonInstance
		{
			get
			{
				if (!slot.HasValue)
				{
					return false;
				}

				return ReferenceEquals(this, Instance);
			}
		}
		/// <summary>
		/// The current singleton instance.
		/// </summary>
		public static SingletonBehaviour Instance
		{
			get => slot.Value;
			protected set => slot.Value = value;
		}
		protected static Slot<SingletonBehaviour> Slot => slot;

		private static readonly Slot<SingletonBehaviour> slot = new Slot<SingletonBehaviour>();

		/// <summary>
		/// Initializes the singleton environment.
		/// </summary>
		/// <remarks>Note: <see cref="RuntimeInitializeOnLoadMethodAttribute"/> may not work on generic <see cref="MonoBehaviour"/>s.</remarks>
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		internal static void InitializeOnLoad()
		{
			Instance = null;
			InitializedOnLoad?.Invoke();
		}

		protected void SetInstance(SingletonBehaviour instance)
		{
			if (!HasInstance)
			{
				Instance = instance;
			}
		}

		protected void ClearInstance(SingletonBehaviour instance)
		{
			if (instance.IsSingletonInstance)
			{
				Instance = null;
			}
		}

		#region MONOBEHAVIOUR
		protected virtual void OnEnable() => SetInstance(this);

		protected virtual void OnDisable() => ClearInstance(this);
		#endregion

		#region EVENT
		/// <summary>
		/// Use this to receive <see cref="RuntimeInitializeOnLoadMethodAttribute"/> callbacks.
		/// </summary>
		public static event Action InitializedOnLoad;
		#endregion
	}

	public abstract partial class SingletonBehaviour<T> : SingletonBehaviour where T : SingletonBehaviour<T>
	{
		public static new T Instance {
			get
			{
				if (HasInstance)
				{
					return (T)SingletonBehaviour.Instance;
				}

				throw new SingletonReferenceException(typeof(T));
			}
			protected set => SingletonBehaviour.Instance = value;
		}

		static SingletonBehaviour()
		{
			Slot.OnValueChanged += (oldValue, newValue) =>
			{
				if (oldValue != null)
				{
					Decommissioned?.Invoke(null, new SingletonEventArgs((T)oldValue));
				}
				if (newValue != null)
				{
					Commissioned?.Invoke(null, new SingletonEventArgs((T)newValue));
				}
			};
		}

		#region TYPE
		public class SingletonEventArgs : EventArgs
		{
			public readonly T Instance;

			public SingletonEventArgs(T instance) => Instance = instance;
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
	}
}
