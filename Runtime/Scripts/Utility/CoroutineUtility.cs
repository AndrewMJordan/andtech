/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using System;
using System.Collections;
using UnityEngine;

namespace Andtech {

	public static class CoroutineUtility {

		/// <summary>
		/// Returns an empty routine.
		/// </summary>
		/// <returns>An empty routine.</returns>
		public static IEnumerator Empty {
			get {
				yield break;
			}
		}

		/// <summary>
		/// Delays the coroutine.
		/// </summary>
		/// <param name="routine">The procedure to perform.</param>
		/// <param name="delay">How many seconds to wait.</param>
		/// <returns>The aggregated routine.</returns>
		public static IEnumerator After(this IEnumerator routine, float delay) {
			yield return Delay(delay);
			yield return routine;
		}

		public static IEnumerator Wait(this IEnumerator routine, float delay) {
			yield return routine;
			yield return Yielders.WaitForSeconds(delay);
		}

		public static IEnumerator Delay(float delay) {
			yield return Yielders.WaitForSeconds(delay);
		}

		public static IEnumerator Lerp(float duration, Action<float> interpolator) {
			foreach (var alpha in Tween.Linear(duration)) {
				interpolator(alpha);
				yield return Yielders.WaitForPostUpdate;
			}
		}

		/// <summary>
		/// Performs the callback before the routine.
		/// </summary>
		/// <param name="routine">The routine to perform.</param>
		/// <param name="callback">The callback to perform.</param>
		/// <returns>The aggregated routine.</returns>
		public static IEnumerator Prepend(this IEnumerator routine, Action callback) {
			callback();
			yield return routine;
		}

		/// <summary>
		/// Performs the callback after the routine.
		/// </summary>
		/// <param name="routine">The routine to perform.</param>
		/// <param name="callback">The callback to perform.</param>
		/// <returns>The aggregated routine.</returns>
		public static IEnumerator Append(this IEnumerator routine, Action callback) {
			yield return routine;
			callback();
		}

		/// <summary>
		/// Performs two routines sequentially.
		/// </summary>
		/// <param name="first">The first routine to perform.</param>
		/// <param name="second">The second routine to perform.</param>
		/// <returns>The aggregated routine.</returns>
		public static IEnumerator Concat(this IEnumerator first, IEnumerator second) {
			yield return first;
			yield return second;
		}

		/// <summary>
		/// Converts a coroutine to a routine.
		/// </summary>
		/// <param name="coroutine">The coroutine to convert.</param>
		/// <returns>The routine.</returns>
		public static IEnumerator ToEnumerator(this Coroutine coroutine) {
			yield return coroutine;
		}
	}
}
