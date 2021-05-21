/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using System;
using System.Diagnostics;

namespace Andtech
{

	/// <summary>
	/// A container for a replaceable value.
	/// </summary>
	/// <typeparam name="T">The type of the value contained by the slot.</typeparam>
	[DebuggerStepThrough]
	public class Slot<T> where T : class
	{
		/// <summary>
		/// The current value.
		/// </summary>
		public T Value
		{
			get => value;
			set
			{
				T oldValue = Value;
				T newValue = value;
				if (ReferenceEquals(newValue, oldValue))
				{
					return;
				}

				this.value = newValue;
				OnValueChanged?.Invoke(oldValue, newValue);
			}
		}
		public bool HasValue => Value != null;

		private T value;

		public Slot() : this(null) { }

		public Slot(T value) => Value = value;

		#region EVENT
		/// <summary>
		/// The value became changed.
		/// (Client will receive the oldValue and newValue)
		/// </summary>
		public event Action<T, T> OnValueChanged;
		#endregion
	}
}
