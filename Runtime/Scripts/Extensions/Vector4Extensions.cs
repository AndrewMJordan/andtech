/*
 *	Copyright (c) 2020, AndrewMJordan
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using UnityEngine;

namespace Andtech {

	public static class Vector4Extensions {

		/// <summary>
		/// Selects components from a vector.
		/// </summary>
		/// <param name="original">The original vector.</param>
		/// <param name="x">New x component value.</param>
		/// <param name="y">New y component value.</param>
		/// <param name="z">New z component value.</param>
		/// <param name="w">New w component value.</param>
		/// <returns>A combination of the original and new values.</returns>
		public static Vector4 With(this Vector4 original, float? x = null, float? y = null, float? z = null, float? w = null) => new Vector4 {
			x = x ?? original.x,
			y = y ?? original.y,
			z = z ?? original.z,
			w = w ?? original.w
		};

		/// <summary>
		/// Makes this <paramref name="vector"/> have a magnitude of 1.
		/// </summary>
		/// <param name="vector">The vector to scale.</param>
		/// <param name="length">The length of the original vector.</param>
		public static void Normalize(this ref Vector4 vector, out float length) {
			length = vector.magnitude;
			vector /= length;
		}

		/// <summary>
		/// Returns the components rounded to the nearest integer.
		/// </summary>
		/// <param name="vector">The vector whose components should be rounded.</param>
		/// <returns>The vector with rounded components.</returns>
		public static Vector4 Round(this Vector4 vector) {
			return new Vector4() {
				x = Mathf.Round(vector.x),
				y = Mathf.Round(vector.y),
				z = Mathf.Round(vector.z),
				w = Mathf.Round(vector.w)
			};
		}

		/// <summary>
		/// Returns the components rounded to the nearest integer.
		/// </summary>
		/// <param name="vector">The vector whose components should be rounded.</param>
		/// <returns>The vector with rounded components.</returns>
		public static Vector4 RoundToInt(this Vector4 vector) {
			return new Vector4() {
				x = Mathf.RoundToInt(vector.x),
				y = Mathf.RoundToInt(vector.y),
				z = Mathf.RoundToInt(vector.z),
				w = Mathf.RoundToInt(vector.w)
			};
		}

		/// <summary>
		/// Returns the largest integer smaller than or equal to f (for each component).
		/// </summary>
		/// <param name="vector">The vector whose components should be floored.</param>
		/// <returns>The vector with floored components.</returns>
		public static Vector4 Floor(this Vector4 vector) {
			return new Vector4() {
				x = Mathf.Floor(vector.x),
				y = Mathf.Floor(vector.y),
				z = Mathf.Floor(vector.z),
				w = Mathf.Floor(vector.w)
			};
		}

		/// <summary>
		/// Returns the largest integer smaller than or equal to f (for each component).
		/// </summary>
		/// <param name="vector">The vector whose components should be floored.</param>
		/// <returns>The vector with floored components.</returns>
		public static Vector4 FloorToInt(this Vector4 vector) {
			return new Vector4() {
				x = Mathf.FloorToInt(vector.x),
				y = Mathf.FloorToInt(vector.y),
				z = Mathf.FloorToInt(vector.z),
				w = Mathf.FloorToInt(vector.w)
			};
		}

		/// <summary>
		/// Returns the largest integer greater than or equal to f (for each component).
		/// </summary>
		/// <param name="vector">The vector whose components should be ceiled.</param>
		/// <returns>The vector with ceiled components.</returns>
		public static Vector4 Ceil(this Vector4 vector) {
			return new Vector4() {
				x = Mathf.Ceil(vector.x),
				y = Mathf.Ceil(vector.y),
				z = Mathf.Ceil(vector.z),
				w = Mathf.Ceil(vector.w)
			};
		}

		/// <summary>
		/// Returns the largest integer greater than or equal to f (for each component).
		/// </summary>
		/// <param name="vector">The vector whose components should be ceiled.</param>
		/// <returns>The vector with ceiled components.</returns>
		public static Vector4 CeilToInt(this Vector4 vector) {
			return new Vector4() {
				x = Mathf.CeilToInt(vector.x),
				y = Mathf.CeilToInt(vector.y),
				z = Mathf.CeilToInt(vector.z),
				w = Mathf.CeilToInt(vector.w)
			};
		}

		/// <summary>
		/// Returns a component-wise reciprocal of <paramref name="vector"/>.
		/// </summary>
		/// <param name="vector">The vector to reciprocate.</param>
		/// <returns>The reciprocal of <paramref name="vector"/>.</returns>
		public static Vector4 Reciprocal(this Vector4 vector) {
			return new Vector4() {
				x = 1.0F / vector.x,
				y = 1.0F / vector.y,
				z = 1.0F / vector.z,
				w = 1.0F / vector.w
			};
		}

		/// <summary>
		/// Divides the current vector component-wise by another.
		/// </summary>
		/// <param name="a">The divident vector.</param>
		/// <param name="b">The divisor vector</param>
		/// <returns>A vector of component-wise quotients.</returns>
		public static Vector4 DivideBy(this Vector4 a, Vector4 b) {
			return new Vector4() {
				x = a.x / b.x,
				y = a.y / b.y,
				z = a.z / b.z,
				w = a.z / b.z
			};
		}
	}
}
