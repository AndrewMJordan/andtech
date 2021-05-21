/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using UnityEngine;

namespace Andtech
{

	/// <summary>
	/// Calculates interpolation parameters.
	/// </summary>
	public static class FrameInterpolation
	{
		/// <summary>
		/// The current interpolation value within the physics interval.
		/// </summary>
		public static float InterpolationFactor
		{
			get
			{
				if (Time.frameCount != lastFrameCount)
				{
					cachedInterpolationFactor = (Time.time - Time.fixedTime) / Time.fixedDeltaTime;
					lastFrameCount = Time.frameCount;
				}

				return cachedInterpolationFactor;
			}
		}

		private static int lastFrameCount;
		private static float cachedInterpolationFactor;

		[RuntimeInitializeOnLoadMethod]
		internal static void ResetCaches() => lastFrameCount = -1;
	}
}
