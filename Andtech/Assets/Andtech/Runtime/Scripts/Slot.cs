using System;
using System.Diagnostics;

namespace Andtech {

	public class SlotEventArgs<T> : EventArgs {
		public T OldValue { get; internal set; }
		public T NewValue { get; internal set; }
	}

	/// <summary>
	/// A container for a replaceable value.
	/// </summary>
	/// <typeparam name="T">The type of the value contained by the slot.</typeparam>
	[DebuggerStepThrough]
	public class Slot<T> where T : class {
		/// <summary>
		/// The current value.
		/// </summary>
		public T Value {
			get => value;
			set {
				T oldValue = Value;
				T newValue = value;
				if (ReferenceEquals(newValue, oldValue))
					return;

				this.value = newValue;
				OnReplace(new SlotEventArgs<T> { OldValue = oldValue, NewValue = Value });
			}
		}
		public bool HasValue => Value != null;

		private T value;

		public Slot() : this(null) { }

		public Slot(T value) => Value = value;

		#region EVENT
		/// <summary>
		/// The value became replaced.
		/// (Client will receive the oldValue and newValue)
		/// </summary>
		public event EventHandler<SlotEventArgs<T>> Replaced;

		protected virtual void OnReplace(SlotEventArgs<T> e) => Replaced?.Invoke(this, e);
		#endregion
	}
}
