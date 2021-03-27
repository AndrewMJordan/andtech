/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using System.Runtime.CompilerServices;
using UnityEngine;

namespace Andtech {

	/// <summary>
	/// Standard easing functions.
	/// </summary>
	public static class Easing {
		private const float MIDPOINT = 0.5F;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Linear(float t) => t;

		#region Quadratic
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float EaseInQuadratic(float t) => t * t;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float EaseOutQuadratic(float t) => 1.0F - (1.0F - t) * (1.0F - t);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float EaseInOutQuadratic(float t) => EaseInOutPow(t, 2.0F);
		#endregion

		#region Cubic
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float EaseInCubic(float t) => t * t * t;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float EaseOutCubic(float t) => 1.0F - (1.0F - t) * (1.0F - t) * (1.0F - t);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float EaseInOutCubic(float t) => EaseInOutPow(t, 3.0F);
		#endregion

		#region Quartic
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float EaseInQuartic(float t) => t * t * t * t;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float EaseOutQuartic(float t) => 1.0F - (1.0F - t) * (1.0F - t) * (1.0F - t) * (1.0F - t);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float EaseInOutQuartic(float t) => EaseInOutPow(t, 4.0F);
		#endregion

		#region Quintic
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float EaseInQuintic(float t) => t * t * t * t * t;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float EaseOutQuintic(float t) => 1.0F - (1.0F - t) * (1.0F - t) * (1.0F - t) * (1.0F - t) * (1.0F - t);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float EaseInOutQuintic(float t) => EaseInOutPow(t, 5.0F);
		#endregion

		#region Pow
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float EaseInPow(float t, float power) => Mathf.Pow(t, power);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float EaseOutPow(float t, float power) => 1.0F - EaseInPow(1.0F - t, power);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float EaseInOutPow(float t, float power) => EaseInOutPow(t, power, MIDPOINT);

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float EaseInOutPow(float t, float power, float midpoint) {
			if (t < midpoint) {
				return Mathf.Pow(t / midpoint, power) * midpoint;
			}

			return 1.0F - Mathf.Pow((1.0F - t) / (1.0F - midpoint), power) * (1.0F - midpoint);
		}
		#endregion
	}
}
