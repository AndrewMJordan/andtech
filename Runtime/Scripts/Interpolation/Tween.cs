/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Andtech
{

	/// <summary>
	/// Standard tweening functions.
	/// </summary>
	public static class Tween
	{

		/// <summary>
		/// Generates tweening values using scaled time.
		/// </summary>
		/// <param name="easingFunction">The function to evaluate. Evaluated values should be on the range [0, 1].</param>
		/// <param name="duration">The duration of the animation.</param>
		/// <returns>Tweening values [0, 1] from the function.</returns>
		public static IEnumerable<float> Generate(Func<float, float> easingFunction, float duration)
		{
			for (float t = 0.0F; t < duration; t += Time.deltaTime)
			{
				yield return easingFunction(t / duration);
			}

			yield return easingFunction(1.0F);
		}

		/// <summary>
		/// Generates tweening values using unscaled time.
		/// </summary>
		/// <param name="easingFunction">The function to evaluate. Evaluated values should be on the range [0, 1].</param>
		/// <param name="duration">The duration of the animation.</param>
		/// <returns>Tweening values [0, 1] from the function.</returns>
		public static IEnumerable<float> GenerateRealtime(Func<float, float> easingFunction, float duration)
		{
			for (float t = 0.0F; t < duration; t += Time.unscaledDeltaTime)
			{
				yield return easingFunction(t / duration);
			}

			yield return easingFunction(1.0F);
		}

		public static IEnumerable<float> Linear(float duration) => Generate(Easing.Linear, duration);

		public static IEnumerable<float> LinearRealtime(float duration) => GenerateRealtime(Easing.Linear, duration);

		#region Quadratic
		public static IEnumerable<float> EaseInQuadratic(float duration) => Generate(Easing.EaseInQuadratic, duration);

		public static IEnumerable<float> EaseInQuadraticRealtime(float duration) => GenerateRealtime(Easing.EaseInQuadratic, duration);

		public static IEnumerable<float> EaseOutQuadratic(float duration) => Generate(Easing.EaseOutQuadratic, duration);

		public static IEnumerable<float> EaseOutQuadraticRealtime(float duration) => GenerateRealtime(Easing.EaseOutQuadratic, duration);

		public static IEnumerable<float> EaseInOutQuadratic(float duration) => Generate(Easing.EaseInOutQuadratic, duration);

		public static IEnumerable<float> EaseInOutQuadraticRealtime(float duration) => GenerateRealtime(Easing.EaseInOutQuadratic, duration);

		public static IEnumerable<float> EaseOutInQuadratic(float duration) => Generate(Easing.EaseOutInQuadratic, duration);

		public static IEnumerable<float> EaseOutInQuadraticRealtime(float duration) => GenerateRealtime(Easing.EaseOutInQuadratic, duration);
		#endregion

		#region Cubic
		public static IEnumerable<float> EaseInCubic(float duration) => Generate(Easing.EaseInCubic, duration);

		public static IEnumerable<float> EaseInCubicRealtime(float duration) => GenerateRealtime(Easing.EaseInCubic, duration);

		public static IEnumerable<float> EaseOutCubic(float duration) => Generate(Easing.EaseOutCubic, duration);

		public static IEnumerable<float> EaseOutCubicRealtime(float duration) => GenerateRealtime(Easing.EaseOutCubic, duration);

		public static IEnumerable<float> EaseInOutCubic(float duration) => Generate(Easing.EaseInOutCubic, duration);

		public static IEnumerable<float> EaseInOutCubicRealtime(float duration) => GenerateRealtime(Easing.EaseInOutCubic, duration);

		public static IEnumerable<float> EaseOutInCubic(float duration) => Generate(Easing.EaseOutInCubic, duration);

		public static IEnumerable<float> EaseOutInCubicRealtime(float duration) => GenerateRealtime(Easing.EaseOutInCubic, duration);
		#endregion

		#region Quartic
		public static IEnumerable<float> EaseInQuartic(float duration) => Generate(Easing.EaseInQuartic, duration);

		public static IEnumerable<float> EaseInQuarticRealtime(float duration) => GenerateRealtime(Easing.EaseInQuartic, duration);

		public static IEnumerable<float> EaseOutQuartic(float duration) => Generate(Easing.EaseOutQuartic, duration);

		public static IEnumerable<float> EaseOutQuarticRealtime(float duration) => GenerateRealtime(Easing.EaseOutQuartic, duration);

		public static IEnumerable<float> EaseInOutQuartic(float duration) => Generate(Easing.EaseInOutQuartic, duration);

		public static IEnumerable<float> EaseInOutQuarticRealtime(float duration) => GenerateRealtime(Easing.EaseInOutQuartic, duration);

		public static IEnumerable<float> EaseOutInQuartic(float duration) => Generate(Easing.EaseOutInQuartic, duration);

		public static IEnumerable<float> EaseOutInQuarticRealtime(float duration) => GenerateRealtime(Easing.EaseOutInQuartic, duration);
		#endregion

		#region Quintic
		public static IEnumerable<float> EaseInQuintic(float duration) => Generate(Easing.EaseInQuintic, duration);

		public static IEnumerable<float> EaseInQuinticRealtime(float duration) => GenerateRealtime(Easing.EaseInQuintic, duration);

		public static IEnumerable<float> EaseOutQuintic(float duration) => Generate(Easing.EaseOutQuintic, duration);

		public static IEnumerable<float> EaseOutQuinticRealtime(float duration) => GenerateRealtime(Easing.EaseOutQuintic, duration);

		public static IEnumerable<float> EaseInOutQuintic(float duration) => Generate(Easing.EaseInOutQuintic, duration);

		public static IEnumerable<float> EaseInOutQuinticRealtime(float duration) => GenerateRealtime(Easing.EaseInOutQuintic, duration);

		public static IEnumerable<float> EaseOutInQuintic(float duration) => Generate(Easing.EaseOutInQuintic, duration);

		public static IEnumerable<float> EaseOutInQuinticRealtime(float duration) => GenerateRealtime(Easing.EaseOutInQuintic, duration);
		#endregion

		#region Pow
		public static IEnumerable<float> EaseInPow(float duration, float power) => Generate(x => Easing.EaseInPow(x, power), duration);

		public static IEnumerable<float> EaseInPowRealtime(float duration, float power) => GenerateRealtime(x => Easing.EaseInPow(x, power), duration);

		public static IEnumerable<float> EaseOutPow(float duration, float power) => Generate(x => Easing.EaseOutPow(x, power), duration);

		public static IEnumerable<float> EaseOutPowRealtime(float duration, float power) => GenerateRealtime(x => Easing.EaseOutPow(x, power), duration);

		public static IEnumerable<float> EaseInOutPow(float duration, float power) => Generate(x => Easing.EaseInOutPow(x, power), duration);

		public static IEnumerable<float> EaseInOutPowRealtime(float duration, float power) => GenerateRealtime(x => Easing.EaseInOutPow(x, power), duration);

		public static IEnumerable<float> EaseOutInPow(float duration, float power) => Generate(x => Easing.EaseOutInPow(x, power), duration);

		public static IEnumerable<float> EaseOutInPowRealtime(float duration, float power) => GenerateRealtime(x => Easing.EaseOutInPow(x, power), duration);
		#endregion
	}
}
