/*
 *	Copyright (c) 2021, AndtechGames
 *	All rights reserved.
 *	
 *	This source code is licensed under the BSD-style license found in the
 *	LICENSE file in the root directory of this source tree
 */

using System.Runtime.CompilerServices;
using UnityEngine;

namespace Andtech
{

    /// <summary>
    /// Standard easing functions.
    /// </summary>
    public static class Easing
    {
        private const float MIDPOINT = 0.5f;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float Linear(float t) => t;

        #region Quadratic
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float EaseInQuadratic(float t) => t * t;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float EaseOutQuadratic(float t) => 1.0f - (1.0f - t) * (1.0f - t);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float EaseInOutQuadratic(float t) => EaseInOutPow(t, 2.0f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float EaseOutInQuadratic(float t) => EaseOutInPow(t, 2.0f);
        #endregion

        #region Cubic
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float EaseInCubic(float t) => t * t * t;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float EaseOutCubic(float t) => 1.0f - (1.0f - t) * (1.0f - t) * (1.0f - t);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float EaseInOutCubic(float t) => EaseInOutPow(t, 3.0f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float EaseOutInCubic(float t) => EaseOutInPow(t, 3.0f);
        #endregion

        #region Quartic
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float EaseInQuartic(float t) => t * t * t * t;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float EaseOutQuartic(float t) => 1.0f - (1.0f - t) * (1.0f - t) * (1.0f - t) * (1.0f - t);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float EaseInOutQuartic(float t) => EaseInOutPow(t, 4.0f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float EaseOutInQuartic(float t) => EaseOutInPow(t, 4.0f);
        #endregion

        #region Quintic
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float EaseInQuintic(float t) => t * t * t * t * t;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float EaseOutQuintic(float t) => 1.0f - (1.0f - t) * (1.0f - t) * (1.0f - t) * (1.0f - t) * (1.0f - t);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float EaseInOutQuintic(float t) => EaseInOutPow(t, 5.0f);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float EaseOutInQuintic(float t) => EaseOutInPow(t, 5.0f);
        #endregion

        #region Pow
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float EaseInPow(float t, float power) => Mathf.Pow(t, power);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float EaseOutPow(float t, float power) => 1.0f - EaseInPow(1.0f - t, power);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float EaseInOutPow(float t, float power)
        {
            if (t < MIDPOINT)
            {
                return Mathf.Pow(2.0f * t, power) / 2.0f;
            }

            return 1.0f - Mathf.Pow(-2.0f * t + 2.0f, power) / 2.0f;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float EaseOutInPow(float t, float power)
        {
            if (t < MIDPOINT)
            {
                return (1.0f - Mathf.Pow(-2.0f * t + 1.0f, power)) / 2.0f;
            }

            return (1.0f + Mathf.Pow(2.0f * t - 1.0f, power)) / 2.0f;
        }
        #endregion
    }
}
