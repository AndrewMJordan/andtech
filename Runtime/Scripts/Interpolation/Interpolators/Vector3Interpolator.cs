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
	/// Interpolates a vector of floats.
	/// </summary>
	public class Vector3Interpolator {
		public Vector3 Current {
			get => current;
			set => current = value;
		}
		public Vector3 Target {
			get => target;
			set => target = value;
		}
		public float MaxSpeed { get; set; } = Mathf.Infinity;
		public float SmoothTime { get; set; } = 1.0F;
		public Vector3 Velocity {
			get => velocity;
			set => velocity = value;
		}

		private Vector3 current;
		private Vector3 target;
		private Vector3 velocity;

		public Vector3Interpolator() {
			SmoothTime = 1.0F;
			MaxSpeed = Mathf.Infinity;
		}

		public void MoveTowards() => MoveTowards(Time.deltaTime);

		public void MoveTowards(float deltaTime) {
			current.x = Mathf.MoveTowards(current.x, target.x, MaxSpeed * deltaTime);
			current.y = Mathf.MoveTowards(current.y, target.y, MaxSpeed * deltaTime);
			current.z = Mathf.MoveTowards(current.z, target.z, MaxSpeed * deltaTime);
		}

		public void MoveTowardsAngle() => MoveTowardsAngle(Time.deltaTime);

		public void MoveTowardsAngle(float deltaTime) {
			current.x = Mathf.MoveTowardsAngle(current.x, target.x, MaxSpeed * deltaTime);
			current.y = Mathf.MoveTowardsAngle(current.y, target.y, MaxSpeed * deltaTime);
			current.z = Mathf.MoveTowardsAngle(current.z, target.z, MaxSpeed * deltaTime);
		}

		public void SmoothDamp() => SmoothDamp(Time.deltaTime);

		public void SmoothDamp(float deltaTime) {
			current.x = Mathf.SmoothDamp(current.x, target.x, ref velocity.x, SmoothTime, MaxSpeed, deltaTime);
			current.y = Mathf.SmoothDamp(current.y, target.y, ref velocity.y, SmoothTime, MaxSpeed, deltaTime);
			current.z = Mathf.SmoothDamp(current.z, target.z, ref velocity.z, SmoothTime, MaxSpeed, deltaTime);
		}

		public void SmoothDampAngle() => SmoothDampAngle(Time.deltaTime);

		public void SmoothDampAngle(float deltaTime) {
			current.x = Mathf.SmoothDampAngle(current.x, target.x, ref velocity.x, SmoothTime, MaxSpeed, deltaTime);
			current.y = Mathf.SmoothDampAngle(current.y, target.y, ref velocity.y, SmoothTime, MaxSpeed, deltaTime);
			current.z = Mathf.SmoothDampAngle(current.z, target.z, ref velocity.z, SmoothTime, MaxSpeed, deltaTime);
		}

		public static Vector3Interpolator Linear(float maxAcceleration) => Linear(maxAcceleration, Vector3.zero);

		public static Vector3Interpolator Linear(float maxAcceleration, Vector3 initialValue) => new Vector3Interpolator { Current = initialValue, MaxSpeed = maxAcceleration };

		public static Vector3Interpolator Smooth(float smoothTime) => Smooth(smoothTime, Vector3.zero);

		public static Vector3Interpolator Smooth(float smoothTime, Vector3 initialValue) => new Vector3Interpolator { Current = initialValue, SmoothTime = smoothTime };

		/// <summary>
		/// Casts the interpolator to the type of the internal value.
		/// </summary>
		/// <param name="interpolator">The interpolator to cast.</param>
		public static implicit operator Vector3(Vector3Interpolator interpolator) => interpolator.Current;
	}
}
