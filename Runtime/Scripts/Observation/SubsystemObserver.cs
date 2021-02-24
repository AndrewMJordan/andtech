/*
 *	Copyright (c) 2020, AndrewMJordan
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using UnityEngine;

namespace Andtech {

	/// <summary>
	/// Template for observing a target subsystem.
	/// </summary>
	/// <typeparam name="TSubsystem">The subsystem to target.</typeparam>
	public abstract class SubsystemObserver<TSubsystem> : MonoBehaviour, IObserver<TSubsystem> where TSubsystem : SubsystemBehaviour<TSubsystem> {

		#region MONOBEHAVIOUR
		protected virtual void OnEnable() => SubsystemBehaviour<TSubsystem>.Register(this);

		protected virtual void OnDisable() => SubsystemBehaviour<TSubsystem>.Unregister(this);
		#endregion

		#region ABSTRACT
		protected abstract void OnRegister(TSubsystem instance);

		protected abstract void OnUnregister(TSubsystem instance);
		#endregion

		#region INTERFACE
		void IObserver<TSubsystem>.OnRegister(TSubsystem instance) => OnRegister(instance);

		void IObserver<TSubsystem>.OnUnregister(TSubsystem instance) => OnUnregister(instance);
		#endregion
	}
}
