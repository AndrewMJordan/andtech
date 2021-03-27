/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using UnityEngine;

namespace Andtech {

	/// <summary>
	/// Base class for subjects in OBSERVER pattern.
	/// </summary>
	/// <typeparam name="T">The type of the subject.</typeparam>
	public abstract class SubjectBehaviour<T> : MonoBehaviour, IObservable<T> where T : SubjectBehaviour<T> {
		private readonly ObserverSet<T> observers = new ObserverSet<T>();

		#region MONOBEHAVIOUR
		protected virtual void OnEnable() => observers.Set(this as T);

		protected virtual void OnDisable() => observers.Clear(this as T);
		#endregion

		#region INTERFACE
		void IObservable<T>.Register(IObserver<T> observer) => observers.Add(observer);

		void IObservable<T>.Unregister(IObserver<T> observer) => observers.Remove(observer);
		#endregion
	}
}
