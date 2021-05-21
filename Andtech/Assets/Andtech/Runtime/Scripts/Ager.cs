using System;
using UnityEngine;

namespace Andtech
{

	/// <summary>
	/// Interpolates values based on weighted averaging.
	/// </summary>
	[Serializable]
	public class Ager
	{
		/// <summary>
		/// The current aged value.
		/// </summary>
		public float Value
		{
			get => value;
			set => this.value = value;
		}
		/// <summary>
		/// How much influence should incoming values have?
		/// </summary>
		public float Weight
		{
			get => weight;
			set => weight = value;
		}

		[SerializeField]
		private float value = default;
		[Range(0.0F, 1.0F)]
		[SerializeField]
		private float weight = 1.0F;

		public Ager(float weight)
		{
			Weight = weight;
			Value = default;
		}

		public Ager(float weight, float value)
		{
			Weight = weight;
			Value = value;
		}

		public void MoveTo(float value) => MoveTo(value, Time.deltaTime);

		public void MoveTo(float value, float deltaTime)
		{
			Value = Mathf.Lerp(value, Value, Mathf.Pow(1.0F - Weight, deltaTime));
		}
	}
}
